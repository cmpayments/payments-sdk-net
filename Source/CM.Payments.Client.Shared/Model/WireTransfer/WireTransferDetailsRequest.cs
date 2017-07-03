using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// In depth details of the Wire Transfer payment request.
    /// </summary>
    [PublicAPI]
    public class WireTransferDetailsRequest : DetailsRequest
    {
        /// <summary>
        /// Unique identifier as reference for the merchant.
        /// </summary>
        [JsonProperty("purchase_id")]
        public string PurchaseId { get; set; }
    }
}