namespace Olympus.Concepts.UnitOfWork.Abstractions;

public class ResultSet : List<IResult>
{
    public bool Break { get; set; } = false;

    public void Add(object obj)
    {
        base.Add(!(obj is IResult) ? new ResultBase { Result = obj } : (IResult)obj);
    }
}
