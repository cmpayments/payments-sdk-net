using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// In depth details of the Bancontact payment request.
    /// </summary>
    [PublicAPI]
    public class BancontactDetailsRequest : DetailsRequest
    {
        /// <summary>
        /// Issuers for a Bancontact payment. If omitted BCMC is assumed.
        /// </summary>
        [JsonProperty("issuers")]
        public string[] Issuers { get; set; }
    }
}