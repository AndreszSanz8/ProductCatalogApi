using Api_ProductCatalog.Application.Interfaces.Services;
using Api_ProductCatalog.Application.Models.Requests;
using Api_ProductCatalog.Application.Models.Responses;
using Api_ProductCatalog.Domain.Entities;
using Api_ProductCatalog.Domain.Interfaces;

namespace Api_ProductCatalog.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repo;

    public ProductService(IProductRepository repo)
    {
        _repo = repo;
    }

    public async Task<ProductResponse> CreateAsync(CreateProductRequest request)
    {
        var product = new Product
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            Stock = request.Stock
        };

        await _repo.AddAsync(product);

        return new ProductResponse(
            product.Id,
            product.Name,
            product.Description,
            product.Price,
            product.Stock);
    }

    public async Task<IEnumerable<ProductResponse>> GetAllAsync()
    {
        var products = await _repo.GetAllAsync();
        return products.Select(p =>
            new ProductResponse(p.Id, p.Name, p.Description, p.Price, p.Stock));
    }

    public async Task<ProductResponse?> GetByIdAsync(int id)
    {
        var product = await _repo.GetByIdAsync(id);
        if (product == null) return null;

        return new ProductResponse(
            product.Id,
            product.Name,
            product.Description,
            product.Price,
            product.Stock);
    }

    public async Task UpdateStockAsync(int id, int stock)
    {
        var product = await _repo.GetByIdAsync(id)
            ?? throw new Exception("Producto no encontrado");

        product.Stock = stock;
        await _repo.UpdateAsync(product);
    }

    public async Task DeleteAsync(int id)
    {
        await _repo.DeleteAsync(id);
    }
}