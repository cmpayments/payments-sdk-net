using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    [PublicAPI]
    public class BancontactDetailsRequest : DetailsRequest
    {
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
        ///     Issuers for a Bancontact payment. If omitted BCMC is assumed.
        /// </summary>
        [JsonProperty("issuers")]
        public string[] Issuers { get; set; }

        /// <summary>
        ///     Unique identifier as reference for the merchant.
        /// </summary>
        [JsonProperty("purchase_id")]
        public string PurchaseId { get; set; }

        /// <summary>
        ///     URL that will be used when the payment is completed.
        /// </summary>
        [JsonProperty("success_url", NullValueHandling = NullValueHandling.Ignore)]
        public string SuccessUrl { get; set; }
    }
}