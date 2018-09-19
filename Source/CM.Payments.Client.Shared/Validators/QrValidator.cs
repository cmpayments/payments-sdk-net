using System;
using CM.Payments.Client.Model;
using FluentValidation;

namespace CM.Payments.Client.Validators
{
    internal sealed class QrValidator : BaseValidator<QrRequest>
    {
        public QrValidator()
        {
            RuleFor(w => w.Amount).NotNull();
            RuleFor(w => w.AmountChangeable).NotNull();
            RuleFor(w => w.Description).NotEmpty().Length(1, 95);
            RuleFor(w => w.OneOff).NotNull();
            RuleFor(w => w.Expiration).NotNull().Must(BeAValidDate).WithMessage("Invalid date/time");
            RuleFor(w => w.Beneficiary).NotEmpty().Length(1, 40);
            RuleFor(w => w.PurchaseId).NotEmpty().Length(1, 35);
            RuleFor(w => w.Size).NotNull().InclusiveBetween(100, 2000);
            When(
                w => w.AmountChangeable,
                () =>
                {
                    RuleFor(x => x.AmountMin).GreaterThan(0).LessThan(w => w.AmountMax).WithMessage("'AmountMin' must be less than 'AmountMax'");
                    RuleFor(x => x.AmountMax)
                        .GreaterThan(0)
                        .GreaterThan(w => w.AmountMin)
                        .WithMessage("'AmountMax' must be greater than 'AmountMin'");
                    RuleFor(x => x.Amount).GreaterThanOrEqualTo(w => w.AmountMin).LessThanOrEqualTo(w => w.AmountMax);
                });
        }

        private static bool BeAValidDate(string value)
        {
            return DateTime.TryParse(value, out _);
        }
    }
}