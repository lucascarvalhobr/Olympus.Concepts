namespace Olympus.Concepts.Microservices.Abstractions;

internal sealed class Product : BaseEntity
{
    public string Name { get; set; }

    public string Description { get; set; }

    public string Price { get; set; }
}
