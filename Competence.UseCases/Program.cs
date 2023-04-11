// See https://aka.ms/new-console-template for more information

using Competence.UseCases.Fixes;
using Competence.UseCases.Issues;


var paymentWithIssues = new PaymentServiceWithIssues();
paymentWithIssues.PayOrder();

var paymentWithFixes = new PaymentServiceWithFixes();
paymentWithFixes.PayOrder(); 


