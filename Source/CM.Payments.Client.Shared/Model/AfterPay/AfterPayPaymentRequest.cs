using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// Details of the AfterPay payment request.
    /// </summary>
    [PublicAPI]
    public sealed class AfterPayPaymentRequest : PaymentRequest
    {
        internal override PaymentMethod Method { get; } = PaymentMethod.AfterPay;

        /// <summary>
        /// Contains more in depth information about the Payment.
        /// </summary>
        [JsonProperty("payment_details")]
        public AfterPayDetailsRequest Details { get; set; }
    }
}