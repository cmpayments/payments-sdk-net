using Newtonsoft.Json;
using System.Collections.Generic;

namespace CM.Payments.Client.Model
{
    public class ChargeRequest
    {
        /// <summary>
        /// Total amount to be paid for the charge.
        /// </summary>
        [JsonProperty("amount")]
        [JsonRequired]
        public double Amount { get; set; }

        /// <summary>
        /// Currency code in ISO-4217 format.
        /// </summary>
        [JsonProperty("currency")]
        [JsonRequired]
        public string Currency { get; set; }

        /// <summary>
        /// List of payments.
        /// </summary>
        [JsonProperty("payments")]
        [JsonRequired]
        public IEnumerable<PaymentRequest> Payments { get; set; }
    }
}
