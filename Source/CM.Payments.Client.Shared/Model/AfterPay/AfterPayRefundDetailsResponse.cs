using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// Details for an AfterPay refund.
    /// </summary>
    [PublicAPI]
    public class AfterPayRefundDetailsResponse : RefundDetailsResponse
    {
        /// <summary>
        ///     Invoice number for the refund.
        /// </summary>
        [JsonProperty("credit_invoice_number")]
        public string CreditInvoiceNumber { get; set; }
    }
}