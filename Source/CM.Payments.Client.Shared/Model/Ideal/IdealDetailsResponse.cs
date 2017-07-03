using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// In depth details of the iDEAL payment response.
    /// </summary>
    [PublicAPI]
    public sealed class IdealDetailsResponse : IdealDetailsRequest, IDetailsResponse
    {
        /// <summary>
        /// URL to where an end-user can execute the payment.
        /// </summary>
        [JsonProperty("authentication_url")]
        public string AuthenticationUrl { get; set; }

        /// <summary>
        /// Name of payer.
        /// </summary>
        [JsonProperty("paid_by_ascript")]
        public string PaidByAscript { get; set; }

        /// <summary>
        /// BIC of bank of payer.
        /// </summary>
        [JsonProperty("paid_by_bic")]
        public string PaidByBic { get; set; }

        /// <summary>
        /// IBAN of payer.
        /// </summary>
        [JsonProperty("paid_by_iban")]
        public string PaidByIban { get; set; }
    }
}