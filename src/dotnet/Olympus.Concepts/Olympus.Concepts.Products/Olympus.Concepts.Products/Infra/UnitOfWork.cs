using Olympus.Concepts.Products.Core.Repository;
using Olympus.Concepts.Products.Infra.Database;
using Olympus.Concepts.Products.Infra.Repository;

namespace Olympus.Concepts.Products.Infra;

internal class UnitOfWork : IUnitOfWork
{
    private bool _disposed;

    private readonly ProductDbContext _productDbContext;

    private readonly ProductRepository _productRepository;
    public IProductRepository Products => _productRepository ?? new ProductRepository(_productDbContext);

    public UnitOfWork(ProductDbContext productDbContext)
    {
        _productDbContext = productDbContext ?? throw new ArgumentNullException(nameof(productDbContext));
    }

    public async Task CompleteAsync() => await _productDbContext.SaveChangesAsync();

    public async ValueTask DisposeAsync()
    {
        await DisposeAsync(true);

        // Take this object off the finalization queue to prevent 
        // finalization code for this object from executing a second time.
        GC.SuppressFinalize(this);
    }

    protected virtual async ValueTask DisposeAsync(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                // Dispose managed resources.
                await _productDbContext.DisposeAsync();
            }

            // Dispose any unmanaged resources here...
            _disposed = true;
        }
    }
}
