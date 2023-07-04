namespace Olympus.Concepts.UnitOfWork.Abstractions;

public interface IExecutorFactory : IDisposable
{
    void Register(Type t, IExecutor executor);

    IExecutor Resolve(IUnitOfWork obj);

    void Commit();

    void RollBack();

    void BeginTransaction();

    bool IsRolledBack();
}
