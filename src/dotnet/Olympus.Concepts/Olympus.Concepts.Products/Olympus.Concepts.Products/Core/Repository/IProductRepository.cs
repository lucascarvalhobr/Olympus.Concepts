using Olympus.Concepts.Products.Core.Entity;

namespace Olympus.Concepts.Products.Core.Repository;

internal interface IProductRepository
{
    Product GetProductById(Guid id);

    Task<List<Product>> GetAsync();

    Task InsertAsync(Product product);

    Task DeleteAsync(Guid id);

    Task UpdateAsync(Product product);

    Task SaveAsync();
}

