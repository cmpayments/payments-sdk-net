using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// An iDeal payment.
    /// </summary>
    [PublicAPI]
    public sealed class IdealPaymentRequest : PaymentRequest
    {
        /// <summary>
        ///     Contains more in depth information about the Payment.
        /// </summary>
        [JsonProperty("payment_details")]
        public IdealDetailsRequest Details { get; set; }

        internal override string Method { get; } = "iDEAL";
    }
}