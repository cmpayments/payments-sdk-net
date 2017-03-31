using CM.Payments.Client.Model;
using FluentValidation;

namespace CM.Payments.Client.Validators
{
    internal sealed class CreditcardDetailsValidator : AbstractValidator<CreditcardDetailsRequest>
    {
        public CreditcardDetailsValidator()
        {
            this.RuleFor(r => r.PurchaseId).NotEmpty().Length(1, 35);
        }
    }
}