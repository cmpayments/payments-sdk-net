using CM.Payments.Client.Model;
using FluentValidation;

namespace CM.Payments.Client.Validators
{
    internal sealed class SofortDetailsValidator : BaseValidator<SofortDetailsRequest>
    {
        public SofortDetailsValidator()
        {
            RuleFor(r => r.PurchaseId).NotEmpty().Length(1, 35);
            RuleFor(r => r.BankAccountNumber).NotEmpty().Length(1, 34);
            RuleFor(r => r.ConsumerName).NotEmpty().Length(1, 255);
            RuleFor(r => r.BankBic).NotEmpty().Length(1, 11);
            RuleFor(r => r.PurchaseId).NotEmpty().Length(1, 35);
            RuleFor(r => r.Description).NotEmpty().Length(1, 35);
        }
    }
}