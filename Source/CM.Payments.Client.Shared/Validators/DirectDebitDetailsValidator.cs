using CM.Payments.Client.Model;
using FluentValidation;
using JetBrains.Annotations;
using System.Text.RegularExpressions;

namespace CM.Payments.Client.Validators
{
    internal sealed class DirectDebitDetailsValidator : AbstractValidator<DirectDebitDetailsRequest>
    {
        public DirectDebitDetailsValidator()
        {
            this.RuleFor(d => d.BankAccountNumber).NotNull().Must(BeAValidIban);
            this.RuleFor(d => d.Name).NotNull();
            this.RuleFor(d => d.MandateId).NotNull().Length(1, 35);
            this.RuleFor(d => d.PurchaseId).NotNull().Length(1, 35);
        }

        private static bool BeAValidIban([NotNull] string iban)
        {
            return Regex.IsMatch(iban, @"^[A-Z]{2}[0-9]{2}[A-Z]{4}[0-9]{10}$");
        }
    }
}