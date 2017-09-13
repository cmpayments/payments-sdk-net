using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// Details of the PayPal payment request.
    /// </summary>
    [PublicAPI]
    public sealed class PayPalPaymentRequest : PaymentRequest
    {
        /// <summary>
        /// Contains more in depth information about the Payment.
        /// </summary>
        [JsonProperty("payment_details")]
        public PayPalDetailsRequest Details { get; set; }

        /// <summary>
        /// Payment method used to make the payment.
        /// </summary>
        internal override string Method { get; } = "PayPal";
    }
}