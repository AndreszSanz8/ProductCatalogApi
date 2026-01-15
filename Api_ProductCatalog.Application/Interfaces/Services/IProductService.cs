using Api_ProductCatalog.Application.Models.Requests;
using Api_ProductCatalog.Application.Models.Responses;
namespace Api_ProductCatalog.Application.Interfaces.Services;

public interface IProductService
{
    Task<ProductResponse> CreateAsync(CreateProductRequest request);
    Task<IEnumerable<ProductResponse>> GetAllAsync();
    Task<ProductResponse?> GetByIdAsync(int id);
    Task UpdateStockAsync(int id, int stock);
    Task DeleteAsync(int id);
}