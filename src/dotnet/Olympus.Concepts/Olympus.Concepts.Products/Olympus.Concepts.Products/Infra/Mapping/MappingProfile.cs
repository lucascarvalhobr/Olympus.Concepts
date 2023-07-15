namespace Olympus.Concepts.Products.Infra.Mapping;

using AutoMapper;
using Olympus.Concepts.Products.Core.Entity.Products;

internal class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductResponse>();
    }
}
