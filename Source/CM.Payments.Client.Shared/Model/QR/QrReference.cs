using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// QR code reference used in the batch QR response.
    /// </summary>
    [PublicAPI]
    public class QrReference
    {
        /// <summary>
        /// QR code ID.
        /// </summary>
        [JsonProperty("qr_id")]
        public string QrId { get; set; }

        /// <summary>
        /// QR code URL.
        /// </summary>
        [JsonProperty("qr_code_url")]
        public string QrCodeUrl { get; set; }
    }
}
