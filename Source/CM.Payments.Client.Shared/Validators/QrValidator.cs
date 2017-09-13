using System;
using CM.Payments.Client.Model;
using FluentValidation;

namespace CM.Payments.Client.Validators
{
    internal sealed class QrValidator : AbstractValidator<QrRequest>
    {
        public QrValidator()
        {
            this.RuleFor(w => w.Amount).NotNull();
            this.RuleFor(w => w.AmountChangeable).NotNull();
            this.RuleFor(w => w.Description).NotEmpty().Length(1, 95);
            this.RuleFor(w => w.OneOff).NotNull();
            this.RuleFor(w => w.Expiration).NotNull().Must(BeAValidDate).WithMessage("Invalid date/time");
            this.RuleFor(w => w.Beneficiary).NotEmpty().Length(1, 40);
            this.RuleFor(w => w.PurchaseId).NotEmpty().Length(1, 35);
            this.RuleFor(w => w.Size).NotNull().InclusiveBetween(100, 2000);
            this.When(
                w => w.AmountChangeable,
                () =>
                {
                    this.RuleFor(x => x.AmountMin).GreaterThan(0).LessThan(w => w.AmountMax).WithMessage("'AmountMin' must be less than 'AmountMax'");
                    this.RuleFor(x => x.AmountMax)
                        .GreaterThan(0)
                        .GreaterThan(w => w.AmountMin)
                        .WithMessage("'AmountMax' must be greater than 'AmountMin'");
                    this.RuleFor(x => x.Amount).GreaterThanOrEqualTo(w => w.AmountMin).LessThanOrEqualTo(w => w.AmountMax);
                });
        }

        private static bool BeAValidDate(string value)
        {
            DateTime date;
            return DateTime.TryParse(value, out date);
        }
    }
}