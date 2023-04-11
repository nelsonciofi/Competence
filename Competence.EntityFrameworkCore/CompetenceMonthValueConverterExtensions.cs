using Microsoft.EntityFrameworkCore;

namespace Competence.EntityFrameworkCore;

public static class CompetenceMonthValueConverterExtensions
{
    public static ModelConfigurationBuilder AddDefaultMonthCompetenceConverter(this ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<CompetenceMonth>().HaveConversion<CompetenceMonthValueConverterAsMonthCount>();
        return configurationBuilder;
    }

}