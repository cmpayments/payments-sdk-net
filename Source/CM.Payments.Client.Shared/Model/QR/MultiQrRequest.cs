using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// Request to generate a batch of QR codes.
    /// </summary>
    [PublicAPI]
    public class MultiQrRequest
    {
        /// <summary>
        /// Individual QR code requests. Note: the same QR reference cannot be used multiple times.
        /// </summary>
        [JsonProperty("data")]
        public IEnumerable<QrRequest> Data { get; set; }
    }
}
