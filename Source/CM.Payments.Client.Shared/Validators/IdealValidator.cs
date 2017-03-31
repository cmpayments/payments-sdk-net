using CM.Payments.Client.Model;
using FluentValidation;

namespace CM.Payments.Client.Validators
{
    internal sealed class IdealValidator : AbstractValidator<IdealPaymentRequest>
    {
        public IdealValidator()
        {
            this.RuleFor(p => p.Details).SetValidator(new IdealDetailsValidator());
        }
    }
}