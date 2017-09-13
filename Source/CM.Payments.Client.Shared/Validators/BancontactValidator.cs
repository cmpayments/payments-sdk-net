using CM.Payments.Client.Model;
using FluentValidation;

namespace CM.Payments.Client.Validators
{
    internal sealed class BancontactValidator : AbstractValidator<BancontactPaymentRequest>
    {
        public BancontactValidator()
        {
            this.RuleFor(p => p.Details).SetValidator(new BancontactDetailsValidator());
        }
    }
}