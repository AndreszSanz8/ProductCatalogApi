using Api_ProductCatalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api_ProductCatalog.Infrastructure.Context;

public class ProductCatalogContext : DbContext
{
    public ProductCatalogContext(DbContextOptions<ProductCatalogContext> options)
        : base(options) { }

    public DbSet<Product> Products => Set<Product>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Id)
                  .ValueGeneratedOnAdd();
            entity.Property(p => p.Price)
              .HasPrecision(18, 2);
        });
    }
}
