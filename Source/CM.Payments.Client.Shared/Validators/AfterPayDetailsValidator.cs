using System.Text.RegularExpressions;
using CM.Payments.Client.Model;
using FluentValidation;
using JetBrains.Annotations;

namespace CM.Payments.Client.Validators
{
    internal sealed class AfterPayDetailsValidator : BaseValidator<AfterPayDetailsRequest>
    {
        public AfterPayDetailsValidator()
        {
            RuleFor(d => d.BankAccountNumber).NotNull();
            RuleFor(d => d.InvoiceNumber).NotNull().Length(2, 15);
            RuleFor(d => d.IpAddress).NotNull().Must(BeAValidIpAddress);
            RuleFor(d => d.OrderNumber).NotNull().Length(2, 25);
            RuleFor(d => d.PortfolioId).NotNull().GreaterThanOrEqualTo(1).LessThanOrEqualTo(3);
            RuleFor(d => d.Password).NotNull().Length(1, 20);
            RuleFor(d => d.TotalOrderAmount).NotNull();
            RuleFor(d => d.BillToAddress).SetValidator(new OrderAddressValidator());
            RuleFor(d => d.ShipToAddress).SetValidator(new OrderAddressValidator());
            RuleFor(d => d.Orderline).SetCollectionValidator(new OrderLineValidator());
        }

        private static bool BeAValidIpAddress([NotNull] string ip)
        {
            return Regex.IsMatch(ip, @"^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$");
        }

        private sealed class OrderLineValidator : BaseValidator<AfterPayDetailsRequest.OrderLine>
        {
            public OrderLineValidator()
            {
                RuleFor(r => r.ArticleDescription).NotNull().Length(1, 45);
                RuleFor(r => r.ArticleId).NotNull().Length(1, 25);
                RuleFor(r => r.Quantity).NotNull();
                RuleFor(r => r.UnitPrice).NotNull();
                RuleFor(r => r.VatCategory).NotNull();
            }
        }

        private sealed class OrderAddressValidator : BaseValidator<AfterPayDetailsRequest.OrderAddress>
        {
            public OrderAddressValidator()
            {
                RuleFor(r => r.City).NotEmpty().Length(1, 80);
                RuleFor(r => r.StreetName).NotEmpty().Length(1, 80);
                RuleFor(r => r.HouseNumber).NotNull();
                RuleFor(r => r.IsoCountryCode).NotEmpty().Length(1, 2);
                RuleFor(r => r.PostalCode).NotEmpty().Must(BeAValidPostalCode);
                RuleFor(r => r.Region).NotEmpty().Length(1, 80);
                RuleFor(r => r.Reference).SetValidator(new ReferencePersonValidator());
            }

            private sealed class ReferencePersonValidator : BaseValidator<AfterPayDetailsRequest.OrderAddress.ReferencePerson>
            {
                public ReferencePersonValidator()
                {
                    RuleFor(r => r.LastName).NotNull().Length(1, 30);
                    RuleFor(r => r.Initials).NotNull().Length(1, 20);
                    RuleFor(r => r.EmailAddress).NotEmpty().EmailAddress();
                    RuleFor(r => r.PhoneNumber1).NotEmpty().Length(10);
                    RuleFor(r => r.PhoneNumber2).NotEmpty().Length(10);
                    RuleFor(r => r.Gender).Length(1);
                    RuleFor(r => r.DateOfBirth).NotEmpty();
                    RuleFor(r => r.IsoLanguage).NotEmpty().Length(1, 5);
                }
            }
        }
    }
}