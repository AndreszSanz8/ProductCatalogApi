using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api_ProductCatalog.Infrastructure.Context.Factories;

public class ProductCatalogContextFactory
    : IDesignTimeDbContextFactory<ProductCatalogContext>
{
    public ProductCatalogContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ProductCatalogContext>();

        optionsBuilder.UseSqlite("Data Source=productcatalog.db");

        return new ProductCatalogContext(optionsBuilder.Options);
    }
}
