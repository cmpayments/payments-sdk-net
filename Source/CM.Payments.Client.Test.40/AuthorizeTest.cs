using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            const string expectedSignature = "ZjJhMjBmZDFhOTU0NWEwMGJhMTUwYjI4ZTZhYzJlZDgxMjU5MGQ0ZDBkNTM2MGQ4OGVmY2RkMzkwMjY1MGNjZg==";

            //Act
            var actualSignature = new OAuth("xvz1evFS4wEEPTGEFPHBog", "LswwdoUaIvS8ltyTt5jkRh4J50vUPVVHtR2YPi5kE")
                .GenerateSignature("GET", "https://api.cmpayments.com/charges/v1?exampleParameter=value", "", timestamp, nonce);

            //Assert
            Assert.AreEqual(expectedSignature, actualSignature);
        }

        [TestMethod]
        public void AuthorizeWithDataInBody()
        {
            //Arrage
            const string nonce = "32f3c8c2b06e96ec8e19eb4d39672720";
            const string timestamp = "1443539180";
            const string json = "{\"amount\":15.95,\"currency\":\"EUR\",\"payments\":[{\"payment_details\":{\"cancelled_url\":\"\",\"description\":\"Test description\",\"expired_url\":\"\",\"failed_url\":\"\",\"issuer_id\":\"INGBNL2A\",\"purchase_id\":\"e90b4be7b95c48ccaeafe64193bc1ebc\",\"success_url\":\"\"},\"payment_method\":\"iDEAL\",\"amount\":15.95,\"due_date\":null,\"currency\":\"EUR\"}]}";
            const string expectedSignature = "MzcxYjUyZTBkZGE1YjYwOTA2MmExMzRmMGU2OTkzYWZmODVlNjgwOGU2MzgyYmNkNDI5ZmFmZDQwYTAwMGU3Nw==";
            
            //Act
            var actualSignature = new OAuth("xvz1evFS4wEEPTGEFPHBog", "LswwdoUaIvS8ltyTt5jkRh4J50vUPVVHtR2YPi5kE")
                .GenerateSignature("POST", "https://api.cmpayments.com/charges/v1?exampleParameter=value", json, timestamp, nonce);

            //Assert
            Assert.AreEqual(expectedSignature, actualSignature);
        }
    }
}