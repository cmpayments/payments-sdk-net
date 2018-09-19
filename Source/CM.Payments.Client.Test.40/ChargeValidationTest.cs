using CM.Payments.Client.Model;
using CM.Payments.Client.Validators;
using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CM.Payments.Client.Test
{
    [TestClass]
    public class ChargeValidationTest
    {
        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void Validate_WithoutAmount()
        {
            //Arrange
            var charge = new ChargeRequest
            {
                Currency = "EUR",
                Payments = new List<PaymentRequest>
                {
                    new IdealPaymentRequest
                    {
                        Currency = "EUR",
                        Details = new IdealDetailsRequest
                        {
                            IssuerId = "RABONL2U",
                            SuccessUrl = "",
                            FailedUrl = "",
                            CancelledUrl = "",
                            ExpiredUrl = "",
                            PurchaseId = Guid.NewGuid().ToString("N"),
                            Description = "Test description."
                        }
                    }
                }
            };

            //Act
            new ChargeValidator().ValidateAndThrow(charge);
        }


        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void Validate_WithoutPayments()
        {
            //Arrange
            var charge = new ChargeRequest
            {
                Amount = 20.5,
                Currency = "EUR",
                Payments = new List<PaymentRequest>()
            };

            //Act
            new ChargeValidator().ValidateAndThrow(charge);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void Validate_Non_ISO_4217_Currency()
        {
            //Arrange
            var charge = new ChargeRequest
            {
                Amount = 20.5,
                Currency = "EURO",
                Payments = new List<PaymentRequest>()
            };

            //Act
            new ChargeValidator().ValidateAndThrow(charge);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void Validate_Non_ISO_4217_Currency_In_Payment()
        {
            //Arrange
            var charge = new ChargeRequest
            {
                Currency = "EUR",
                Payments = new List<PaymentRequest>
                {
                    new IdealPaymentRequest
                    {
                        Currency = "EURO",
                        Details = new IdealDetailsRequest
                        {
                            IssuerId = "RABONL2U",
                            SuccessUrl = "",
                            FailedUrl = "",
                            CancelledUrl = "",
                            ExpiredUrl = "",
                            PurchaseId = Guid.NewGuid().ToString("N"),
                            Description = "Test description."
                        }
                    }
                }
            };

            //Act
            new ChargeValidator().ValidateAndThrow(charge);
        }
    }
}