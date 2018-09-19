using CM.Payments.Client.Model;
using FluentValidation;

namespace CM.Payments.Client.Validators
{
    internal sealed class CreditcardDetailsValidator : BaseValidator<CreditcardDetailsRequest>
    {
        public CreditcardDetailsValidator()
        {
            RuleFor(r => r.PurchaseId).NotEmpty().Length(1, 35);
        }
    }
}