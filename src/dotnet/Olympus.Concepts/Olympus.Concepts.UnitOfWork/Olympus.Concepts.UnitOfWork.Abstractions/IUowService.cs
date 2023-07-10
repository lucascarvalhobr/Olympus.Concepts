namespace Olympus.Concepts.UnitOfWork.Abstractions;

public interface IUowService
{
    ValueTask<IExecutorFactory> GetDefaultFactoryAsync(bool transactional, CancellationToken cancellationToken = default);
}
