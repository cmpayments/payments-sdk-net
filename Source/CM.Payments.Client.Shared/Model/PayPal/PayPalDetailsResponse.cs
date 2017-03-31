using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    [PublicAPI]
    public sealed class PayPalDetailsResponse : PayPalDetailsRequest, IAuthenticatedResponse
    {
        [JsonProperty("fee_amount")]
        public string Amount { get; set; }

        [JsonProperty("payer_city")]
        public string City { get; set; }

        [JsonProperty("fee_currency")]
        public string Currency { get; set; }

        [JsonProperty("payer_email")]
        public string Email { get; set; }

        [JsonProperty("payer_first_name")]
        public string Firstname { get; set; }

        [JsonProperty("payer_last_name")]
        public string Lastname { get; set; }

        [JsonProperty("authentication_url")]
        public string AuthenticationUrl { get; set; }
    }
}