using CM.Payments.Client.Model;
using FluentValidation;

namespace CM.Payments.Client.Validators
{
    internal sealed class IdealValidator : BaseValidator<IdealPaymentRequest>
    {
        public IdealValidator()
        {
            RuleFor(p => p.Currency).NotNull().Must(BeAValidCurrency).WithMessage($"'{nameof(IdealPaymentRequest.Currency)}' must be in the right ISO format.");
            RuleFor(p => p.Details).SetValidator(new IdealDetailsValidator());
        }
    }
}