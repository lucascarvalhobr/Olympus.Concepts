namespace Olympus.Concepts.UnitOfWork.Sql.Abstractions
{
    public interface INonQueryWork
    {
        void Execute(int returnValue, SqlParameters parameters);
    }
}
