namespace Competence.Tests;

public class CompetenceTests
{
    [Fact]
    public void Should_ConstructCompetenceFromYearAndMonth()
    {
        // Arrange
        int year = 2023;
        int month = 4;

        // Act
        CompetenceMonth competenceMonth = new(month, year);

        // Assert
        Assert.Equal(year, competenceMonth.Year);
        Assert.Equal(month, competenceMonth.Month);
    }

    [Fact]
    public void Should_ConstructCompetenceFromMonthCount()
    {
        // Arrange
        int monthCount = 25;

        // Act
        CompetenceMonth competenceMonth = new(monthCount);

        // Assert
        Assert.Equal(2, competenceMonth.Year);
        Assert.Equal(1, competenceMonth.Month);
    }

    [Fact]
    public void Should_ConvertToMonthCount()
    {
        // Arrange
        CompetenceMonth competenceMonth = new(4, 2023);

        // Act
        int monthCount = competenceMonth.ToMonthCount();

        // Assert
        Assert.Equal(24280, monthCount);
    }

    [Fact]
    public void Should_ConvertToDateTimeUsingOneAsDay()
    {
        // Arrange
        CompetenceMonth competenceMonth = new(4, 2023);

        // Act
        DateTime dateTime = competenceMonth.ToDateTime();

        // Assert
        Assert.Equal(new DateTime(2023, 4, 1), dateTime);
    }


    [Fact]
    public void Should_ConvertToCompetenceTextIn_MMyyyy_Format()
    {
        // Arrange
        CompetenceMonth competenceMonth = new(4, 2023);

        // Act
        string competenceText = competenceMonth.ToCompetenceText();

        // Assert
        Assert.Equal("04/2023", competenceText);
    }



    [Theory]
    [InlineData(2023, 1, 2024, 4)]
    [InlineData(2023, -1, 2022, 4)]
    [InlineData(2023, 3, 2026, 4)]
    [InlineData(2023, -3, 2020, 4)]
    public void Should_AddYearsWithoutChangingMonths(int initialYear, int yearsToAdd, int expectedYear, int expectedMonth)
    {
        // Arrange
        CompetenceMonth competenceMonth = new(4, initialYear);

        // Act
        CompetenceMonth newCompetenceMonth = competenceMonth.AddYears(yearsToAdd);

        // Assert
        Assert.Equal(expectedYear, newCompetenceMonth.Year);
        Assert.Equal(expectedMonth, newCompetenceMonth.Month);
    }


    [Theory]
    [InlineData(1, 2023, 5)]
    [InlineData(-1, 2023, 3)]
    [InlineData(12, 2024, 4)]
    [InlineData(-12, 2022, 4)]
    [InlineData(5, 2023, 9)]
    [InlineData(-5, 2022, 11)]
    public void Should_AddMonths(int monthsToAdd, int expectedYear, int expectedMonth)
    {
        // Arrange
        CompetenceMonth competenceMonth = new(4, 2023);

        // Act
        CompetenceMonth newCompetenceMonth = competenceMonth.AddMonths(monthsToAdd);

        // Assert
        Assert.Equal(expectedYear, newCompetenceMonth.Year);
        Assert.Equal(expectedMonth, newCompetenceMonth.Month);
    }

    [Fact]
    public void Should_BeEqualityByValues()
    {
        // Arrange
        CompetenceMonth competenceMonth1 = new(4, 2023);
        CompetenceMonth competenceMonth2 = new(4, 2023);
        CompetenceMonth competenceMonth3 = new(4, 2024);

        // Assert
        Assert.Equal(competenceMonth1, competenceMonth2);
        Assert.NotEqual(competenceMonth1, competenceMonth3);
    }

    [Fact]
    public void Should_ConstructWithPositiveYearAndMonth_Successful()
    {
        // Arrange
        int year = 2023;
        int month = 4;

        // Act
        var competenceMonth = new CompetenceMonth(month, year);

        // Assert
        Assert.Equal(year, competenceMonth.Year);
        Assert.Equal(month, competenceMonth.Month);
    }

    [Theory]
    [InlineData("04/2023", 4, 2023)]
    [InlineData("2023/04", 4, 2023)]
    [InlineData("12/23", 12, 23)]
    [InlineData("04-2023", 4, 2023)]
    [InlineData("2023-04", 4, 2023)]
    [InlineData("12-23", 12, 23)]
    public void Should_ConstructFromText(string txt, int expectedMonth, int expectedYear)
    {
        // Act
        var competence = new CompetenceMonth(txt);

        // Assert
        Assert.Equal(expectedMonth, competence.Month);
        Assert.Equal(expectedYear, competence.Year);
    }

    [Theory]
    [InlineData("", typeof(ArgumentNullException))]
    [InlineData(null, typeof(ArgumentNullException))]
    [InlineData("042023", typeof(ArgumentException))]
    [InlineData("abc-abc", typeof(ArgumentException))]
    [InlineData("abcd-ac", typeof(InvalidOperationException))]
    [InlineData("ab/aghc", typeof(InvalidOperationException))]
    [InlineData("202304", typeof(ArgumentException))]
    [InlineData("-02304", typeof(ArgumentException))]
    [InlineData("999999999999999-99999999999999999", typeof(ArgumentException))]
    [InlineData("invalidformat", typeof(ArgumentException))]
    public void Should_ThrowException_When_InvalidFormat(string txt, Type exceptionThrownType)
    {
        // Arrange, Act & Assert
        Assert.Throws(exceptionThrownType, () => new CompetenceMonth(txt));
    }

    [Theory]
    [InlineData(4, 2023)]
    [InlineData(4, 20)]
    public void Should_ConstructFromDateTime(int month, int year)
    {
        var dt = new DateTime(year, month, 1);

        var competence = new CompetenceMonth(dt);

        Assert.Equal(month, competence.Month);
        Assert.Equal(year, competence.Year);
    }

    [Fact]
    public void Should_ThrowException_WhenConstructWithZeroYear()
    {
        // Arrange
        int year = 0;
        int month = 4;

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => new CompetenceMonth(year, month));
    }

    [Fact]
    public void Should_ThrowException_WhenConstructWithZeroMonth()
    {
        // Arrange
        int year = 2023;
        int month = 0;

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => new CompetenceMonth(year, month));
    }

    [Fact]
    public void Should_ConstructWithPositiveMonthCount_Successful()
    {
        // Arrange
        int monthCount = 25; // 2 years and 1 month

        // Act
        var competenceMonth = new CompetenceMonth(monthCount);

        // Assert
        Assert.Equal(2, competenceMonth.Year);
        Assert.Equal(1, competenceMonth.Month);
    }

    [Fact]
    public void Should_ThrowException_WhenConstructWithZeroMonthCount()
    {
        // Arrange
        int monthCount = 0;

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => new CompetenceMonth(monthCount));
    }

    [Fact]
    public void Should_HaveGetPropertiesAsSetInConstructor()
    {
        // Arrange
        int year = 2022;
        int month = 4;

        // Act
        var competenceMonth = new CompetenceMonth(month, year);

        // Assert
        Assert.Equal(2022, competenceMonth.Year);
        Assert.Equal(4, competenceMonth.Month);
    }

    [Fact]
    public void Should_ImplicitlyConvertsToDateTime()
    {
        // Arrange
        CompetenceMonth competenceMonth = new(4, 2023);

        // Act
        DateTime dateTime = competenceMonth;

        // Assert
        Assert.Equal(new DateTime(2023, 4, 1), dateTime);
    }

    [Fact]
    public void Should_ConvertCompetenceMonthToInt()
    {
        // Arrange  
        CompetenceMonth competenceMonth = new(4, 2023);

        // Act
        int monthCount = competenceMonth;

        // Assert
        Assert.Equal(24280, monthCount);
    }

}