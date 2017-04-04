using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// Specific details about a Wire Transfer payment.
    /// </summary>
    [PublicAPI]
    public sealed class WireTransferDetailsResponse : WireTransferDetailsRequest, IAuthenticatedResponse
    {
        /// <summary>
        /// Unique identification code for a financial institution. This is the	BIC-code of the IBAN that CM-Payments is using. This bank-code has to be used for transfers outside the Netherlands.
        /// </summary>
        [JsonProperty("beneficiary_bic")]
        public string BIC { get; set; }

        /// <summary>
        /// 	A unique (short) code that the end-user has to use as description by the transaction. The length could vary over time.
        /// </summary>
        [JsonProperty("payment_description")]
        public string Description { get; set; }

        /// <summary>
        /// The IBAN of CM-Payments to send money to.
        /// </summary>
        [JsonProperty("beneficiary_iban")]
        public string IBAN { get; set; }

        /// <summary>
        /// The name of the holder of the IBAN.
        /// </summary>
        [JsonProperty("beneficiary_name")]
        public string Name { get; set; }

        /// <summary>
        /// URL to where an end-user can execute the payment.
        /// </summary>
        string IAuthenticatedResponse.AuthenticationUrl { get; set; }
    }
}