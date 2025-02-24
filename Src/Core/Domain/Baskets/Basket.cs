using Domain.Attributes;
using Domain.Catalogs;

namespace Domain.Baskets;

[Auditable]
public class Basket
{
    public int Id { get; set; }
    public string BuyerId { get; private set; }

    private readonly List<BasketItem> _items = new List<BasketItem>();
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