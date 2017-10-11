using CM.Payments.Client.Model;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;

namespace CM.Payments.Client.Validators
{
    internal sealed class ChargeValidator : AbstractValidator<ChargeRequest>
    {
        public ChargeValidator()
        {
            this.RuleFor(c => c.Amount).NotEmpty();
            this.RuleFor(c => c.Payments)
                .Must(ContainOneItem)
                .WithMessage("'Payments' must contain '1' payment.")
                .SetCollectionValidator(new PaymentValidator());
        }
        
        private static bool ContainOneItem(IEnumerable<PaymentRequest> payments)
        {
            return payments?.Count() == 1;
        }
    }
}