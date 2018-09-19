using Newtonsoft.Json.Converters;
using System.Globalization;

namespace CM.Payments.Client.Converters
{
    internal sealed class DateConverter : IsoDateTimeConverter
    {
        public DateConverter()
        {
            DateTimeStyles = DateTimeStyles.AdjustToUniversal;
            DateTimeFormat = "yyyy-MM-dd";
        }
    }
}