using CM.Payments.Client.Model;
using FluentValidation;

namespace CM.Payments.Client.Validators
{
    internal sealed class RefundValidator : AbstractValidator<RefundRequest>
    {
        public RefundValidator()
        {
            this.RuleFor(w => w.Amount).NotNull();
            this.RuleFor(w => w.PaymentId).NotEmpty().Length(1, 39);
        }
    }
}