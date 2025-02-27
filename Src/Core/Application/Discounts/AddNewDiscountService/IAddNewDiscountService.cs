using System.ComponentModel.DataAnnotations;
using Application.Interfaces.Contexts;
using Domain.Discounts;

namespace Application.Discounts.AddNewDiscountService;

public interface IAddNewDiscountService
{
    void Execute(AddNewDiscountDto model);
}


public class AddNewDiscountService : IAddNewDiscountService
{
    private readonly IDataBaseContext _context;

    public AddNewDiscountService(IDataBaseContext context)
    {
        _context = context;
    }

    public void Execute(AddNewDiscountDto discount)
    {
        var newDiscount = new Discount()
        {
            Name = discount.Name,
            CouponCode = discount.CouponCode,
            DiscountAmount = discount.DiscountAmount,
            DiscountLimitationId = discount.DiscountLimitationId,
            DiscountPercentage = discount.DiscountPercentage,
            DiscountTypeId = discount.DiscountTypeId,
            EndDate = discount.EndDate,
            RequiresCouponCode = discount.RequiresCouponCode,
            StartDate = discount.StartDate,
            UsePercentage = discount.UsePercentage,
        };

        if (discount.appliedToCatalogItem != null)
        {
            var catalogItems = _context.CatalogItems.Where(p => discount.appliedToCatalogItem.Contains(p.Id)).ToList();
            newDiscount.CatalogItems = catalogItems;
        }

        _context.Discounts.Add(newDiscount);
        _context.SaveChanges();
    }
}

public class AddNewDiscountDto
{
    [Display(Name = "نام تخفیف")]
    public string Name { get; set; }
    [Display(Name = "استفاده از درصد؟")]
    public bool UsePercentage { get; set; } = true;
    [Display(Name = "درصد تخفیف")]
    public int DiscountPercentage { get; set; } = 0;
    [Display(Name = "مبلغ تخفیف")]
    public int DiscountAmount { get; set; } = 0;
    [Display(Name = "زمان شروع")]
    public DateTime? StartDate { get; set; }
    [Display(Name = "زمان انقضا")]
    public DateTime? EndDate { get; set; }
    [Display(Name = "استفاده از کوپن")]
    public bool RequiresCouponCode { get; set; }
    [Display(Name = "کد کوپن")]
    public string CouponCode { get; set; }
    [Display(Name = "نوع تخفیف")]
    public int DiscountTypeId { get; set; }
    [Display(Name = "محدودیت تخفیف")]
    public int DiscountLimitationId { get; set; }

    [Display(Name = "تعداد کد تخفیف")]
    public int LimitationTimes { get; set; } = 0;
    [Display(Name = "اعمال برای محصول")]
    public List<int> appliedToCatalogItem { get; set; }
}