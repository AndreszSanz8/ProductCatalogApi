using Api_ProductCatalog.Domain.Entities;
using Api_ProductCatalog.Domain.Interfaces;
using Api_ProductCatalog.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Api_ProductCatalog.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ProductCatalogContext _context;

    public ProductRepository(ProductCatalogContext context)
    {
        _context = context;
    }

    public async Task<Product> AddAsync(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<IEnumerable<Product>> GetAllAsync() =>
        await _context.Products
            .Where(p => p.IsActive)
            .ToListAsync();

    public async Task<Product?> GetByIdAsync(int id) =>
        await _context.Products
            .FirstOrDefaultAsync(p => p.Id == id && p.IsActive);

    public async Task UpdateAsync(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product != null)
        {
            product.IsActive = false;
            await _context.SaveChangesAsync();
        }
    }
}