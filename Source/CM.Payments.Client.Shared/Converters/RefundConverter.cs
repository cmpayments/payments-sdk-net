using CM.Payments.Client.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
// ReSharper disable once RedundantUsingDirective
using System.Reflection;

namespace CM.Payments.Client.Converters
{
    internal sealed class RefundConverter : JsonConverter
    {
        public override bool CanWrite => false;        

        /// <summary>
        /// Writes the json.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The serializer.</param>
        /// <exception cref="System.NotSupportedException"></exception>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Reads the json.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value.</param>
        /// <param name="serializer">The serializer.</param>
        /// <returns></returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var target = new RefundDetailsResponse();
            var token = JToken.Load(reader);
            serializer.Populate(token.CreateReader(), target);
            return target;
        }

        /// <inheritdoc />
        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>
        ///   <c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
        /// </returns>
        public override bool CanConvert(Type objectType) => typeof(RefundResponse).IsAssignableFrom(objectType);
    }
}