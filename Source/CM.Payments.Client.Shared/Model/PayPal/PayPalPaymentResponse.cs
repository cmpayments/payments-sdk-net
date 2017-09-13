using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// Details of the PayPal payment response.
    /// </summary>
    [PublicAPI]
    public sealed class PayPalPaymentResponse : PaymentResponse
    {
        /// <summary>
        /// In depth details of the PayPal response.
        /// </summary>
        [JsonProperty("payment_details")]
        public new PayPalDetailsResponse Details
        {
            get => (PayPalDetailsResponse) base.Details;
            set => base.Details = value;
        }
    }
}