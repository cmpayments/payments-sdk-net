using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// Specific details about a credit card payment.
    /// </summary>
    [PublicAPI]
    public sealed class CreditcardDetailsResponse : CreditcardDetailsRequest, IAuthenticatedResponse
    {
        /// <summary>
        /// Issuer for Creditcard.
        /// </summary>
        [JsonProperty("issuer")]
        public string Issuer { get; set; }

        /// <summary>
        /// Masked credit card number.
        /// </summary>
        [JsonProperty("masked_pan")]
        public string MaskedPan { get; set; }

        /// <summary>
        /// Explanatory text for failure.
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