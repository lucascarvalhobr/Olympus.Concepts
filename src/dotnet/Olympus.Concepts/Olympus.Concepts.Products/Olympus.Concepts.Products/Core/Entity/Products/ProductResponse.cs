namespace Olympus.Concepts.Products.Core.Entity.Products;

public sealed class ProductResponse
{
    public Guid Id { get; private set;  }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}
