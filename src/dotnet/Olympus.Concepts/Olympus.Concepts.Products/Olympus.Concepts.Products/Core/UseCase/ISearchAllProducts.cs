using Olympus.Concepts.Products.Core.Entity.Products;

namespace Olympus.Concepts.Products.Core.UseCase;

public interface ISearchAllProducts
{
    Task<List<ProductResponse>> GetAllAsync();
}
