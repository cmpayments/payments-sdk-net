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
        internal override PaymentMethod Method { get; } = PaymentMethod.Bancontact;

        /// <summary>
        /// Contains more in depth information about the Payment.
        /// </summary>
        [JsonProperty("payment_details")]
        public BancontactDetailsRequest Details { get; set; }        
    }
}