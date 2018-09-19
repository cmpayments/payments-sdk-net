using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// Details of the Sofort payment response.
    /// </summary>
    [PublicAPI]
    public sealed class SofortPaymentResponse : PaymentResponse
    {
        internal override PaymentMethod Method => PaymentMethod.SOFORT;

        /// <summary>
        /// In depth details of the Sofort response.
        /// </summary>
        [JsonProperty("payment_details")]
        public new SofortDetailsResponse Details
        {
            get => (SofortDetailsResponse) base.Details;
            set => base.Details = value;
        }
    }
}