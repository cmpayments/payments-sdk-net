using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CM.Payments.Client.Model
{
    public sealed class ChargeResponse
    {
        [JsonProperty("charge_id")]
        public string ChargeId { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("amount")]
        public decimal Amount { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
        [JsonProperty("payments")]
        public IEnumerable<PaymentResponse> Payments { get; set; }
    }
}
