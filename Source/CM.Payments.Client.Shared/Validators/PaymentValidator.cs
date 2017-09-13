using System.Globalization;
using CM.Payments.Client.Model;
using FluentValidation;

namespace CM.Payments.Client.Validators
{
    internal sealed class PaymentValidator : PaymentValidatorBase<PaymentRequest>
    {
        public PaymentValidator()
        {
            this.RuleFor(p => p.Amount).NotEmpty();
            this.RuleFor(p => p.Currency).Must(BeAValidIsoFormat).WithMessage("'Currency' must be in the right ISO format.");
            this.AddValidator<IdealPaymentRequest, IdealValidator>();
            this.AddValidator<PayPalPaymentRequest, PayPalValidator>();
            this.AddValidator<AfterPayPaymentRequest, AfterPayValidator>();
            this.AddValidator<CreditcardPaymentRequest, CreditcardValidator>();
            this.AddValidator<SofortPaymentRequest, SofortValidator>();
            this.AddValidator<BancontactPaymentRequest, BancontactValidator>();
            this.AddValidator<WireTransferPaymentRequest, WireTransferValidator>();
            this.AddValidator<DirectDebitPaymentRequest, DirectDebitValidator>();
        }

        private static bool BeAValidIsoFormat(string currency)
        {
            var info = new RegionInfo("NL");
            return info.ISOCurrencySymbol == currency;
        }
    }
}