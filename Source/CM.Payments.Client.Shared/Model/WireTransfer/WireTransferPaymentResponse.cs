using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    [PublicAPI]
    public sealed class WireTransferPaymentResponse : PaymentResponse
    {
        [JsonProperty("payment_details")]
        public new WireTransferDetailsResponse Details
        {
            get { return (WireTransferDetailsResponse) base.Details; }
            set { base.Details = value; }
        }
    }
}