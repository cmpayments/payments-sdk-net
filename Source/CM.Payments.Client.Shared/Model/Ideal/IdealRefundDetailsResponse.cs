using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    [PublicAPI]
    public sealed class IdealRefundDetailsResponse : RefundDetailsResponse
    {
        [JsonProperty("credit_transaction_reference")]
        public string CreditTransactionReference { get; set; }

        [JsonProperty("credit_transaction_status")]
        public string CreditTransactionStatus { get; set; }

        [JsonProperty("debit_transaction_reference")]
        public string DebitTransactionReference { get; set; }

        [JsonProperty("debit_transaction_status")]
        public string DebitTransactionStatus { get; set; }

        [JsonProperty("purchase_id")]
        public string PurchaseId { get; set; }

        [JsonProperty("refund_bic")]
        public string RefundBic { get; set; }

        [JsonProperty("refund_iban")]
        public string RefundIban { get; set; }

        [JsonProperty("refund_name")]
        public string RefundName { get; set; }
    }
}