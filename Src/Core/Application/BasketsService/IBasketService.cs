using Application.Dtos;

namespace Application.BasketsService;

public interface IBasketService
{
    BasketDto GetOrCreateBasketForUser(string BuyerId);
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