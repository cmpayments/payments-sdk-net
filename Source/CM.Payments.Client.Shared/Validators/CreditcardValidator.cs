using CM.Payments.Client.Model;
using FluentValidation;

namespace CM.Payments.Client.Validators
{
    internal sealed class CreditcardValidator : AbstractValidator<CreditcardPaymentRequest>
    {
        public CreditcardValidator()
        {
            this.RuleFor(p => p.Details).SetValidator(new CreditcardDetailsValidator());
        }
    }
}