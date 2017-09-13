using CM.Payments.Client.Model;
using FluentValidation;

namespace CM.Payments.Client.Validators
{
    internal sealed class PayPalValidator : AbstractValidator<PayPalPaymentRequest>
    {
        public PayPalValidator()
        {
            this.RuleFor(p => p.Details).SetValidator(new PayPalDetailsValidator());
        }
    }
}