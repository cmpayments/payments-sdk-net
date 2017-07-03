using CM.Payments.Client.Converters;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// In depth details of the refund response.
    /// </summary>
    [JsonConverter(typeof(RefundConverter))]
    public sealed class RefundDetailsResponse
    {
        /// <summary>
        /// Unique reference of the credit bank transaction.
        /// </summary>
        [JsonProperty("credit_transaction_reference")]
        public string CreditTransactionReference { get; set; }

        /// <summary>
        /// Status of the credit bank transaction.
        /// </summary>
        [JsonProperty("credit_transaction_status")]
        public string CreditTransactionStatus { get; set; }

        /// <summary>
        /// Unique reference of the debit bank transaction.
        /// </summary>
        [JsonProperty("debit_transaction_reference")]
        public string DebitTransactionReference { get; set; }

        /// <summary>
        /// Status of the debit bank transaction.
        /// </summary>
        [JsonProperty("debit_transaction_status")]
        public string DebitTransactionStatus { get; set; }

        /// <summary>
        /// Purchase identifier related to refund.
        /// </summary>
        [JsonProperty("purchase_id")]
        public string PurchaseId { get; set; }

        /// <summary>
        /// BIC of the refund IBAN.
        /// </summary>
        [JsonProperty("refund_bic")]
        public string RefundBic { get; set; }

        /// <summary>
        /// IBAN of the refund.
        /// </summary>
        [JsonProperty("refund_iban")]
        public string RefundIban { get; set; }

        /// <summary>
        /// Name of the end-user.
        /// </summary>
        [JsonProperty("refund_name")]
        public string RefundName { get; set; }
    }
}