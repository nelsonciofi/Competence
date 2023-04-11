namespace Competence.UseCases.Issues;

internal class PaymentOrder
{
    public PaymentOrder(string competence, DateTime dueDate, AccountsReceivable[] accountsReceivables)
    {
        if (string.IsNullOrWhiteSpace(competence)) throw new ArgumentNullException(nameof(competence));
        if (dueDate < DateTime.Today) throw new ArgumentOutOfRangeException(nameof(dueDate));
        if (!accountsReceivables.Any()) throw new ArgumentException("Payment order must have at least one account receivable.", nameof(accountsReceivables));

        Competence = competence;
        AccountsReceivables = accountsReceivables;
        DueDate = dueDate;
        Value = accountsReceivables.Sum(a => a.Value);
    }

    public DateTime DueDate { get; }
    public decimal Value { get; }
    public string Competence { get; }

    public bool Paid { get; set; }

    public AccountsReceivable[] AccountsReceivables { get; }
}
