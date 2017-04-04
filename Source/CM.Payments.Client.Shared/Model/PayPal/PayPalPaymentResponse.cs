using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// A PayPal payment.
    /// </summary>
    [PublicAPI]
    public sealed class PayPalPaymentResponse : PaymentResponse
    {
        /// <summary>
        /// Details for the PayPal payment.
        /// </summary>
        [JsonProperty("payment_details")]
        public new PayPalDetailsResponse Details
        {
            get { return (PayPalDetailsResponse) base.Details; }
            set { base.Details = value; }
        }
    }
}