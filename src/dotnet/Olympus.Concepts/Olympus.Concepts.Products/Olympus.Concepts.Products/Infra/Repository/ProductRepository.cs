using Microsoft.EntityFrameworkCore;
using Olympus.Concepts.Products.Core.Entity;
using Olympus.Concepts.Products.Core.Repository;
using Olympus.Concepts.Products.Infra.Database;

namespace Olympus.Concepts.Products.Infra.Repository;

internal sealed class ProductRepository : IProductRepository
{
    private readonly ProductDbContext _context;

    public ProductRepository(ProductDbContext context)
    {
        _context = context;
    }

    public Product GetProductById(Guid id)
    {
        return _context.Products.FirstOrDefault(i => i.Id == id);
    }

    public Task<List<Product>> GetAsync()
    {
        return _context.Products.ToListAsync();
    }

    public async Task InsertAsync(Product product)
    {
        await _context.Products.AddAsync(product);
    }

    public async Task DeleteAsync(Guid id)
    {
        var item = GetProductById(id);
        _context.Products.Remove(item);
        await SaveAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        _context.Update(product);
        await SaveAsync();
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}
