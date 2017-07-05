using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// In depth details of the direct debit payment response.
    /// </summary>
    [PublicAPI]
    public sealed class DirectDebitDetailsResponse : DirectDebitDetailsRequest, IDetailsResponse
    {
        /// <summary>
        /// Unique identifier of the bank transaction.
        /// </summary>
        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }
    }
}