using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    [PublicAPI]
    public sealed class CreditcardDetailsResponse : CreditcardDetailsRequest, IAuthenticatedResponse
    {
        [JsonProperty("issuer")]
        public string Issuer { get; set; }

        [JsonProperty("masked_pan")]
        public string MaskedPan { get; set; }

        [JsonProperty("reason_for_failure")]
        public string ReasonForFailure { get; set; }

        [JsonProperty("authentication_url")]
        public string AuthenticationUrl { get; set; }
    }
}