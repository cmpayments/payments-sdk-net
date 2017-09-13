using JetBrains.Annotations;
using Newtonsoft.Json;
using System;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// Details of the payment request.
    /// </summary>
    public abstract class PaymentRequest
    {
        /// <summary>
        /// Payment method used to make the payment.
        /// </summary>
        [JsonProperty("payment_method")]
        [UsedImplicitly]
        internal abstract string Method { get; }

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
    }
}