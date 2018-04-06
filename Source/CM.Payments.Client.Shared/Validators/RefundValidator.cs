using CM.Payments.Client.Model;
using FluentValidation;

namespace CM.Payments.Client.Validators
{
    internal sealed class RefundValidator : BaseValidator<RefundRequest>
    {
        public RefundValidator()
        {
            RuleFor(w => w.Amount).NotNull();
            RuleFor(p => p.Currency).NotNull().Must(BeAValidCurrency).WithMessage($"'{nameof(RefundRequest.Currency)}' must be in the right ISO format.");
            RuleFor(w => w.PaymentId).NotEmpty().Length(1, 39);
        }
    }
}