using Microsoft.EntityFrameworkCore;
using Olympus.Concepts.Products.Core.Entity.Products;
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

    public Task<Product> GetByIdAsync(Guid id)
    {
        return _context.Products.FirstOrDefaultAsync(i => i.Id == id);
    }

    public Task<List<Product>> GetAllAsync()
    {
        return _context.Products.ToListAsync();
    }

    public async Task AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);
    }

    public Task RemoveAsync(Product product)
    {
        _context.Products.Remove(product);

        return Task.CompletedTask;
    }

    public Task UpdateAsync(Product product)
    {
        _context.Update(product);

        return Task.CompletedTask;
    }
}
