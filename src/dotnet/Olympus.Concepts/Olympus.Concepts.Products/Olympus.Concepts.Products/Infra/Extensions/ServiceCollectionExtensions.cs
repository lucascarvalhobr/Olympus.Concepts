using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;

using Olympus.Concepts.Products.Core.Repository;
using Olympus.Concepts.Products.Core.UseCase;
using Olympus.Concepts.Products.Infra.Database;
using Olympus.Concepts.Products.Infra.Repository;
using Olympus.Concepts.Products.Infra.Mapping;

namespace Olympus.Concepts.Products.Infra.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddAProductsProviders(this IServiceCollection services)
    {
        AddDbContext(services);

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ISearchAllProducts, SearchAllProducts>();

        AddMappingProfile(services);

        return services;
    }

    private static void AddDbContext(IServiceCollection services)
    {
        var connString = Environment.GetEnvironmentVariable("OlympusDatabase");

        services.AddDbContext<ProductDbContext>(
        options =>
            options.UseSqlServer(
                connString,
                x => x.MigrationsAssembly("Olympus.Concepts.Products.Infra.Database")));
    }

    private static void AddMappingProfile(IServiceCollection services)
    {
        var mappingConfig = new MapperConfiguration(config =>
        {
            config.AddProfile(new MappingProfile());
        });

        IMapper mapper = mappingConfig.CreateMapper();

        services.AddSingleton(mapper);
    }
}
