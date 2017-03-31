using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    [PublicAPI]
    public sealed class CreditcardPaymentResponse : PaymentResponse
    {
        [JsonProperty("payment_details")]
        public new CreditcardDetailsResponse Details
        {
            get { return (CreditcardDetailsResponse) base.Details; }
            set { base.Details = value; }
        }
    }
}