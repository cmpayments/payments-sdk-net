using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    [PublicAPI]
    public sealed class IdealPaymentResponse : PaymentResponse
    {
        [JsonProperty("payment_details")]
        public new IdealDetailsResponse Details
        {
            get { return (IdealDetailsResponse) base.Details; }
            set { base.Details = value; }
        }
    }
}