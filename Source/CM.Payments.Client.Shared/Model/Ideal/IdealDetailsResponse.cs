using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    [PublicAPI]
    public sealed class IdealDetailsResponse : IdealDetailsRequest, IAuthenticatedResponse
    {
        /// <summary>
        /// Name of the payer.
        /// </summary>
        [JsonProperty("paid_by_ascript")]
        public string PaidByAscript { get; set; }

        /// <summary>
        /// BIC of the payer.
        /// </summary>
        [JsonProperty("paid_by_bic")]
        public string PaidByBic { get; set; }

        /// <summary>
        /// IBAN of the payer
        /// </summary>
        [JsonProperty("paid_by_iban")]
        public string PaidByIban { get; set; }

        /// <summary>
        /// URL to where an end-user can execute the payment.
        /// </summary>
        [JsonProperty("authentication_url")]
        public string AuthenticationUrl { get; set; }
    }
}