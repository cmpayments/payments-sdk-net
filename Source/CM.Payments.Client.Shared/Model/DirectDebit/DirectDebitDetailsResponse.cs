using JetBrains.Annotations;
using Newtonsoft.Json;
using System;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// In depth details of the direct debit payment response.
    /// </summary>
    [PublicAPI]
    public sealed class DirectDebitDetailsResponse : DirectDebitDetailsRequest, IDetailsResponse
    {
        /// <summary>
        /// URL to where an end-user can execute the payment.
        /// </summary>
        [JsonProperty("authentication_url")]
        public string AuthenticationUrl { get; set; }

        /// <summary>
        /// Date and time at which the transaction is reversed.
        /// </summary>
        [JsonProperty("reversed_on")]
        public DateTime? ReversedOn { get; set; }

        /// <summary>
        /// SEPA return reason code of the reversed transaction.
        /// </summary>
        [JsonProperty("reverse_reason_code")]
        public string ReverseReasonCode { get; set; }

        /// <summary>
        /// Description of the SEPA return reason code.
        /// </summary>
        [JsonProperty("reverse_reason_description")]
        public string ReverseReasonDescription { get; set; }

        /// <summary>
        /// Unique identifier of the bank transaction.
        /// </summary>
        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }
    }
}