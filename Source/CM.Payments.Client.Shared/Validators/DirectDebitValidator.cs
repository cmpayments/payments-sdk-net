using CM.Payments.Client.Model;
using FluentValidation;

namespace CM.Payments.Client.Validators
{
    internal sealed class DirectDebitValidator : BaseValidator<DirectDebitPaymentRequest>
    {
        public DirectDebitValidator()
        {
            RuleFor(p => p.Currency).NotNull().Must(BeAValidCurrency).WithMessage($"'{nameof(DirectDebitPaymentRequest.Currency)}' must be in the right ISO format.");
            RuleFor(p => p.Details).SetValidator(new DirectDebitDetailsValidator());
        }
    }
}