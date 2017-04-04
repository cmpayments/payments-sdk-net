using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// A credit card payment.
    /// </summary>
    [PublicAPI]
    public sealed class CreditcardPaymentResponse : PaymentResponse
    {
        /// <summary>
        /// Details about the Creditcard payment.
        /// </summary>
        [JsonProperty("payment_details")]
        public new CreditcardDetailsResponse Details
        {
            get { return (CreditcardDetailsResponse) base.Details; }
            set { base.Details = value; }
        }
    }
}