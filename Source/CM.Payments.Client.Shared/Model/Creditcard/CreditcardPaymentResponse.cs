using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// Details of the credit card payment response.
    /// </summary>
    [PublicAPI]
    public sealed class CreditcardPaymentResponse : PaymentResponse
    {
        /// <summary>
        /// In depth details of the credit card response.
        /// </summary>
        [JsonProperty("payment_details")]
        public new CreditcardDetailsResponse Details
        {
            get => (CreditcardDetailsResponse) base.Details;
            set => base.Details = value;
        }
    }
}