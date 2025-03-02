using Domain.Attributes;
using Domain.Catalogs;
using Domain.Discounts;

namespace Domain.Baskets;

[Auditable]
public class Basket
{
    public int Id { get; set; }
    public string BuyerId { get; private set; }

    private readonly List<BasketItem> _items = new List<BasketItem>();

    public int DiscountAmount { get;private set; } = 0;
    public Discount AppliedDiscount { get; private set; }
    public int? AppliedDiscountId { get;private set; }
    public ICollection<BasketItem> Items => _items.AsReadOnly();
    public Basket(string buyerId)
    {
        BuyerId = buyerId;
    }

    public void AddItem(int catalogItemId, int quantity, int unitPrice)
    {
        if (!Items.Any(p => p.CatalogItemId == catalogItemId))
        {
            _items.Add(new BasketItem(catalogItemId, quantity, unitPrice));
            return;
        }
        var existingItem = Items.FirstOrDefault(p => p.CatalogItemId == catalogItemId);
        existingItem.AddQuantity(quantity);
    }

    public int TotalPrice()
    {
        int totalPrice = _items.Sum(p => p.UnitPrice * p.Quantity);
        totalPrice -= AppliedDiscount.GetDiscountAmount(totalPrice);
        return totalPrice;
    }

    public int TotalPriceWithOutDiescount()
    {
        int totalPrice = _items.Sum(p => p.UnitPrice * p.Quantity);
        return totalPrice;
    }
    public void ApplyDiscountCode(Discount discount)
    {
        AppliedDiscount = discount;
        AppliedDiscountId = discount.Id;
        DiscountAmount = discount.GetDiscountAmount(TotalPriceWithOutDiescount());
    }
    public void RemoveDescount()
    {
        AppliedDiscount = null;
        AppliedDiscountId = null;
        DiscountAmount = 0;
    }
}
[Auditable]
public class BasketItem
{
    public int Id { get; set; }
    public int UnitPrice { get; private set; }
    public int Quantity { get; private set; }
    public int CatalogItemId { get; private set; }
    public CatalogItem CatalogItem { get; private set; }
    public int BasketId { get; private set; }

    public BasketItem(int catalogItemId, int quantity, int unitPrice)
    {
        CatalogItemId = catalogItemId;
        UnitPrice = unitPrice;
        SetQuantity(quantity);
    }

    public void AddQuantity(int quantity)
    {
        Quantity += quantity;
    }

    public void SetQuantity(int quantity)
    {
        Quantity = quantity;
    }
}