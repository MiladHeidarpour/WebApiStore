using Domain.Baskets;
using Domain.Catalogs;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces.Contexts;

public interface IDataBaseContext
{
    public DbSet<CatalogBrand> CatalogBrands { get; set; }
    public DbSet<CatalogType> CatalogTypes { get; set; }
    public DbSet<CatalogItem> CatalogItems { get; set; }
    public DbSet<Basket> Baskets { get; set; }
    public DbSet<BasketItem> BasketItems { get; set; }
    int SaveChanges();
    int SaveChanges(bool acceptAllChangesOnSuccess);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
}