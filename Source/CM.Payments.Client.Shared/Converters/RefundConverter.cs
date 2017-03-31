using CM.Payments.Client.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
// ReSharper disable once RedundantUsingDirective
using System.Reflection;

namespace CM.Payments.Client.Converters
{
    internal sealed class RefundConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(RefundResponse).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            RefundDetailsResponse target;

            if (token.Count() > 1)
                target = new IdealRefundDetailsResponse();
            else
                target = new AfterPayRefundDetailsResponse();
            serializer.Populate(token.CreateReader(), target);

            return target;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }
    }
}
