using CM.Payments.Client.Model;
using FluentValidation;

namespace CM.Payments.Client.Validators
{
    internal sealed class AfterPayValidator : AbstractValidator<AfterPayPaymentRequest>
    {
        public AfterPayValidator()
        {
            this.RuleFor(p => p.Details).SetValidator(new AfterPayDetailsValidator());
        }
    }
}