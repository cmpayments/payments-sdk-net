using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    [PublicAPI]
    public sealed class SofortPaymentResponse : PaymentResponse
    {
        [JsonProperty("payment_details")]
        public new SofortDetailsResponse Details
        {
            get { return (SofortDetailsResponse) base.Details; }
            set { base.Details = value; }
        }
    }
}