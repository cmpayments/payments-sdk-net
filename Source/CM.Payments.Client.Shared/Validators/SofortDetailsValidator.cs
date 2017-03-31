using CM.Payments.Client.Model;
using FluentValidation;

namespace CM.Payments.Client.Validators
{
    internal sealed class SofortDetailsValidator : AbstractValidator<SofortDetailsRequest>
    {
        public SofortDetailsValidator()
        {
            this.RuleFor(r => r.PurchaseId).NotEmpty().Length(1, 35);
            this.RuleFor(r => r.BankAccountNumber).NotEmpty().Length(1, 34);
            this.RuleFor(r => r.ConsumerName).NotEmpty().Length(1, 255);
            this.RuleFor(r => r.BankBic).NotEmpty().Length(1, 11);
            this.RuleFor(r => r.PurchaseId).NotEmpty().Length(1, 35);
            this.RuleFor(r => r.Description).NotEmpty().Length(1, 35);
        }
    }
}