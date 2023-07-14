using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Olympus.Concepts.Products.Core.Repository;
using Olympus.Concepts.Products.Core.UseCase;
using Olympus.Concepts.Products.Core.UseCase.Interfaces;
using Olympus.Concepts.Products.Infra.Database;
using Olympus.Concepts.Products.Infra.Repository;

namespace Olympus.Concepts.Products.Infra.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddAProductsProviders(this IServiceCollection services)
    {
        services.AddSingleton<IProductRepository, ProductRepository>();
        services.AddSingleton<ISearchAllProducts, SearchAllProducts>();

        var connString = Environment.GetEnvironmentVariable("OlympusDatabase");

        services.AddDbContext<ProductDbContext>(
        options =>
            options.UseSqlServer(
                connString,
                x => x.MigrationsAssembly("Olympus.Concepts.Products.Infra.Database")));

        return services;
    }
}
