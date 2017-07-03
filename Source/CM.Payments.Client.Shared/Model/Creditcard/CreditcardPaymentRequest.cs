using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// Details of the credit card payment request.
    /// </summary>
    [PublicAPI]
    public sealed class CreditcardPaymentRequest : PaymentRequest
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("capture")]
        public bool Capture { get; set; }

        /// <summary>
        /// Contains more in depth information about the Payment.
        /// </summary>
        [JsonProperty("payment_details")]
        public CreditcardDetailsRequest Details { get; set; }

        /// <summary>
        /// Payment method used to make the payment.
        /// </summary>
        internal override string Method { get; } = "Creditcard";
    }
}