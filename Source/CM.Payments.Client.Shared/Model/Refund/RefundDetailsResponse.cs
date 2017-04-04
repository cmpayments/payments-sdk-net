using CM.Payments.Client.Converters;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// Details about a refund.
    /// </summary>
    [JsonConverter(typeof(RefundConverter))]
    public abstract class RefundDetailsResponse
    {
    }
}