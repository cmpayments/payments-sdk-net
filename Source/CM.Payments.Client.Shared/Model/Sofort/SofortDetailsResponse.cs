using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// In depth details of the SOFORT payment response.
    /// </summary>
    [PublicAPI]
    public sealed class SofortDetailsResponse : SofortDetailsRequest, IDetailsResponse
    {
        /// <summary>
        /// Unique identifier of the transaction.
        /// </summary>
        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }

        /// <summary>
        /// URL to where the end-user can execute the payment.
        /// </summary>
        [JsonProperty("authentication_url")]
        public string AuthenticationUrl { get; set; }
    }
}