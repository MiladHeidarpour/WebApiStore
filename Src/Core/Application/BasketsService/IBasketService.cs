using Application.Dtos;

namespace Application.BasketsService;

public interface IBasketService
{
    BasketDto GetOrCreateBasketForUser(string BuyerId);
    void AddItemToBasket(int basketId, int catalogItemId, int quantity = 1);
    bool RemoveItemFromBasket(int itemId);
    bool SetQuantities(int itemId, int quantity);
}

public class BasketDto
{
    public int Id { get; set; }
    public string BuyerId { get; set; }
    public List<BasketItemDto> Items { get; set; } = new List<BasketItemDto>();

}

public class BasketItemDto
{
    public int Id { get; set; }
    public int CatalogItemId { get; set; }
    public string CatalogName { get; set; }
    public int UnitPrice { get; set; }
    public int Quantity { get; set; }
    public string ImageUrl { get; set; }
}