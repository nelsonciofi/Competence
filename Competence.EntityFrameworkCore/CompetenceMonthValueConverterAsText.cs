using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Competence.EntityFrameworkCore;

public class CompetenceMonthValueConverterAsText : ValueConverter<CompetenceMonth, string>
{
    public CompetenceMonthValueConverterAsText() : base(
        v => v.ToCompetenceText(),
        v => new CompetenceMonth(v))
    { }
}