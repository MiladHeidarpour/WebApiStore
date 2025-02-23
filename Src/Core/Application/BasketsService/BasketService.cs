using Application.Catalogs.CatalogItems.UriComposer;
using Application.Interfaces.Contexts;
using Domain.Baskets;
using Microsoft.EntityFrameworkCore;

namespace Application.BasketsService;

public class BasketService : IBasketService
{
    private readonly IDataBaseContext _context;
    private readonly IUriComposerService _uriService;

    public BasketService(IDataBaseContext context, IUriComposerService uriService)
    {
        _context = context;
        _uriService = uriService;
    }

    public BasketDto GetOrCreateBasketForUser(string BuyerId)
    {
        var basket = _context.Baskets
            .Include(p => p.Items)
            .ThenInclude(p => p.CatalogItem)
            .ThenInclude(p => p.CatalogItemImages)
            .SingleOrDefault(p => p.BuyerId == BuyerId);

        if (basket == null)
        {
            //سبد خرید را ایجاد کنید
            return CreateBasketForUser(BuyerId);
        }
        return new BasketDto
        {
            Id = basket.Id,
            BuyerId = basket.BuyerId,
            Items = basket.Items.Select(item => new BasketItemDto
            {
                CatalogItemId = item.CatalogItemId,
                Id = item.Id,
                CatalogName = item.CatalogItem.Name,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice,
                ImageUrl = _uriService.ComposeImageUri(item?.CatalogItem?.CatalogItemImages?.FirstOrDefault()?.Src ?? ""),
            }).ToList(),
        };
    }

    public void AddItemToBasket(int basketId, int catalogItemId, int quantity = 1)
    {
        var basket = _context.Baskets.FirstOrDefault(p => p.Id == basketId);
        if (basket == null)
            throw new Exception("");

        var catalog = _context.CatalogItems.Find(catalogItemId);
        basket.AddItem(catalogItemId, quantity, catalog.Price);

        _context.SaveChanges();
    }

    private BasketDto CreateBasketForUser(string BuyerId)
    {
        Basket basket = new Basket(BuyerId);
        _context.Baskets.Add(basket);
        _context.SaveChanges();
        return new BasketDto
        {
            BuyerId = basket.BuyerId,
            Id = basket.Id,
        };
    }
}