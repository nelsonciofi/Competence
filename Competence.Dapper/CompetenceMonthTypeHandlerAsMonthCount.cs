using Dapper;
using System.Data;

namespace Competence.Dapper;
    
public class CompetenceMonthTypeHandlerAsMonthCount : SqlMapper.TypeHandler<CompetenceMonth>
{
    public override CompetenceMonth Parse(object value)
    {
        if (value is int v)
        {
            return new CompetenceMonth(v);
        }

        return new CompetenceMonth();
    }

    public override void SetValue(IDbDataParameter parameter, CompetenceMonth value)
    {
        parameter.Value = value.ToMonthCount();
    }  
}
