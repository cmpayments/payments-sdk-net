using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// Specific details for a SOFORT payment.
    /// </summary>
    [PublicAPI]
    public class SofortDetailsRequest : DetailsRequest
    {
        /// <summary>
        ///     IBAn of customer bank account.
        /// </summary>
        [JsonProperty("bank_account_number")]
        public string BankAccountNumber { get; set; }

        /// <summary>
        ///     BIC of customer bank.
        /// </summary>
        [JsonProperty("bank_bic")]
        public string BankBic { get; set; }

        /// <summary>
        ///     URL that will be used to call the backend of a merchant when the status has changed.
        /// </summary>
        [JsonProperty("callback_url", NullValueHandling = NullValueHandling.Ignore)]
        public string CallbackUrl { get; set; }

        /// <summary>
        ///     URL that will be used when the payment is cancelled.
        /// </summary>
        [JsonProperty("cancelled_url", NullValueHandling = NullValueHandling.Ignore)]
        public string CancelledUrl { get; set; }

        /// <summary>
        ///     Name of the customer.
        /// </summary>
        [JsonProperty("consumer_name")]
        public string ConsumerName { get; set; }

        /// <summary>
        ///     Description of the payment.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        ///     URL that will be used when the payment is expired.
        /// </summary>
        [JsonProperty("expired_url", NullValueHandling = NullValueHandling.Ignore)]
        public string ExpiredUrl { get; set; }

        /// <summary>
        ///     URL that will be used when the payment failed.
        /// </summary>
        [JsonProperty("failed_url", NullValueHandling = NullValueHandling.Ignore)]
        public string FailedUrl { get; set; }

        /// <summary>
        ///     Unique identifier as reference for the merchant.
        /// </summary>
        [JsonProperty("purchase_id")]
        public string PurchaseId { get; set; }

        /// <summary>
        ///     URL that will be used when the payment is completed.
        /// </summary>
        [JsonProperty("success_url", NullValueHandling = NullValueHandling.Ignore)]
        public string SuccessUrl { get; set; }
    }
}