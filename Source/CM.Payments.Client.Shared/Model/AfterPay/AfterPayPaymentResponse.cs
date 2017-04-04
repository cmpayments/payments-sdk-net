using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// An AfterPay payment.
    /// </summary>
    [PublicAPI]
    public sealed class AfterPayPaymentResponse : PaymentResponse
    {
        /// <summary>
        /// Details for a AfterPay payment.
        /// </summary>
        [JsonProperty("payment_details")]
        public new AfterPayDetailsResponse Details
        {
            get { return (AfterPayDetailsResponse) base.Details; }
            set { base.Details = value; }
        }
    }
}