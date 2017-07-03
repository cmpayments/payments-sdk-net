using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// Details of the Bancontact payment request.
    /// </summary>
    [PublicAPI]
    public sealed class BancontactPaymentRequest : PaymentRequest
    {
        /// <summary>
        /// Contains more in depth information about the Payment.
        /// </summary>
        [JsonProperty("payment_details")]
        public BancontactDetailsRequest Details { get; set; }

        /// <summary>
        /// Payment method used to make the payment.
        /// </summary>
        internal override string Method { get; } = "Bancontact";
    }
}