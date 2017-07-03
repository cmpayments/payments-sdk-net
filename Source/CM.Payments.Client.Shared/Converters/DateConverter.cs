using Newtonsoft.Json.Converters;
using System.Globalization;

namespace CM.Payments.Client.Converters
{
    internal sealed class DateConverter : IsoDateTimeConverter
    {
        public DateConverter()
        {
            this.DateTimeStyles = DateTimeStyles.AdjustToUniversal;
            this.DateTimeFormat = "yyyy-MM-dd";
        }
    }
}