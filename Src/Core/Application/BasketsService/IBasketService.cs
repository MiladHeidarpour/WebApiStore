﻿using Application.Dtos;

namespace Application.BasketsService;

public interface IBasketService
{
    BasketDto GetOrCreateBasketForUser(string BuyerId);
    void AddItemToBasket(int basketId, int catalogItemId, int quantity = 1);
    bool RemoveItemFromBasket(int itemId);
    bool SetQuantities(int itemId, int quantity);
    BasketDto GetBasketForUser(string userId);
    void TransferBasket(string anonymousId, string userId);
}

public class BasketDto
{
    public int Id { get; set; }
    public string BuyerId { get; set; }
    public List<BasketItemDto> Items { get; set; } = new List<BasketItemDto>();
    public int DiscountAmount { get; set; }
    public int Total()
    {
        if (Items.Count > 0)
        {
            int total = Items.Sum(p => p.UnitPrice * p.Quantity);
            total -= DiscountAmount;
            return total;
        }
        return 0;
    }
    public int TotalWithOutDiescount()
    {
        if (Items.Count > 0)
        {
            int total = Items.Sum(p => p.UnitPrice * p.Quantity);
            return total;
        }
        return 0;
    }

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