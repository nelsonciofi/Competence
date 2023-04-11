namespace Competence;

public static class CompetenceMonthExtensions
{

    public static IEnumerable<string> CompetenceTextRangeTo(this CompetenceMonth cmFrom, CompetenceMonth cmTo)
    {
        if (cmFrom > cmTo)
        {
            (cmTo, cmFrom) = (cmFrom, cmTo);
        }

        while (cmFrom <= cmTo)
        {
            yield return cmFrom.ToCompetenceText();
            cmFrom = cmFrom.AddMonths(1);
        }
    }
    
    
    public static (DateTime, DateTime) DateTimeRangeTo(this CompetenceMonth cmFrom, CompetenceMonth cmTo)
    {
        if (cmFrom > cmTo)
        {
            (cmTo, cmFrom) = (cmFrom, cmTo);
        }

        DateTime fromDate = cmFrom;
        DateTime toDate = cmTo;
        
        toDate = toDate.AddMonths(1).AddDays(-1);

        return (fromDate, toDate);
    }

    public static (int, int) MonthCountRangeTo(this CompetenceMonth cmFrom, CompetenceMonth cmTo)
    {
        if (cmFrom > cmTo)
        {
            (cmTo, cmFrom) = (cmFrom, cmTo);
        }

        int fromDate = cmFrom;
        int toDate = cmTo;        

        return (fromDate, toDate);
    }
}
