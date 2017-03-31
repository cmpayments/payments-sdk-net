using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    [PublicAPI]
    public sealed class SofortDetailsResponse : SofortDetailsRequest, IAuthenticatedResponse
    {
        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }

        [JsonProperty("authentication_url")]
        public string AuthenticationUrl { get; set; }
    }
}