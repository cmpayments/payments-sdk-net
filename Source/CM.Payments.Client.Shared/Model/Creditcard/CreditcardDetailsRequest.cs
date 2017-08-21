using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// In depth details of the credit card payment request.
    /// </summary>
    [PublicAPI]
    public class CreditcardDetailsRequest : DetailsRequest
    {
        /// <summary>
        /// MasterCard, VISA. If omitted all issuers will be available on the paypage.
        /// </summary>
        [JsonProperty("issuers", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Issuers { get; set; }

        /// <summary>
        /// Whether a recurring payment needs to be created, or not.
        /// </summary>
        [JsonProperty("recurring", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Recurring { get; set; }
    }
}