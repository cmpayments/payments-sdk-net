using System;
using CM.Payments.Client.Converters;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    /// <summary>
    ///     Base class for a payment response
    /// </summary>
    [JsonConverter(typeof(PaymentConverter))]
    public abstract class PaymentResponse
    {
        internal PaymentResponse()
        {
        }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("charge_id")]
        public string ChargeId { get; set; }

        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonIgnore]
        public IAuthenticatedResponse Details { get; set; }

        [JsonProperty("due_date", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime DueDate { get; set; }

        [JsonProperty("expires_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime ExpiresAt { get; set; }

        [JsonProperty("payment_method")]
        public string Method { get; set; }

        [JsonProperty("payment_id")]
        public string PaymentId { get; set; }

        [JsonProperty("short_payment_id")]
        public string ShortPaymentId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("test")]
        public bool Test { get; set; }

        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime UpdatedAt { get; set; }
    }
}