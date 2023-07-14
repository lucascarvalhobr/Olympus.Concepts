using Microsoft.EntityFrameworkCore;
using Olympus.Concepts.Products.Core.Entity;

namespace Olympus.Concepts.Products.Infra.Database;

internal sealed class ProductDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
    {

    }
}
