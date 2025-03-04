using Domain.Baskets;
using Domain.Catalogs;
using Domain.Discounts;
using Domain.Orders;
using Domain.Payments;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces.Contexts;

public interface IDataBaseContext
{
    DbSet<CatalogBrand> CatalogBrands { get; set; }
    DbSet<CatalogType> CatalogTypes { get; set; }
    DbSet<CatalogItem> CatalogItems { get; set; }
    DbSet<Basket> Baskets { get; set; }
    DbSet<BasketItem> BasketItems { get; set; }
    DbSet<UserAddress> UserAddresses { get; set; }
    DbSet<Order> Orders { get; set; }
    DbSet<OrderItem> OrderItems { get; set; }
    DbSet<Payment> Payments { get; set; }
    DbSet<Discount> Discounts { get; set; }
    DbSet<DiscountUsageHistory> DiscountUsageHistories { get; set; }
    DbSet<CatalogItemFavorite> CatalogItemFavorites { get; set; }
    int SaveChanges();
    int SaveChanges(bool acceptAllChangesOnSuccess);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
}