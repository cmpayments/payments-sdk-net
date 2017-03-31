using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    [PublicAPI]
    public sealed class WireTransferDetailsResponse : WireTransferDetailsRequest, IAuthenticatedResponse
    {
        [JsonProperty("beneficiary_bic")]
        public string BIC { get; set; }

        [JsonProperty("payment_description")]
        public string Description { get; set; }

        [JsonProperty("beneficiary_iban")]
        public string IBAN { get; set; }

        [JsonProperty("beneficiary_name")]
        public string Name { get; set; }

        string IAuthenticatedResponse.AuthenticationUrl { get; set; }
    }
}