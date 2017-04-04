using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// A PayPal payment.
    /// </summary>
    [PublicAPI]
    public sealed class PayPalPaymentRequest : PaymentRequest
    {
        /// <summary>
        ///     Contains more in depth information about the Payment.
        /// </summary>
        [JsonProperty("payment_details")]
        public PayPalDetailsRequest Details { get; set; }

        internal override string Method { get; } = "PayPal";
    }
}