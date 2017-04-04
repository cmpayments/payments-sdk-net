using System;
using CM.Payments.Client.Converters;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// A Wire Transfer payment.
    /// </summary>
    [PublicAPI]
    public sealed class WireTransferPaymentRequest : PaymentRequest
    {
        /// <summary>
        ///     Contains more in depth information about the Payment.
        /// </summary>
        [JsonProperty("payment_details")]
        public WireTransferDetailsRequest Details { get; set; }

        /// <summary>
        ///     Expiration date of the payment.
        /// </summary>
        [JsonProperty("expires_at")]
        [JsonConverter(typeof(UtcDateTimeConverter))]
        public DateTime ExpiredAt { get; set; }

        internal override string Method { get; } = "WireTransfer";
    }
}