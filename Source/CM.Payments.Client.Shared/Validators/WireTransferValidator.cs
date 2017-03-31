using CM.Payments.Client.Model;
using FluentValidation;

namespace CM.Payments.Client.Validators
{
    internal sealed class WireTransferValidator : AbstractValidator<WireTransferPaymentRequest>
    {
        public WireTransferValidator()
        {
            this.RuleFor(p => p.Details).SetValidator(new WireTransferDetailsValidator());
        }
    }
}