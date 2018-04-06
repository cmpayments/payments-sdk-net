using CM.Payments.Client.Model;
using FluentValidation;

namespace CM.Payments.Client.Validators
{
    internal sealed class SofortValidator : BaseValidator<SofortPaymentRequest>
    {
        public SofortValidator()
        {
            RuleFor(p => p.Currency).NotNull().Must(BeAValidCurrency).WithMessage($"'{nameof(SofortPaymentRequest.Currency)}' must be in the right ISO format.");
            RuleFor(p => p.Details).SetValidator(new SofortDetailsValidator());
        }
    }
}