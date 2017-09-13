using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// Details of the wire transfer payment response.
    /// </summary>
    [PublicAPI]
    public sealed class WireTransferPaymentResponse : PaymentResponse
    {
        /// <summary>
        /// In depth details of the wire transfer response.
        /// </summary>
        [JsonProperty("payment_details")]
        public new WireTransferDetailsResponse Details
        {
            get => (WireTransferDetailsResponse) base.Details;
            set => base.Details = value;
        }
    }
}