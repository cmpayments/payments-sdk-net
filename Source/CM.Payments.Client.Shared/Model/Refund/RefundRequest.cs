using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// Contains information to make a refund.
    /// </summary>
    [PublicAPI]
    public sealed class RefundRequest
    {
        /// <summary>
        ///     The amount to be refunded
        /// </summary>
        [JsonProperty("amount")]
        public double Amount { get; set; }

        /// <summary>
        ///     Currency of the refunding ISO-4217.
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <summary>
        ///     More details about the refund.
        /// </summary>
        [JsonProperty("refund_details")]
        public RefundDetailsRequest Details { get; set; }

        /// <summary>
        ///     Unique identifier of the payment to refund.
        /// </summary>
        [JsonProperty("payment_id")]
        public string PaymentId { get; set; }

        /// <summary>
        ///     Reason of the refund request.
        /// </summary>
        [JsonProperty("reason")]
        public string Reason { get; set; }
    }
}