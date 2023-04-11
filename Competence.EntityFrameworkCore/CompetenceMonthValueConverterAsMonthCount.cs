using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Competence.EntityFrameworkCore;

public class CompetenceMonthValueConverterAsMonthCount : ValueConverter<CompetenceMonth, int>
{
    public CompetenceMonthValueConverterAsMonthCount() : base(
        v => v.ToMonthCount(),
        v => new CompetenceMonth(v))
    { }
}
