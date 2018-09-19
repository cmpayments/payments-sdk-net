using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// Details of the Bancontact payment response.
    /// </summary>
    [PublicAPI]
    public sealed class BancontactPaymentResponse : PaymentResponse
    {
        internal override PaymentMethod Method => PaymentMethod.Bancontact;

        /// <summary>
        /// In depth details of the Bancontact response.
        /// </summary>
        [JsonProperty("payment_details")]
        public new BancontactDetailsResponse Details
        {
            get => (BancontactDetailsResponse) base.Details;
            set => base.Details = value;
        }
    }
}