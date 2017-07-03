using CM.Payments.Client.Converters;
using Newtonsoft.Json;
using System;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// Details of the payment response.
    /// </summary>
    [JsonConverter(typeof(PaymentConverter))]
    public abstract class PaymentResponse
    {
        internal PaymentResponse()
        {
        }

        /// <summary>
        /// Amount of the payment.
        /// </summary>
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// Unique identifier of the charge object linked to the payment object.
        /// </summary>
        [JsonProperty("charge_id")]
        public string ChargeId { get; set; }

        /// <summary>
        /// Creation date of the payment.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Currency of the payment in ISO-4217 format.
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// In depth details of the payment response.
        /// </summary>
        [JsonIgnore]
        public IDetailsResponse Details { get; set; }

        /// <summary>
        /// Expiration date of the payment.
        /// </summary>
        [JsonProperty("due_date", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime DueDate { get; set; }

        /// <summary>
        /// The maximum date of paying this transaction.
        /// </summary>
        [JsonProperty("expires_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime ExpiresAt { get; set; }

        /// <summary>
        /// Payment method used to make the payment.
        /// </summary>
        [JsonProperty("payment_method")]
        public string Method { get; set; }

        /// <summary>
        /// Unique identifier of the payment object.
        /// </summary>
        [JsonProperty("payment_id")]
        public string PaymentId { get; set; }

        /// <summary>
        /// Short unique identifier of the payment object.
        /// </summary>
        [JsonProperty("short_payment_id")]
        public string ShortPaymentId { get; set; }

        /// <summary>
        /// Status of the payment.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Indication if the payment is created in test modus.
        /// </summary>
        [JsonProperty("test")]
        public bool Test { get; set; }

        /// <summary>
        /// Update date of the payment.
        /// </summary>
        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime UpdatedAt { get; set; }
    }
}