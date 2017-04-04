using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// A Bancontact payment.
    /// </summary>
    [PublicAPI]
    public sealed class BancontactPaymentResponse : PaymentResponse
    {
        /// <summary>
        /// The details for a Bancontact payment.
        /// </summary>
        [JsonProperty("payment_details")]
        public new BancontactDetailsResponse Details
        {
            get { return (BancontactDetailsResponse) base.Details; }
            set { base.Details = value; }
        }
    }
}