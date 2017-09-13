using CM.Payments.Client.Model;
using CM.Payments.Client.Validators;
using FluentValidation;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CM.Payments.Client.Test
{
    [TestClass]
    public class ChargeValidationTest
    {
        private readonly ChargeValidator _validate = new ChargeValidator();

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void Validate_WithError()
        {
            //Arrange
            var charge = new ChargeRequest
            {
                Amount = 20.5,
                Currency = "EU",
                Payments = new List<PaymentRequest>()
                {
                    new IdealPaymentRequest()
                    {
                        Amount = 20.5,
                        Currency = "EUR",
                        Details = new IdealDetailsRequest()
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
            _validate.ValidateAndThrow(charge);
        }

        [TestMethod]
        public void Validate_WithoutError()
        {
            _validate.ShouldNotHaveValidationErrorFor(c => c.Currency, "EUR");
        }
    }
}