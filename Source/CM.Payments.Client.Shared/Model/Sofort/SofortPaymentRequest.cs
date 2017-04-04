using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// A SOFORT payment.
    /// </summary>
    [PublicAPI]
    public sealed class SofortPaymentRequest : PaymentRequest
    {
        /// <summary>
        ///     Contains more in depth information about the Payment.
        /// </summary>
        [JsonProperty("payment_details")]
        public SofortDetailsRequest Details { get; set; }

        internal override string Method { get; } = "SOFORT";
    }
}