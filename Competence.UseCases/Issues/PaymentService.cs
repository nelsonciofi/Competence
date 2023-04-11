namespace Competence.UseCases.Issues;

internal class PaymentServiceWithIssues
{
    public void PayOrder()
    {
        var service1AccountReceivable = new AccountsReceivable("04/2023", 10);
        var service2AccountReceivable = new AccountsReceivable("04/2023", 15);

        var servicesPaymentOrder = new PaymentOrder("04/2023",
                                                    new DateTime(2023, 04, 15),
                                                    new AccountsReceivable[] {
                                                        service1AccountReceivable,
                                                        service2AccountReceivable
                                                    });

        var paymentCompetence = DateTime.Parse(servicesPaymentOrder.Competence);

        if (service1AccountReceivable.Competence.Month != paymentCompetence.Month ||
           service2AccountReceivable.Competence.Month != paymentCompetence.Month)
        {
            throw new InvalidOperationException("Payment can only happen in the same competence month of accounts receivable.");
        }

        //Some service implements payment logic.

        servicesPaymentOrder.Paid = true;

        Console.WriteLine("The order was paid successfully!");
    }
}
