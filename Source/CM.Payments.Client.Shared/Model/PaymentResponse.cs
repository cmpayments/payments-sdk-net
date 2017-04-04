using System;
using CM.Payments.Client.Converters;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    /// <summary>
    ///     Base class for a payment response
    /// </summary>
    [JsonConverter(typeof(PaymentConverter))]
    public abstract class PaymentResponse
    {
        internal PaymentResponse()
        {
        }

        /// <summary>
        /// 	Amount of the payment.
        /// </summary>
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// 	Charge id linked to the payment object.
        /// </summary>
        [JsonProperty("charge_id")]
        public string ChargeId { get; set; }

        /// <summary>
        /// Creation date of the payment.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Currency of the payment in ISO-4217 format.
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public IAuthenticatedResponse Details { get; set; }

        /// <summary>
        /// 	Expiration date of the payment.
        /// </summary>
        [JsonProperty("due_date", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime DueDate { get; set; }

        /// <summary>
        /// 	Only for the payment method Wire Transfer. The last date of paying this transaction
        /// </summary>
        [JsonProperty("expires_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime ExpiresAt { get; set; }

        /// <summary>
        /// 	Payment method used to make the payment.
        /// </summary>
        [JsonProperty("payment_method")]
        public string Method { get; set; }

        /// <summary>
        /// Id of the payment object.
        /// </summary>
        [JsonProperty("payment_id")]
        public string PaymentId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("short_payment_id")]
        public string ShortPaymentId { get; set; }

        /// <summary>
        /// Status of the Payment. Can be: Open, Expired, Failed, Success or Cancelled.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// 	Indication of Payment was created in test modus. Test mode is dependent on Merchant’ test setting
        /// </summary>
        [JsonProperty("test")]
        public bool Test { get; set; }

        /// <summary>
        /// 	Update date of the payment.
        /// </summary>
        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime UpdatedAt { get; set; }
    }
}