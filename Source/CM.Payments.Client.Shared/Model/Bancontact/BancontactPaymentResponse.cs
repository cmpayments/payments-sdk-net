using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    [PublicAPI]
    public sealed class BancontactPaymentResponse : PaymentResponse
    {
        [JsonProperty("payment_details")]
        public new BancontactDetailsResponse Details
        {
            get { return (BancontactDetailsResponse) base.Details; }
            set { base.Details = value; }
        }
    }
}