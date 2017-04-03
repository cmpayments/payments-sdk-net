using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CM.Payments.Client.Model
{
    public sealed class ChargeResponse
    {
        /// <summary>
        /// Unique ID of the charge.
        /// </summary>
        [JsonProperty("charge_id")]
        public string ChargeId { get; set; }
        /// <summary>
        /// The status of the charge. Can be: Open, Expired, Failed , Success or Cancelled.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }
        /// <summary>
        /// 	The amount for the charge.
        /// </summary>
        [JsonProperty("amount")]
        public decimal Amount { get; set; }
        /// <summary>
        /// 	Currency used for the charge in ISO-4217 format.
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }
        /// <summary>
        /// Date of creation.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// Date of update.
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
        /// <summary>
        /// List of payments.
        /// </summary>
        [JsonProperty("payments")]
        public IEnumerable<PaymentResponse> Payments { get; set; }
    }
}
