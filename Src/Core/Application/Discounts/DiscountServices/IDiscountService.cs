using Application.Interfaces.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Application.Discounts.DiscountServices;

public interface IDiscountService
{
    List<CatalogItemDto> GetCatalogItems(string? searchKey);
    bool ApplyDiscountInBasket(string couponCode, int basketId);
    bool RemoveDiscountFromBasket( int basketId);
}

public class DiscountService:IDiscountService
{
    private readonly IDataBaseContext _context;

    public DiscountService(IDataBaseContext context)
    {
        _context = context;
    }

    public List<CatalogItemDto> GetCatalogItems(string? searchKey=null)
    {
        if (!string.IsNullOrEmpty(searchKey))
        {
            var data = _context.CatalogItems.Where(p => p.Name.Contains(searchKey)).Select(p=>new CatalogItemDto()
            {
                Id = p.Id,
                Name = p.Name,
            }).ToList();
            return data;
        }
        else
        {
            var data = _context.CatalogItems.OrderByDescending(p=>p.Id).Take(10).Select(p => new CatalogItemDto()
            {
                Id = p.Id,
                Name = p.Name,
            }).ToList();
            return data;
        }
    }

    public bool ApplyDiscountInBasket(string couponCode, int basketId)
    {
        var basket = _context.Baskets.Include(p => p.Items).Include(p => p.AppliedDiscount)
            .FirstOrDefault(p => p.Id == basketId);

        var discount = _context.Discounts.Where(p => p.CouponCode.Equals(couponCode)).FirstOrDefault();

        basket.ApplyDiscountCode(discount);
        _context.SaveChanges();
        return true;
    }

    public bool RemoveDiscountFromBasket(int basketId)
    {
        var basket = _context.Baskets.Find(basketId);
        basket.RemoveDescount();
        _context.SaveChanges();
        return true;
    }
}

public class CatalogItemDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}