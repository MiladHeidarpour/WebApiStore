using Application.Interfaces.Contexts;
using Domain.Attributes;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using System;
using Domain.Baskets;
using Domain.Catalogs;
using Domain.Discounts;
using Domain.Orders;
using Persistence.EntityConfigurations;
using Persistence.Seeds;
using Domain.Payments;

namespace Persistence.Contexts;

public class DatabaseContext : DbContext, IDataBaseContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {

    }


    public DbSet<CatalogBrand> CatalogBrands { get; set; }
    public DbSet<CatalogType> CatalogTypes { get; set; }
    public DbSet<CatalogItem> CatalogItems { get; set; }
    public DbSet<Basket> Baskets { get; set; }
    public DbSet<BasketItem> BasketItems { get; set; }
    public DbSet<UserAddress> UserAddresses { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Discount> Discounts { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<User>().Property<DateTime?>("InsertTime");
        //modelBuilder.Entity<User>().Property<DateTime?>("UpdateTime");

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (entityType.ClrType.GetCustomAttributes(typeof(AuditableAttribute), true).Length > 0)
            {
                modelBuilder.Entity(entityType.Name).Property<DateTime>("InsertTime").HasDefaultValue(DateTime.Now);
                modelBuilder.Entity(entityType.Name).Property<DateTime?>("UpdateTime");
                modelBuilder.Entity(entityType.Name).Property<DateTime?>("RemoveTime");
                modelBuilder.Entity(entityType.Name).Property<bool>("IsRemoved").HasDefaultValue(false);
            }
        }
        modelBuilder.Entity<CatalogType>()
            .HasQueryFilter(m => EF.Property<bool>(m, "IsRemoved") == false);

        modelBuilder.Entity<Basket>()
            .HasQueryFilter(m => EF.Property<bool>(m, "IsRemoved") == false);

        modelBuilder.Entity<BasketItem>()
            .HasQueryFilter(m => EF.Property<bool>(m, "IsRemoved") == false);

        modelBuilder.ApplyConfiguration(new CatalogBrandEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new CatalogTypeEntityTypeConfiguration());

        DatabaseContextSeed.CatalogSeed(modelBuilder);

        modelBuilder.Entity<Order>().OwnsOne(p => p.Address);
        
        base.OnModelCreating(modelBuilder);
    }

    public override int SaveChanges()
    {
        var modifiedEntries = ChangeTracker.Entries()
            .Where(p => p.State == EntityState.Modified ||
                        p.State == EntityState.Added ||
                        p.State == EntityState.Deleted);

        foreach (var item in modifiedEntries)
        {
            var entityType = item.Context.Model.FindEntityType(item.Entity.GetType());

            var inserted = entityType.FindProperty("InsertTime");
            var updated = entityType.FindProperty("UpdateTime");
            var removed = entityType.FindProperty("RemoveTime");
            var isRemoved = entityType.FindProperty("IsRemoved");

            if (item.State == EntityState.Added && inserted != null)
            {
                item.Property("InsertTime").CurrentValue = DateTime.Now;
            }

            if (item.State == EntityState.Modified && updated != null)
            {
                item.Property("UpdateTime").CurrentValue = DateTime.Now;
            }

            if (item.State == EntityState.Deleted && removed != null && isRemoved != null)
            {
                item.Property("RemoveTime").CurrentValue = DateTime.Now;
                item.Property("IsRemoved").CurrentValue = true;
                item.State = EntityState.Modified;
            }
        }
        return base.SaveChanges();
    }
}