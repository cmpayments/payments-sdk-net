using CM.Payments.Client.Converters;
using JetBrains.Annotations;
using Newtonsoft.Json;
using System;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// In depth details of the direct debit request.
    /// </summary>
    [PublicAPI]
    public class DirectDebitDetailsRequest : DetailsRequest
    {
        /// <summary>
        /// IBAN of the end user.
        /// </summary>
        [JsonProperty("bank_account_number")]
        public string BankAccountNumber { get; set; }

        /// <summary>
        /// Description of the direct debit payment.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Unique identification of the mandate.
        /// </summary>
        [JsonProperty("mandate_id")]
        public string MandateId { get; set; }

        /// <summary>
        /// Date at which the mandate was obtained.
        /// </summary>
        [JsonProperty("mandate_start_date")]
        [JsonConverter(typeof(DateConverter))]
        public DateTime MandateStartDate { get; set; }

        /// <summary>
        /// Name of the end-user.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        
        /// <summary>
        /// Unique identifier as reference for the merchant.
        /// </summary>
        [JsonProperty("purchase_id")]
        public string PurchaseId { get; set; }

        /// <summary>
        /// Optional description that will be shown on the end user their bank statement.
        /// </summary>
        /// <remarks>
        /// If transaction_description is not provided, description will be used.
        /// </remarks>
        [JsonProperty("transaction_description")]
        public string TransactionDescription { get; set; }
    }
}