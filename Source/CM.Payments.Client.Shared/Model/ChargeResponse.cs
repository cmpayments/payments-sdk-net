using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// Details of the charge response.
    /// </summary>
    public sealed class ChargeResponse
    {
        /// <summary>
        /// Total amount to be paid for the charge.
        /// </summary>
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// Unique identifier of the charge.
        /// </summary>
        [JsonProperty("charge_id")]
        public string ChargeId { get; set; }

        /// <summary>
        /// Date and time the charge is created.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Currency code in ISO-4217 format.
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// List with linked payments.
        /// </summary>
        [JsonProperty("payments")]
        public IEnumerable<PaymentResponse> Payments { get; set; }

        /// <summary>
        /// Status of the charge.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Date and time the charge is updated.
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}