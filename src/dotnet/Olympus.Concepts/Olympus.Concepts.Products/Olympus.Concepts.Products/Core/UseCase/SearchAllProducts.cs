using AutoMapper;
using Olympus.Concepts.Products.Core.Entity.Products;
using Olympus.Concepts.Products.Infra;

namespace Olympus.Concepts.Products.Core.UseCase;

internal sealed class SearchAllProducts : ISearchAllProducts
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public SearchAllProducts(IUnitOfWork uow,
        IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<List<ProductResponse>> GetAllAsync()
    {
        var products = await _uow.Products.GetAllAsync();

        return _mapper.Map<List<Product>, List<ProductResponse>>(products);
    }
}
