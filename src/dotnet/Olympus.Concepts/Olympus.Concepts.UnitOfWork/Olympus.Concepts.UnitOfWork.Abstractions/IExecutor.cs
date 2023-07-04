namespace Olympus.Concepts.UnitOfWork.Abstractions;

public interface IExecutor
{
    void Execute(IUnitOfWork uow, ResultSet resultSet);

    void Execute(IUnitOfWork uow, ResultSet resultSet, int timeout);

    List<UnitOfWorkLog> Logs { get; }
}
