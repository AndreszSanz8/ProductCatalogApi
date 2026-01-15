using Api_ProductCatalog.Domain.Entities;

namespace Api_ProductCatalog.Domain.Interfaces;

public interface IProductRepository
{
    Task<Product> AddAsync(Product product);
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);
    Task UpdateAsync(Product product);
    Task DeleteAsync(int id);
}
