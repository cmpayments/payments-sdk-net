using System.Text.RegularExpressions;
using CM.Payments.Client.Model;
using FluentValidation;
using JetBrains.Annotations;

namespace CM.Payments.Client.Validators
{
    internal sealed class AfterPayDetailsValidator : AbstractValidator<AfterPayDetailsRequest>
    {
        public AfterPayDetailsValidator()
        {
            this.RuleFor(d => d.BankAccountNumber).NotNull().Must(BeAValidIban);
            this.RuleFor(d => d.InvoiceNumber).NotNull().Length(2, 15);
            this.RuleFor(d => d.IpAddress).NotNull().Must(BeAValidIpAddress);
            this.RuleFor(d => d.OrderNumber).NotNull().Length(2, 25);
            this.RuleFor(d => d.PortfolioId).NotNull().GreaterThanOrEqualTo(1).LessThanOrEqualTo(3);
            this.RuleFor(d => d.Password).NotNull().Length(1, 20);
            this.RuleFor(d => d.TotalOrderAmount).NotNull();
            this.RuleFor(d => d.BillToAddress).SetValidator(new OrderAddressValidator());
            this.RuleFor(d => d.ShipToAddress).SetValidator(new OrderAddressValidator());
            this.RuleFor(d => d.Orderline).SetCollectionValidator(new OrderLineValidator());
        }

        private static bool BeAValidIban([NotNull] string iban)
        {
            return Regex.IsMatch(iban, @"^[A-Z]{2}[0-9]{2}[A-Z]{4}[0-9]{10}$");
        }

        private static bool BeAValidIpAddress([NotNull] string ip)
        {
            return Regex.IsMatch(ip, @"^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$");
        }

        private sealed class OrderLineValidator : AbstractValidator<AfterPayDetailsRequest.OrderLine>
        {
            public OrderLineValidator()
            {
                this.RuleFor(r => r.ArticleDescription).NotNull().Length(1, 45);
                this.RuleFor(r => r.ArticleId).NotNull().Length(1, 25);
                this.RuleFor(r => r.Quantity).NotNull();
                this.RuleFor(r => r.UnitPrice).NotNull();
                this.RuleFor(r => r.VatCategory).NotNull();
            }
        }

        private sealed class OrderAddressValidator : AbstractValidator<AfterPayDetailsRequest.OrderAddress>
        {
            public OrderAddressValidator()
            {
                this.RuleFor(r => r.City).NotEmpty().Length(1, 80);
                this.RuleFor(r => r.StreetName).NotEmpty().Length(1, 80);
                this.RuleFor(r => r.HouseNumber).NotNull();
                this.RuleFor(r => r.IsoCountryCode).NotEmpty().Length(1, 2);
                this.RuleFor(r => r.PostalCode).NotEmpty().Must(BeAValidPostalCode);
                this.RuleFor(r => r.Region).NotEmpty().Length(1, 80);
                this.RuleFor(r => r.Reference).SetValidator(new ReferencePersonValidator());
            }

            private static bool BeAValidPostalCode([NotNull] string postal)
            {
                return Regex.IsMatch(postal, @"^[1-9][0-9]{3}\s?([a-zA-Z]{2})?$");
            }

            private sealed class ReferencePersonValidator : AbstractValidator<AfterPayDetailsRequest.OrderAddress.ReferencePerson>
            {
                public ReferencePersonValidator()
                {
                    this.RuleFor(r => r.LastName).NotNull().Length(1, 30);
                    this.RuleFor(r => r.Initials).NotNull().Length(1, 20);
                    this.RuleFor(r => r.EmailAddress).NotEmpty().EmailAddress();
                    this.RuleFor(r => r.PhoneNumber1).NotEmpty().Length(10);
                    this.RuleFor(r => r.PhoneNumber2).NotEmpty().Length(10);
                    this.RuleFor(r => r.Gender).Length(1);
                    this.RuleFor(r => r.DateOfBirth).NotEmpty();
                    this.RuleFor(r => r.IsoLanguage).NotEmpty().Length(1, 5);
                }
            }
        }
    }
}