using CM.Payments.Client.Converters;
using JetBrains.Annotations;
using Newtonsoft.Json;
using System;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// Details of the payment request.
    /// </summary>
    [JsonConverter(typeof(PaymentRequestConverter))]
    public abstract class PaymentRequest
    {
        /// <summary>
        /// Payment method used to make the payment.
        /// </summary>
        [UsedImplicitly, JsonProperty("payment_method")]
        internal abstract PaymentMethod Method { get; }

        /// <summary>
        /// Amount of the payment.
        /// </summary>
        [JsonProperty("amount")]
        public double Amount { get; set; }

        /// <summary>
        /// Date of expiration for the payment.
        /// </summary>
        [JsonProperty("due_date")]
        public DateTime? DueDate { get; set; }

        /// <summary>
        /// Currency code in ISO-4217 format.
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// Whether the payment is a recurring payment, or not.
        /// </summary>
        [JsonProperty("recurring")]
        public bool Recurring { get; set; }

        /// <summary>
        /// Unique identifier of the recurring payment.
        /// </summary>
        /// <remarks>Can be empty when it is the first of a recurring payment.</remarks>
        [JsonProperty("recurring_id")]
        public string RecurringId { get; set; }
    }
}