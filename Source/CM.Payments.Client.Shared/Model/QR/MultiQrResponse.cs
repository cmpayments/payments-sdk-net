using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// Response from a MultiQrRequest.
    /// </summary>
    [PublicAPI]
    public class MultiQrResponse
    {
        /// <summary>
        /// Request ID.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
        /// <summary>
        /// Batch data.
        /// </summary>
        [JsonProperty("batch")]
        public IEnumerable<QrReference> Batch { get; set; }
    }
}
