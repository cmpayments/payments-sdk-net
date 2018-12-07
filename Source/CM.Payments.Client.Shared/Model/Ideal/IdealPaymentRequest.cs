using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// Details of the iDEAL payment request.
    /// </summary>
    [PublicAPI]
    public sealed class IdealPaymentRequest : PaymentRequest
    {
        internal override PaymentMethod Method { get; } = PaymentMethod.Ideal;

        /// <summary>
        /// Contains more in depth information about the Payment.
        /// </summary>
        [JsonProperty("payment_details")]
        public IdealDetailsRequest Details { get; set; }
    }
}