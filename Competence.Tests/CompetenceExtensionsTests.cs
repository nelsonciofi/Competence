namespace Competence.Tests;

public class CompetenceExtensionsTests
{
    [Theory]
    [InlineData("05/2022", "05/2022", new string[] { "05/2022" })]
    [InlineData("05/2022", "07/2022", new string[] { "05/2022", "06/2022", "07/2022" })]
    [InlineData("12/2022", "02/2023", new string[] { "12/2022", "01/2023", "02/2023" })]
    public void Should_CreateCompetenceTextRange(string cmFrom, string cmTo, string[] expected)
    {
        // Arrange
        var from = new CompetenceMonth(cmFrom);
        var to = new CompetenceMonth(cmTo);

        // Act
        var result = from.CompetenceTextRangeTo(to);

        // Assert
        Assert.Equal(expected, result);
    }


    [Theory]
    [InlineData(2022, 3, 2023, 5)]
    [InlineData(2022, 12, 2023, 1)]
    [InlineData(2023, 1, 2023, 1)]
    public void Should_CreateDataTimeRange(int fromYear, int fromMonth, int toYear, int toMonth)
    {
        // Arrange
        var cmFrom = new CompetenceMonth(fromMonth, fromYear);
        var cmTo = new CompetenceMonth(toMonth, toYear);

        // Act
        var (dtFrom, dtTo) = cmFrom.DateTimeRangeTo(cmTo);

        // Assert
        var expectedDtFrom = new DateTime(fromYear, fromMonth, 1);
        var expectedDtTo = new DateTime(toYear, toMonth, DateTime.DaysInMonth(toYear, toMonth));

        Assert.Equal(expectedDtFrom, dtFrom);
        Assert.Equal(expectedDtTo, dtTo);
    }


    [Theory]
    [InlineData(2023, 4, 2023, 4, 24280, 24280)]
    [InlineData(2023, 4, 2023, 5, 24280, 24281)]
    [InlineData(2022, 11, 2023, 2,24275, 24278)]
    public void Should_CreateMonthCountRange(int fromYear, int fromMonth, int toYear, int toMonth, int expectedMonthCountFrom, int expectedMonthCountTo)
    {
        // Arrange
        var cmFrom = new CompetenceMonth(fromMonth, fromYear);
        var cmTo = new CompetenceMonth(toMonth, toYear);

        // Act
        var result = cmFrom.MonthCountRangeTo(cmTo);

        // Assert
        var expected = (expectedMonthCountFrom, expectedMonthCountTo);
        Assert.Equal(expected, result);
    }
}
