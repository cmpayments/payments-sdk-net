using CM.Payments.Client.Model;
using FluentValidation;
using JetBrains.Annotations;
using System.Text.RegularExpressions;

namespace CM.Payments.Client.Validators
{
    internal sealed class DirectDebitDetailsValidator : BaseValidator<DirectDebitDetailsRequest>
    {
        public DirectDebitDetailsValidator()
        {
            RuleFor(d => d.BankAccountNumber).NotNull().Must(BeAValidIban);
            RuleFor(d => d.Name).NotNull();
            RuleFor(d => d.MandateId).NotNull().Length(1, 35);
            RuleFor(d => d.PurchaseId).NotNull().Length(1, 35);
        }
    }
}