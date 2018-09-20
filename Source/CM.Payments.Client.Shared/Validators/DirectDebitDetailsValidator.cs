using CM.Payments.Client.Model;
using FluentValidation;

namespace CM.Payments.Client.Validators
{
    internal sealed class DirectDebitDetailsValidator : BaseValidator<DirectDebitDetailsRequest>
    {
        public DirectDebitDetailsValidator()
        {
            RuleFor(d => d.BankAccountNumber).NotNull();
            RuleFor(d => d.Name).NotNull();
            RuleFor(d => d.MandateId).NotNull().Length(1, 35);
            RuleFor(d => d.PurchaseId).NotNull().Length(1, 35);
        }
    }
}