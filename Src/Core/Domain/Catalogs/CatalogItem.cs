using Domain.Attributes;
using Domain.Discounts;
using Domain.Orders;

namespace Domain.Catalogs;

[Auditable]
public class CatalogItem
{
    private int _Price = 0;
    private int? _OldPrice=null;

    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }


    public int Price
    {
        get => GetPrice();
        set => _Price = value; // مقدار را روی _Price تنظیم کنید
    }

    public int? OldPrice
    {
        get => _OldPrice;
        set => _OldPrice = value; // مقدار را روی _OldPrice تنظیم کنید
    }
    //public int Price
    //{
    //    get
    //    {
    //        return GetPrice();
    //    }
    //    set
    //    {
    //        Price = _Price;
    //    }
    //}

    //public int? OldPrice
    //{
    //    get
    //    {
    //        return _OldPrice;
    //    }
    //    set
    //    {
    //        OldPrice=_OldPrice;
    //    }
    //}

    public int? PercentDiscount { get; set; }


    public int CatalogTypeId { get; set; }
    public CatalogType CatalogType { get; set; }
    public int CatalogBrandId { get; set; }
    public CatalogBrand CatalogBrand { get; set; }
    public int AvailableStock { get; set; }
    public int RestockThreshold { get; set; }
    public int MaxStockThreshold { get; set; }
    public int VisitCount { get; set; }
    public string Slug { get; set; }
    public ICollection<CatalogItemFeature> CatalogItemFeatures { get; set; }
    public ICollection<CatalogItemImage> CatalogItemImages { get; set; }
    public ICollection<Discount> Discounts { get; set; }
    public ICollection<CatalogItemFavorite> CatalogItemFavorites { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; }


    private int GetPrice()
    {
        var dis = GetPreferredDiscount(Discounts, _Price);
        if (dis != null)
        {
            var discountAmount = dis.GetDiscountAmount(_Price);
            int newPrice = _Price - discountAmount;
            _OldPrice = _Price;
            PercentDiscount = (discountAmount * 100) / _Price;
            return newPrice;
        }

        return _Price;

    }

    /// <summary>
    /// دریافت بیشترین تخفیف
    /// </summary>
    /// <param name="discounts"></param>
    /// <param name="price"></param>
    /// <returns></returns>
    private Discount GetPreferredDiscount(ICollection<Discount> discounts, int price)
    {
        Discount preferredDiscount = null;
        decimal? maximumDiscountValue = null;
        if (discounts != null)
        {
            foreach (var discount in discounts)
            {
                var currentDiscountValue = discount.GetDiscountAmount(price);
                if (currentDiscountValue != decimal.Zero)
                {
                    if (!maximumDiscountValue.HasValue || currentDiscountValue > maximumDiscountValue)
                    {
                        maximumDiscountValue = currentDiscountValue;
                        preferredDiscount = discount;
                    }
                }
            }
        }

        return preferredDiscount;
    }
}