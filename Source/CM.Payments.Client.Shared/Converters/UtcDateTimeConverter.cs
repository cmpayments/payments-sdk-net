using System.Globalization;
using Newtonsoft.Json.Converters;

namespace CM.Payments.Client.Converters
{
    internal sealed class UtcDateTimeConverter : IsoDateTimeConverter
    {
        public UtcDateTimeConverter()
        {
            DateTimeStyles = DateTimeStyles.AdjustToUniversal;
            DateTimeFormat = "yyyy-MM-ddTHH:mm:ssZ";
        }
    }
}