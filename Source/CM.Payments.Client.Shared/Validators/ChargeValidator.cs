using CM.Payments.Client.Model;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;

namespace CM.Payments.Client.Validators
{
    internal sealed class ChargeValidator : BaseValidator<ChargeRequest>
    {
        public ChargeValidator()
        {
            RuleFor(c => c.Amount).NotEmpty();
            RuleFor(c => c.Currency).NotNull().Must(BeAValidCurrency);
            RuleFor(c => c.Payments)
                .Must(ContainOneItem)
                .WithMessage($"'{nameof(ChargeRequest.Payments)}' must contain '1' payment.")
                .SetCollectionValidator(new PaymentValidator());
        }
        
        private static bool ContainOneItem(IEnumerable<PaymentRequest> payments)
        {
            return payments?.Count() == 1;
        }
    }
}