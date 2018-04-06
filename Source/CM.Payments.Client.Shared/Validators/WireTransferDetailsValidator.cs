using CM.Payments.Client.Model;
using FluentValidation;

namespace CM.Payments.Client.Validators
{
    internal sealed class WireTransferDetailsValidator : BaseValidator<WireTransferDetailsRequest>
    {
        public WireTransferDetailsValidator()
        {
            RuleFor(r => r.PurchaseId).NotEmpty().Length(1, 35);
        }
    }
}