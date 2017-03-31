using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    [PublicAPI]
    public sealed class IdealDetailsResponse : IdealDetailsRequest, IAuthenticatedResponse
    {
        [JsonProperty("paid_by_ascript")]
        public string PaidByAscript { get; set; }

        [JsonProperty("paid_by_bic")]
        public string PaidByBic { get; set; }

        [JsonProperty("paid_by_iban")]
        public string PaidByIban { get; set; }

        [JsonProperty("authentication_url")]
        public string AuthenticationUrl { get; set; }
    }
}