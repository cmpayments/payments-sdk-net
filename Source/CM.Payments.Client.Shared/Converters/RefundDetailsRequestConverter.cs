using System;
// ReSharper disable once RedundantUsingDirective
using System.Reflection;
using CM.Payments.Client.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CM.Payments.Client.Converters
{
    internal sealed class RefundDetailsRequestConverter : JsonConverter
    {
        public override bool CanWrite => false;

        /// <inheritdoc />
        /// <summary>
        /// Writes the json.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The serializer.</param>
        /// <exception cref="T:System.NotImplementedException"></exception>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        /// <summary>
        /// Reads the json.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value.</param>
        /// <param name="serializer">The serializer.</param>
        /// <returns></returns>
        /// <exception cref="T:System.ArgumentException"></exception>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            RefundDetailsRequest target;
            var token = JToken.Load(reader);

            switch (Enum.Parse(typeof(PaymentMethod), token["payment_method"].Value<string>().Replace(" ", string.Empty), true))
            {
                case PaymentMethod.AfterPay:
                    target = new AfterPayRefundDetailsRequest();
                    break;
                case PaymentMethod.DirectDebit:
                    target = new DirectDebitRefundDetailsRequest();
                    break;
                case PaymentMethod.Ideal:
                case PaymentMethod.IdealQR:
                    target = new IdealRefundDetailsRequest();
                    break;
                default:
                    throw new ArgumentException();
            }

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
        public override bool CanConvert(Type objectType) => typeof(RefundRequest).IsAssignableFrom(objectType);
    }
}
