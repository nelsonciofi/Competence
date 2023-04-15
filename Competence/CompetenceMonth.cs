namespace Competence;


public readonly struct CompetenceMonth : IEquatable<CompetenceMonth>, IComparable<CompetenceMonth>
{
    private readonly int year;
    private readonly int month;

    public CompetenceMonth(int month, int year)
    {
        if (year <= 0) throw new ArgumentOutOfRangeException(nameof(year));
        if (month <= 0 || month > 12) throw new ArgumentOutOfRangeException(nameof(month));

        this.year = year;
        this.month = month;
    }

    public CompetenceMonth(int monthCount)
    {
        if (monthCount <= 0) throw new ArgumentOutOfRangeException(nameof(monthCount));

        CalculateCompetenceFromMonthCount(monthCount, out int month, out int year);

        this.year = year;
        this.month = month;
    }

    public CompetenceMonth(string txt)
    {
        if (string.IsNullOrWhiteSpace(txt)) throw new ArgumentNullException(nameof(txt));

        ConvertCompetenceFromText(txt, out int month, out int year);

        this.year = year;
        this.month = month;
    }

    public CompetenceMonth(DateTime dt)
    {
        year = dt.Year;
        month = dt.Month;
    }


    public int Year => year;
    public int Month => month;

    public int ToMonthCount() => (year * 12) + month;
    public DateTime ToDateTime() => new(year, month, 1);
    public string ToCompetenceText() => $"{month:D2}/{year}";



    public CompetenceMonth AddYears(int years) => new(month, year + years);
    public CompetenceMonth AddMonths(int months)
    {
        var monthCount = ToMonthCount() + months;
        return new CompetenceMonth(monthCount);
    }

    public override bool Equals(object? obj) => obj is CompetenceMonth month && Equals(month);
    public bool Equals(CompetenceMonth other) => year == other.year && month == other.month;
    public override int GetHashCode() => HashCode.Combine(year, month);
    public override string ToString() => ToCompetenceText();

    public int CompareTo(CompetenceMonth other) => this == other ? 0 : this < other ? -1 : 1;

    public static bool operator ==(CompetenceMonth left, CompetenceMonth right) => left.Equals(right);
    public static bool operator !=(CompetenceMonth left, CompetenceMonth right) => !(left == right);

    public static bool operator >(CompetenceMonth left, CompetenceMonth right)
    {
        return left.year > right.year || (left.year == right.year && left.month > right.month);
    }

    public static bool operator <(CompetenceMonth left, CompetenceMonth right)
    {
        return left.year < right.year || (left.year == right.year && left.month < right.month);
    }

    public static implicit operator int(CompetenceMonth competenceMonth)
        => competenceMonth.ToMonthCount();

    public static implicit operator CompetenceMonth(int monthCount)
        => new(monthCount);

    public static implicit operator DateTime(CompetenceMonth competenceMonth)
        => competenceMonth.ToDateTime();

    public static implicit operator CompetenceMonth(DateTime dateTime)
        => new(dateTime);

    public static implicit operator string(CompetenceMonth competenceMonth)
        => competenceMonth.ToCompetenceText();

    public static implicit operator CompetenceMonth(string txt)
        => new(txt);


    public static bool TryParse(string txt, out int month, out int year)
    {
        try
        {
            ConvertCompetenceFromText(txt, out month, out year);
            return true;
        }
        catch (Exception)
        {
            month = 0;
            year = 0;

            return false;
        }
    }

    public static bool TryParse(string txt, out CompetenceMonth cm)
    {
        try
        {
            ConvertCompetenceFromText(txt, out int month, out int year);

            cm = new CompetenceMonth(year, month);

            return true;
        }
        catch (Exception)
        {
            cm = new CompetenceMonth();

            return false;
        }
    }


    private static void CalculateCompetenceFromMonthCount(int monthCount, out int month, out int year)
    {
        year = monthCount / 12;
        month = monthCount % 12;

        while (month < 1)
        {
            month += 12;
            year--;
        }

        while (month > 12)
        {
            month -= 12;
            year++;
        }
    }

    private static void ConvertCompetenceFromText(string txt, out int month, out int year)
    {
        var validChars = new char[] { '/', '-' };

        var index = txt.IndexOfAny(validChars);

        if (index < 0)
        {
            throw new ArgumentException("Invalid format.");
        }

        var txtSpn = txt.AsSpan();

        var p1 = txtSpn[..index];
        var p2 = txtSpn[(index + 1)..];

        if (p1.Length == 2)
        {
            if (!int.TryParse(p1, out month))
            {
                throw new InvalidOperationException();
            }

            if (!int.TryParse(p2, out year))
            {
                throw new InvalidOperationException();
            }
        }
        else if (p1.Length == 4)
        {
            if (!int.TryParse(p2, out month))
            {
                throw new InvalidOperationException();
            }

            if (!int.TryParse(p1, out year))
            {
                throw new InvalidOperationException();
            }
        }
        else
        {
            throw new ArgumentException("Invalid format.");
        }
    }    
}