using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// In depth details of the Bancontact payment response.
    /// </summary>
    [PublicAPI]
    public sealed class BancontactDetailsResponse : BancontactDetailsRequest, IDetailsResponse
    {
        /// <summary>
        /// URL to where an end-user can execute the payment.
        /// </summary>
        [JsonProperty("authentication_url")]
        public string AuthenticationUrl { get; set; }

        /// <summary>
        /// Brand of the Bancontact.
        /// </summary>
        [JsonProperty("issuer")]
        public string Issuer { get; set; }

        /// <summary>
        /// Masked Bancontact cardnumber.
        /// </summary>
        [JsonProperty("masked_pan")]
        public string MaskedPan { get; set; }

        /// <summary>
        /// Explanatory text for failure.
        /// </summary>
        [JsonProperty("reason_for_failure")]
        public string ReasonForFailure { get; set; }
    }
}