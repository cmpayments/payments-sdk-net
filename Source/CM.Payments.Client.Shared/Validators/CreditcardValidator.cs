using CM.Payments.Client.Model;
using FluentValidation;

namespace CM.Payments.Client.Validators
{
    internal sealed class CreditcardValidator : BaseValidator<CreditcardPaymentRequest>
    {
        public CreditcardValidator()
        {
            RuleFor(p => p.Currency).NotNull().Must(BeAValidCurrency).WithMessage($"'{nameof(CreditcardPaymentRequest.Currency)}' must be in the right ISO format.");
            RuleFor(p => p.Details).SetValidator(new CreditcardDetailsValidator());
        }
    }
}