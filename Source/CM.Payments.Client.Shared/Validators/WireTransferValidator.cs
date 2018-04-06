using CM.Payments.Client.Model;
using FluentValidation;

namespace CM.Payments.Client.Validators
{
    internal sealed class WireTransferValidator : BaseValidator<WireTransferPaymentRequest>
    {
        public WireTransferValidator()
        {
            RuleFor(p => p.Currency).NotNull().Must(BeAValidCurrency).WithMessage($"'{nameof(WireTransferPaymentRequest.Currency)}' must be in the right ISO format.");
            RuleFor(p => p.Details).SetValidator(new WireTransferDetailsValidator());
        }
    }
}