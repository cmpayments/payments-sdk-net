using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    [PublicAPI]
    public sealed class PayPalPaymentResponse : PaymentResponse
    {
        [JsonProperty("payment_details")]
        public new PayPalDetailsResponse Details
        {
            get { return (PayPalDetailsResponse) base.Details; }
            set { base.Details = value; }
        }
    }
}