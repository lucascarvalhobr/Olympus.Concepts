using System.Data;

namespace Olympus.Concepts.UnitOfWork.Sql.Abstractions;

public class SqlParameter
{
    public string Name { get; set; }
    public object Value { get; set; }
    public ParameterType Type { get; set; }
    public ParameterDirection Direction { get; set; }
    public string TypeName { get; set; }
    public int Size { get; set; }

    public SqlParameter()
    {
    }

    public SqlParameter(string pmName, ParameterType pmType, object pmValue, int pmSize = 0, string pmTypeName = "")
    {
        Name = pmName;
        Type = pmType;
        Value = pmValue;
        TypeName = pmTypeName;
        Direction = ParameterDirection.Input;
        Size = pmSize;
    }
}
