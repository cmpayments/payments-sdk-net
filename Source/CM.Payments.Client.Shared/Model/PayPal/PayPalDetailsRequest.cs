using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// In depth details of the PayPal payment request.
    /// </summary>
    [PublicAPI]
    public class PayPalDetailsRequest : DetailsRequest
    {
        /// <summary>
        /// Description of the payment.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}