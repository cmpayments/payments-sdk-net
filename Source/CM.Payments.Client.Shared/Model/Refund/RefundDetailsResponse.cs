using CM.Payments.Client.Converters;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    [JsonConverter(typeof(RefundConverter))]
    public abstract class RefundDetailsResponse
    {
    }
}