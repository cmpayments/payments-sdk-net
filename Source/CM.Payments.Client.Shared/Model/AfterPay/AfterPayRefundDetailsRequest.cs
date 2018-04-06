using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// In depth details of the AfterPay refund request.
    /// </summary>
    [PublicAPI]
    public class AfterPayRefundDetailsRequest : RefundDetailsRequest
    {
        internal override PaymentMethod Method => PaymentMethod.AfterPay;

        /// <summary>
        /// Invoice number for the refund.
        /// </summary>
        [JsonProperty("credit_invoice_number")]
        public string CreditInvoiceNumber { get; set; }
    }
}