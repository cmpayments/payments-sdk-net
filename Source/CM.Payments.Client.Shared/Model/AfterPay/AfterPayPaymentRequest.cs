using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// An AfterPay payment.
    /// </summary>
    [PublicAPI]
    public sealed class AfterPayPaymentRequest : PaymentRequest
    {
        /// <summary>
        ///     Details for a AfterPay payment.
        /// </summary>
        [JsonProperty("payment_details")]
        public AfterPayDetailsRequest Details { get; set; }

        internal override string Method { get; } = "AfterPay";
    }
}