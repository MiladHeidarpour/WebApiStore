using Domain.Baskets;
using Domain.Catalogs;
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
    int SaveChanges();
    int SaveChanges(bool acceptAllChangesOnSuccess);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
}