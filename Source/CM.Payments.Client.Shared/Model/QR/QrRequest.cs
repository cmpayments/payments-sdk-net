using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// Contains information to make a QR payment.
    /// </summary>
    [PublicAPI]
    public sealed class QrRequest
    {
        /// <summary>
        ///     Total amount of the charge.
        /// </summary>
        [JsonProperty("amount")]
        public double Amount { get; set; }

        /// <summary>
        ///     Amount can or can't be changed by the end-user.
        /// </summary>
        [JsonProperty("amount_changeable")]
        public bool AmountChangeable { get; set; }

        /// <summary>
        ///     Maximum amount that can be paid.
        /// </summary>
        [JsonProperty("amount_max", NullValueHandling = NullValueHandling.Ignore)]
        public double AmountMax { get; set; }

        /// <summary>
        ///     Minimum amount that can be paid.
        /// </summary>
        [JsonProperty("amount_min", NullValueHandling = NullValueHandling.Ignore)]
        public double AmountMin { get; set; }

        /// <summary>
        ///     Name of the beneficiary.
        /// </summary>
        [JsonProperty("beneficiary")]
        public string Beneficiary { get; set; }

        /// <summary>
        ///     URL that will be used to call the backend of a merchant when the status has changed.
        /// </summary>
        [JsonProperty("callback_url", NullValueHandling = NullValueHandling.Ignore)]
        public string CallbackUrl { get; set; }

        /// <summary>
        ///     URL that will be used when the payment is cancelled.
        /// </summary>
        [JsonProperty("cancelled_url", NullValueHandling = NullValueHandling.Ignore)]
        public string CancelledUrl { get; set; }

        /// <summary>
        ///     Description of the QR payment.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        ///     Expiration date of the QR code.
        /// </summary>
        [JsonProperty("expiration")]
        public string Expiration { get; set; }

        /// <summary>
        ///     URL that will be used when the payment is expired.
        /// </summary>
        [JsonProperty("expired_url", NullValueHandling = NullValueHandling.Ignore)]
        public string ExpiredUrl { get; set; }

        /// <summary>
        ///     URL that will be used when the payment failed.
        /// </summary>
        [JsonProperty("failed_url", NullValueHandling = NullValueHandling.Ignore)]
        public string FailedUrl { get; set; }

        /// <summary>
        ///     QR code can be paid multiple times.
        /// </summary>
        [JsonProperty("one_off")]
        public bool OneOff { get; set; }

        /// <summary>
        ///     Unique identifier used as reference for the merchant.
        /// </summary>
        [JsonProperty("purchase_id")]
        public string PurchaseId { get; set; }

        /// <summary>
        ///     Pixel width and height if the QR image.
        /// </summary>
        [JsonProperty("size")]
        public int Size { get; set; }

        /// <summary>
        ///     URL that will be used when the payment is completed.
        /// </summary>
        [JsonProperty("success_url", NullValueHandling = NullValueHandling.Ignore)]
        public string SuccessUrl { get; set; }
    }
}