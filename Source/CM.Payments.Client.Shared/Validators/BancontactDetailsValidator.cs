using CM.Payments.Client.Model;
using FluentValidation;

namespace CM.Payments.Client.Validators
{
    internal sealed class BancontactDetailsValidator : BaseValidator<BancontactDetailsRequest>
    {
        public BancontactDetailsValidator()
        {
            RuleFor(r => r.PurchaseId).NotEmpty().Length(1, 35);
        }
    }
}