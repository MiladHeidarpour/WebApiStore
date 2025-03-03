using Application.Catalogs.CatalogItems.UriComposer;
using Application.Discounts;
using Application.Interfaces.Contexts;
using AutoMapper;
using Domain.Orders;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Application.Orders;

public interface IOrderService
{
    int CreateOrder(int basketId,int userAddressId,PaymentMethod paymentMethod);
}

public class OrderService : IOrderService
{
    private readonly IDataBaseContext _context;
    private readonly IMapper _mapper;
    private readonly IUriComposerService _uriComposer;
    private readonly IDiscountHistoryService _discountHistoryService;

    public OrderService(IDataBaseContext context, IMapper mapper, IUriComposerService uriComposer, IDiscountHistoryService discountHistoryService)
    {
        _context = context;
        _mapper = mapper;
        _uriComposer = uriComposer;
        _discountHistoryService = discountHistoryService;
    }

    public int CreateOrder(int basketId, int userAddressId, PaymentMethod paymentMethod)
    {
        var basket=_context.Baskets.Include(p=>p.Items)
            .Include(p=>p.AppliedDiscount).SingleOrDefault(p=>p.Id == basketId);

        int[] ids = basket.Items.Select(p => p.CatalogItemId).ToArray();
        var catalogItems = _context.CatalogItems.Include(c=>c.CatalogItemImages).Where(p => ids.Contains(p.Id));
        
        var ordreItems=basket.Items.Select(basketItem =>
        {
            var catalogItem=catalogItems.First(c=>c.Id==basketItem.CatalogItemId);
            var orderItem=new OrderItem(catalogItem.Id,catalogItem.Name,_uriComposer.ComposeImageUri(catalogItem?.CatalogItemImages?.FirstOrDefault()?.Src??""),catalogItem.Price,basketItem.Quantity);
            return orderItem;
        }).ToList();
        
        var userAddress=_context.UserAddresses.SingleOrDefault(p=>p.Id==userAddressId);
        var address=_mapper.Map<Address>(userAddress);
        
        var order=new Order(basket.BuyerId,address,ordreItems,paymentMethod,basket.AppliedDiscount);
        _context.Orders.Add(order);
        _context.Baskets.Remove(basket);
        _context.SaveChanges();
        if (basket.AppliedDiscount!=null)
        {
            _discountHistoryService.InsertDiscountUsageHistory(basket.Id,order.Id);
        }
        return order.Id;
    }
}