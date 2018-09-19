using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// Details of the direct debit payment response.
    /// </summary>
    [PublicAPI]
    public sealed class DirectDebitPaymentResponse : PaymentResponse
    {
        internal override PaymentMethod Method => PaymentMethod.DirectDebit;

        /// <summary>
        /// In depth details of the direct debit response.
        /// </summary>
        [JsonProperty("payment_details")]
        public new DirectDebitDetailsResponse Details
        {
            get => (DirectDebitDetailsResponse)base.Details;
            set => base.Details = value;
        }
    }
}