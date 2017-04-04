using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// Specific details for a Bancontact payment.
    /// </summary>
    [PublicAPI]
    public sealed class BancontactDetailsResponse : BancontactDetailsRequest, IAuthenticatedResponse
    {
        /// <summary>
        /// The issuer for Bancontact.
        /// </summary>
        [JsonProperty("issuer")]
        public string Issuer { get; set; }

        /// <summary>
        /// Masked bancontact card number.
        /// </summary>
        [JsonProperty("masked_pan")]
        public string MaskedPan { get; set; }

        /// <summary>
        /// Explanatory text for the failure. Only present in case of Failure status.
        /// </summary>
        [JsonProperty("reason_for_failure")]
        public string ReasonForFailure { get; set; }

        /// <summary>
        /// URL to where an end-user can execute the payment.
        /// </summary>
        [JsonProperty("authentication_url")]
        public string AuthenticationUrl { get; set; }
    }
}