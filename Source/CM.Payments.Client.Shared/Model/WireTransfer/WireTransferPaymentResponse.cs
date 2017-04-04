using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// A Wire Transfer payment.
    /// </summary>
    [PublicAPI]
    public sealed class WireTransferPaymentResponse : PaymentResponse
    {
        /// <summary>
        /// Details about the WireTransfer payment.
        /// </summary>
        [JsonProperty("payment_details")]
        public new WireTransferDetailsResponse Details
        {
            get { return (WireTransferDetailsResponse) base.Details; }
            set { base.Details = value; }
        }
    }
}