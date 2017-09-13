using CM.Payments.Client.Model;
using FluentValidation;

namespace CM.Payments.Client.Validators
{
    internal sealed class WireTransferDetailsValidator : AbstractValidator<WireTransferDetailsRequest>
    {
        public WireTransferDetailsValidator()
        {
            this.RuleFor(r => r.PurchaseId).NotEmpty().Length(1, 35);
        }
    }
}