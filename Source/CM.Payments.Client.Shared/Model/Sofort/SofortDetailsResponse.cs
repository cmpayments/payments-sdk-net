using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// Specific details for a SOFORT payment.
    /// </summary>
    [PublicAPI]
    public sealed class SofortDetailsResponse : SofortDetailsRequest, IAuthenticatedResponse
    {
        /// <summary>
        /// Description of the transaction.
        /// </summary>
        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }

        /// <summary>
        /// URL to where an end-user can execute the payment.
        /// </summary>
        [JsonProperty("authentication_url")]
        public string AuthenticationUrl { get; set; }
    }
}