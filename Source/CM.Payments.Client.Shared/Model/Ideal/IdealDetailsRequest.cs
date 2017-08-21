using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// In depth details of the iDEAL payment request.
    /// </summary>
    [PublicAPI]
    public class IdealDetailsRequest : DetailsRequest
    {
        /// <summary>
        /// Description of the payment.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Unique identifier of the bank.
        /// </summary>
        [JsonProperty("issuer_id")]
        public string IssuerId { get; set; }
    }
}