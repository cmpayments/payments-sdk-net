using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// In depth details of the Wire Transfer payment response.
    /// </summary>
    [PublicAPI]
    public sealed class WireTransferDetailsResponse : WireTransferDetailsRequest, IDetailsResponse
    {
        /// <summary>
        /// URL to where an end-user can execute the payment.
        /// </summary>
        [JsonProperty("authentication_url")]
        public string AuthenticationUrl { get; set; }

        /// <summary>
        /// Unique identification code of the financial institution linked to the IBAN.
        /// </summary>
        [JsonProperty("beneficiary_bic")]
        public string BIC { get; set; }

        /// <summary>
        /// A unique (short) code that the end-user has to use as description by the transaction.
        /// </summary>
        [JsonProperty("payment_description")]
        public string Description { get; set; }

        /// <summary>
        /// Value of the used IBAN.
        /// </summary>
        [JsonProperty("beneficiary_iban")]
        public string IBAN { get; set; }

        /// <summary>
        /// Name of the holder of the IBAN
        /// </summary>
        [JsonProperty("beneficiary_name")]
        public string Name { get; set; }
    }
}