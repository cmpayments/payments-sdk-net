using System;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// Contains information about a refund when it's received from the server.
    /// </summary>
    public sealed class RefundResponse
    {
        /// <summary>
        ///     The amount to be refunded.
        /// </summary>
        [JsonProperty("amount")]
        public double Amount { get; set; }

        /// <summary>
        /// Date of creation.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        ///     Currency of the refunding ISO-4217.
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <summary>
        ///     More details about the refund.
        /// </summary>
        [JsonProperty("refund_details")]
        public RefundDetailsResponse Details { get; set; }

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

        /// <summary>
        /// Unique identifier of the refund.
        /// </summary>
        [JsonProperty("refund_id")]
        public string RefundId { get; set; }

        /// <summary>
        /// Status of the refund. Can be Succeeded, Failed or Pending
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Test flag for refund.
        /// </summary>
        [JsonProperty("test")]
        public bool Test { get; set; }

        /// <summary>
        /// Date of update.
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}