using Olympus.Concepts.Products.Core.Entity;

namespace Olympus.Concepts.Products.Core.UseCase.Interfaces;

public interface ISearchAllProducts
{
    Task<List<Product>> GetAsync();
}
