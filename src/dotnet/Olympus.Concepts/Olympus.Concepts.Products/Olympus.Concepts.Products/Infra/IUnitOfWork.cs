using Olympus.Concepts.Products.Core.Repository;

namespace Olympus.Concepts.Products.Infra;

internal interface IUnitOfWork : IAsyncDisposable
{
    IProductRepository Products { get; }
    Task CompleteAsync();
}
