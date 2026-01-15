using Api_ProductCatalog.Application.Interfaces.Services;
using Api_ProductCatalog.Application.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
        services.AddValidatorsFromAssembly(
          typeof(DependencyInjection).Assembly);
        return services;

    }
}