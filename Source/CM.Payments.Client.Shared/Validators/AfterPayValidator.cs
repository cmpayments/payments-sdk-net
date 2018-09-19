using CM.Payments.Client.Model;
using FluentValidation;

namespace CM.Payments.Client.Validators
{
    internal sealed class AfterPayValidator : BaseValidator<AfterPayPaymentRequest>
    {
        public AfterPayValidator()
        {
            RuleFor(p => p.Currency).NotNull().Must(BeAValidCurrency).WithMessage($"'{nameof(AfterPayPaymentRequest.Currency)}' must be in the right ISO format.");
            RuleFor(p => p.Details).SetValidator(new AfterPayDetailsValidator());
        }
    }
}