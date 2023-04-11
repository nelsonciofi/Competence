namespace Competence.UseCases.Issues;

internal class AccountsReceivable
{
    public AccountsReceivable(string competence, decimal value)
    {
        if (string.IsNullOrWhiteSpace(competence))
        {
            throw new ArgumentException($"'{nameof(competence)}' cannot be null or whitespace.", nameof(competence));
        }

        competence = "01" + competence;

        if (!DateTime.TryParse(competence, out DateTime date))
        {
            throw new ArgumentException("Invalid format.", nameof(competence));
        }

        Competence = date;
        Value = value;
    }

    public decimal Value { get; set; }
    public DateTime Competence { get; }
}
