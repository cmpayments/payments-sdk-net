using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CM.Payments.Client.Model;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CM.Payments.Client.Test._40
{
    [TestClass]
    public class AuthorizeTest
    {
        [TestMethod]
        public void AuthorizeWithoutDataInBody()
        {
            //Arrange
            const string nonce = "32f3c8c2b06e96ec8e19eb4d39672720";
            const string timestamp = "1443539180";
            var auth = new OAuth("xvz1evFS4wEEPTGEFPHBog", "LswwdoUaIvS8ltyTt5jkRh4J50vUPVVHtR2YPi5kE");
            const string expectedSignature = "ZjJhMjBmZDFhOTU0NWEwMGJhMTUwYjI4ZTZhYzJlZDgxMjU5MGQ0ZDBkNTM2MGQ4OGVmY2RkMzkwMjY1MGNjZg==";

            //Act
            var actualSignature = auth.GenerateSignature("GET", "https://api.cmpayments.com/charges/v1?exampleParameter=value", "", timestamp, nonce);

            //Assert
            Assert.AreEqual(expectedSignature, actualSignature);
        }

        [TestMethod]
        public void AuthorizeWithDataInBody()
        {

            //Arrage
            const string nonce = "32f3c8c2b06e96ec8e19eb4d39672720";
            const string timestamp = "1443539180";
            var charge = new ChargeRequest
            {
                Amount = 15.95,
                Currency = "EUR",
                Payments = new List<PaymentRequest>()
                {
                    new IdealPaymentRequest {
                        Amount = 15.95,
                        Currency = "EUR",
                        Details = new IdealDetailsRequest
                        {
                            IssuerId = "INGBNL2A",
                            SuccessUrl = "",
                            FailedUrl = "",
                            CancelledUrl = "",
                            ExpiredUrl = "",
                            PurchaseId = "e90b4be7b95c48ccaeafe64193bc1ebc",
                            Description = "Test description"
                        }
                    }
                }
            };
            var json = JsonConvert.SerializeObject(charge);
            var auth = new OAuth("xvz1evFS4wEEPTGEFPHBog", "LswwdoUaIvS8ltyTt5jkRh4J50vUPVVHtR2YPi5kE");
            const string expectedSignature = "MzcxYjUyZTBkZGE1YjYwOTA2MmExMzRmMGU2OTkzYWZmODVlNjgwOGU2MzgyYmNkNDI5ZmFmZDQwYTAwMGU3Nw==";

            //Act
            var actualSignature = auth.GenerateSignature("POST", "https://api.cmpayments.com/charges/v1?exampleParameter=value", json, timestamp, nonce);

            //Assert
            Assert.AreEqual(expectedSignature, actualSignature);
        }
    }
}
