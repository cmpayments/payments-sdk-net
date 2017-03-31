using CM.Payments.Client.Model;
using FluentValidation;

namespace CM.Payments.Client.Validators
{
    internal sealed class SofortValidator : AbstractValidator<SofortPaymentRequest>
    {
        public SofortValidator()
        {
            this.RuleFor(p => p.Details).SetValidator(new SofortDetailsValidator());
        }
    }
}