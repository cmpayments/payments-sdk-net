using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// A Bancontact payment.
    /// </summary>
    [PublicAPI]
    public sealed class BancontactPaymentRequest : PaymentRequest
    {
        /// <summary>
        ///     Contains more in depth information about the Payment.
        /// </summary>
        [JsonProperty("payment_details")]
        public BancontactDetailsRequest Details { get; set; }

        internal override string Method { get; } = "Bancontact";
    }
}