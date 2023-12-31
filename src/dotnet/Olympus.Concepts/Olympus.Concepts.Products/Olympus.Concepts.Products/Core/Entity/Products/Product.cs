﻿namespace Olympus.Concepts.Products.Core.Entity.Products;

internal sealed class Product
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
}
