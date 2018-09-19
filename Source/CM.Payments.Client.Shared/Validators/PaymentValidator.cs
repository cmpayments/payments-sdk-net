using System.Globalization;
using CM.Payments.Client.Model;
using FluentValidation;

namespace CM.Payments.Client.Validators
{
    internal sealed class PaymentValidator : PaymentValidatorBase<PaymentRequest>
    {
        public PaymentValidator()
        {
            RuleFor(p => p.Amount).NotEmpty();
            RuleFor(p => p.Currency).NotNull().Must(BeAValidCurrency).WithMessage($"'{nameof(DirectDebitPaymentRequest.Currency)}' must be in the right ISO format.");
            AddValidator<IdealPaymentRequest, IdealValidator>();
            AddValidator<PayPalPaymentRequest, PayPalValidator>();
            AddValidator<AfterPayPaymentRequest, AfterPayValidator>();
            AddValidator<CreditcardPaymentRequest, CreditcardValidator>();
            AddValidator<SofortPaymentRequest, SofortValidator>();
            AddValidator<BancontactPaymentRequest, BancontactValidator>();
            AddValidator<WireTransferPaymentRequest, WireTransferValidator>();
            AddValidator<DirectDebitPaymentRequest, DirectDebitValidator>();
        }
    }
}