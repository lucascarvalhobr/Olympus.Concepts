using Olympus.Concepts.Products.Core.Entity.Products;

namespace Olympus.Concepts.Products.Core.Repository;

internal interface IProductRepository
{
    Task<Product> GetByIdAsync(Guid id);

    Task<List<Product>> GetAllAsync();

    Task AddAsync(Product product);

    Task RemoveAsync(Product product);

    Task UpdateAsync(Product product);
}

