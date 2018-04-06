using CM.Payments.Client.Model;
using FluentValidation;

namespace CM.Payments.Client.Validators
{
    internal sealed class IdealDetailsValidator : BaseValidator<IdealDetailsRequest>
    {
        public IdealDetailsValidator()
        {
            RuleFor(p => p.Description).NotNull().Length(1, 35);
            RuleFor(p => p.PurchaseId).NotNull().Length(1, 35);
            RuleFor(p => p.IssuerId).NotNull().Length(1, 8);
        }
    }
}