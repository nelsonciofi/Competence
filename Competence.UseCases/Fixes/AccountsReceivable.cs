namespace Competence.UseCases.Fixes;

internal class AccountsReceivable
{
    public AccountsReceivable(string competence, decimal value)
    {       
        Competence = competence;
        Value = value;
    }

    public decimal Value { get; set; }
    public CompetenceMonth Competence { get; }
}
