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
        internal override PaymentMethod Method { get; } = PaymentMethod.PayPal;

        /// <summary>
        /// Contains more in depth information about the Payment.
        /// </summary>
        [JsonProperty("payment_details")]
        public PayPalDetailsRequest Details { get; set; }        
    }
}