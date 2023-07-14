using Olympus.Concepts.Products.Core.Entity;
using Olympus.Concepts.Products.Core.Repository;
using Olympus.Concepts.Products.Core.UseCase.Interfaces;

namespace Olympus.Concepts.Products.Core.UseCase;

internal sealed class SearchAllProducts : ISearchAllProducts
{
    private readonly IProductRepository _productRepository;

    public SearchAllProducts(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public Task<List<Product>> GetAsync()
    {
        return _productRepository.GetAsync();
    }
}
