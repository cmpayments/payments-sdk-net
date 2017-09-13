using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// In depth details of the Sofort payment request.
    /// </summary>
    [PublicAPI]
    public class SofortDetailsRequest : DetailsRequest
    {
        /// <summary>
        /// IBAN of customer bank account.
        /// </summary>
        [JsonProperty("bank_account_number")]
        public string BankAccountNumber { get; set; }

        /// <summary>
        /// BIC of customer bank.
        /// </summary>
        [JsonProperty("bank_bic")]
        public string BankBic { get; set; }

        /// <summary>
        /// Name of the customer.
        /// </summary>
        [JsonProperty("consumer_name")]
        public string ConsumerName { get; set; }

        /// <summary>
        /// Description of the payment.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}