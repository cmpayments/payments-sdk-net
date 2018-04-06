using CM.Payments.Client.Converters;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// In depth details of the refund request.
    /// </summary>
    [JsonConverter(typeof(RefundDetailsRequestConverter))]
    public abstract class RefundDetailsRequest
    {
        [UsedImplicitly, JsonProperty("payment_method")]
        internal abstract PaymentMethod Method { get; }
    }
}