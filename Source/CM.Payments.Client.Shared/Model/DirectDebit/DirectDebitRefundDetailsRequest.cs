using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// In depth details of the direct debit refund request.
    /// </summary>
    [PublicAPI]
    public sealed class DirectDebitRefundDetailsRequest : RefundDetailsRequest
    {
        /// <summary>
        /// Description of the direct debit refund.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}