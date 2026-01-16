using Api_ProductCatalog.Domain.Interfaces;
using Api_ProductCatalog.Infrastructure.Context;
using Api_ProductCatalog.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ProductCatalogContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("Default")));

        services.AddScoped<IProductRepository, ProductRepository>();
        return services;
    }
}