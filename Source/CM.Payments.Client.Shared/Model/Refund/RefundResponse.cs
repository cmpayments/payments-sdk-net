using System;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    public sealed class RefundResponse
    {
        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("refund_details")]
        public RefundDetailsResponse Details { get; set; }

        [JsonProperty("payment_id")]
        public string PaymentId { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("refund_id")]
        public string RefundId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("test")]
        public bool Test { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}