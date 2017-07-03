using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// Details of the iDEAL payment response.
    /// </summary>
    [PublicAPI]
    public sealed class IdealPaymentResponse : PaymentResponse
    {
        /// <summary>
        /// In depth details of the iDEAL response.
        /// </summary>
        [JsonProperty("payment_details")]
        public new IdealDetailsResponse Details
        {
            get => (IdealDetailsResponse) base.Details;
            set => base.Details = value;
        }
    }
}