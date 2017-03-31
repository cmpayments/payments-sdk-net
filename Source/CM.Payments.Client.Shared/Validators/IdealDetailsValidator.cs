using CM.Payments.Client.Model;
using FluentValidation;

namespace CM.Payments.Client.Validators
{
    internal sealed class IdealDetailsValidator : AbstractValidator<IdealDetailsRequest>
    {
        public IdealDetailsValidator()
        {
            this.RuleFor(p => p.Description).NotNull().Length(1, 35);
            this.RuleFor(p => p.PurchaseId).NotNull().Length(1, 35);
            this.RuleFor(p => p.IssuerId).NotNull().Length(1, 8);
        }
    }
}