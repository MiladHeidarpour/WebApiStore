using Application.Dtos;
using Application.Interfaces.Contexts;
using Domain.Discounts;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Application.Discounts.DiscountServices;

public interface IDiscountService
{
    List<CatalogItemDto> GetCatalogItems(string? searchKey);
    bool ApplyDiscountInBasket(string couponCode, int basketId);
    bool RemoveDiscountFromBasket( int basketId);
    BaseDto IsDiscountValid(string couponCode,User user);
}

public class DiscountService:IDiscountService
{
    private readonly IDataBaseContext _context;
    private readonly IDiscountHistoryService _discountHistoryService;

    public DiscountService(IDataBaseContext context, IDiscountHistoryService discountHistoryService)
    {
        _context = context;
        _discountHistoryService = discountHistoryService;
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

    public BaseDto IsDiscountValid(string couponCode,User user)
    {
        var discount = _context.Discounts
            .Where(p => p.CouponCode.Equals(couponCode)).FirstOrDefault();

        if (discount == null)
        {
            return new BaseDto(IsSuccess: false,
                Message: new List<string> { "کد تخفیف معتبر نمی باشد" });
        }

        var now = DateTime.UtcNow;
        if (discount.StartDate.HasValue)
        {
            var startDate = DateTime.SpecifyKind(discount.StartDate.Value, DateTimeKind.Utc);
            if (startDate.CompareTo(now) > 0)
                return new BaseDto(false, new List<string>
                    { "هنوز زمان استفاده از این کد تخفیف فرا نرسیده است" });
        }
        if (discount.EndDate.HasValue)
        {
            var endDate = DateTime.SpecifyKind(discount.EndDate.Value, DateTimeKind.Utc);
            if (endDate.CompareTo(now) < 0)
                return new BaseDto(false, new List<string> { "کد تخفیف منقضی شده است" });
        }

        var checkLimit = CheckDiscountLimitations(discount, user);

        if (checkLimit.IsSuccess == false)
            return checkLimit;
        return new BaseDto(true, null);
    }
    private BaseDto CheckDiscountLimitations(Discount discount, User user)
    {
        switch (discount.DiscountLimitation)
        {
            case DiscountLimitationType.Unlimited:
            {
                return new BaseDto(true, null);
            }
            case DiscountLimitationType.NTimesOnly:
            {
                var totalUsage = _discountHistoryService.GetAllDiscountUsageHistory(discount.Id, null, 0, 1).Data.Count();
                if (totalUsage < discount.LimitationTimes)
                {
                    return new BaseDto(true, null);

                }
                else
                {
                    return new BaseDto(false, new List<string> { "ظرفیت استفاده از این کد تخفیف تکمیل شده است" });

                }
            }
            case DiscountLimitationType.NTimesPerCustomer:
            {
                if (user != null)
                {
                    var totalUsage = _discountHistoryService.GetAllDiscountUsageHistory(discount.Id, user.Id, 0, 1).Data.Count();
                    if (totalUsage < discount.LimitationTimes)
                    {
                        return new BaseDto(true, null);
                    }
                    else
                    {
                        return new BaseDto(false, new List<string> { "تعدادی که شما مجاز به استفاده از این تخفیف بوده اید به پایان رسیده است" });
                    }
                }
                else
                {
                    return new BaseDto(true, null);
                }
            }
            default:
                break;
        }
        return new BaseDto(true, null);

    }
}

public class CatalogItemDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}