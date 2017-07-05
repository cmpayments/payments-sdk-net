using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// Details of the AfterPay payment response.
    /// </summary>
    [PublicAPI]
    public sealed class AfterPayPaymentResponse : PaymentResponse
    {
        /// <summary>
        /// In depth details of the AfterPay payment response.
        /// </summary>
        [JsonProperty("payment_details")]
        public new AfterPayDetailsResponse Details
        {
            get => (AfterPayDetailsResponse) base.Details;
            set => base.Details = value;
        }
    }
}