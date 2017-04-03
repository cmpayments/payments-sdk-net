using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    [PublicAPI]
    public sealed class IdealRefundDetailsResponse : RefundDetailsResponse
    {
        /// <summary>
        /// ID for the credit transaction.
        /// </summary>
        [JsonProperty("credit_transaction_reference")]
        public string CreditTransactionReference { get; set; }

        /// <summary>
        /// Status of the credit transaction.
        /// </summary>
        [JsonProperty("credit_transaction_status")]
        public string CreditTransactionStatus { get; set; }

        /// <summary>
        /// ID for the debit transaction.
        /// </summary>
        [JsonProperty("debit_transaction_reference")]
        public string DebitTransactionReference { get; set; }

        /// <summary>
        /// Status of the debit transaction.
        /// </summary>
        [JsonProperty("debit_transaction_status")]
        public string DebitTransactionStatus { get; set; }

        /// <summary>
        /// Purchase ID related to the refund.
        /// </summary>
        [JsonProperty("purchase_id")]
        public string PurchaseId { get; set; }

        /// <summary>
        /// BIC of the bank.
        /// </summary>
        [JsonProperty("refund_bic")]
        public string RefundBic { get; set; }

        /// <summary>
        /// Bank account number.
        /// </summary>
        [JsonProperty("refund_iban")]
        public string RefundIban { get; set; }

        /// <summary>
        /// Name related to the bank account.
        /// </summary>
        [JsonProperty("refund_name")]
        public string RefundName { get; set; }
    }
}