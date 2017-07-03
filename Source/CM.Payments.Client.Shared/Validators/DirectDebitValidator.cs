using CM.Payments.Client.Model;
using FluentValidation;

namespace CM.Payments.Client.Validators
{
    internal sealed class DirectDebitValidator : AbstractValidator<DirectDebitPaymentRequest>
    {
        public DirectDebitValidator()
        {
            this.RuleFor(p => p.Details).SetValidator(new DirectDebitDetailsValidator());
        }
    }
}