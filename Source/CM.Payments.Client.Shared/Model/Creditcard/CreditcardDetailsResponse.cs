using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// In depth details of the credit card payment response.
    /// </summary>
    [PublicAPI]
    public sealed class CreditcardDetailsResponse : CreditcardDetailsRequest, IDetailsResponse
    {
        /// <summary>
        /// URL to where an end-user can execute the payment.
        /// </summary>
        [JsonProperty("authentication_url")]
        public string AuthenticationUrl { get; set; }

        /// <summary>
        /// Brand of the credit card.
        /// </summary>
        [JsonProperty("issuer")]
        public string Issuer { get; set; }

        /// <summary>
        /// Masked creditcard number.
        /// </summary>
        [JsonProperty("masked_pan")]
        public string MaskedPan { get; set; }

        /// <summary>
        /// Explanatory text for failure
        /// </summary>
        [JsonProperty("reason_for_failure")]
        public string ReasonForFailure { get; set; }
    }
}