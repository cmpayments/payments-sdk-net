using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// Details of the QR payment response.
    /// </summary>
    [PublicAPI]
    public sealed class QrResponse
    {
        /// <summary>
        /// Total amount of the charge.
        /// </summary>
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// Amount can or can't be changed by the end-user.
        /// </summary>
        [JsonProperty("amount_changeable")]
        public bool AmountChangeable { get; set; }

        /// <summary>
        /// Name of the beneficiary.
        /// </summary>
        [JsonProperty("beneficiary")]
        public string Beneficiary { get; set; }

        /// <summary>
        /// Date and time the QR payment is created.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Description of the QR payment.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Expiration date of the QR code.
        /// </summary>
        [JsonProperty("expiration")]
        public DateTime? Expiration { get; set; }

        /// <summary>
        /// QR code can be paid multiple times.
        /// </summary>
        [JsonProperty("one_off")]
        public bool OneOff { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("payments")]
        public object Payments { get; set; }

        /// <summary>
        /// Unique identifier used as reference for the merchant.
        /// </summary>
        [JsonProperty("purchase_id")]
        public string PurchaseId { get; set; }

        /// <summary>
        /// URL to the QR image.
        /// </summary>
        [JsonProperty("qr_code_url")]
        public string QrCodeUrl { get; set; }

        /// <summary>
        /// Unique identifier of the QR payment.
        /// </summary>
        [JsonProperty("qr_id")]
        public string QrId { get; set; }

        /// <summary>
        /// Pixel width and height if the QR image.
        /// </summary>
        [JsonProperty("size")]
        public int Size { get; set; }

        /// <summary>
        /// Status of the QR payment.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Date and time the QR payment is updated.
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}