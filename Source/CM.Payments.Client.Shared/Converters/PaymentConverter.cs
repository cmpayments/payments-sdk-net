using CM.Payments.Client.Model;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
// ReSharper disable once RedundantUsingDirective
using System.Reflection;

namespace CM.Payments.Client.Converters
{
    internal sealed class PaymentConverter : JsonConverter
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
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, [NotNull] JsonSerializer serializer)
        {
            PaymentResponse target;

            var token = JToken.Load(reader);

            switch (Enum.Parse(typeof(PaymentMethod), token["payment_method"].Value<string>()))
            {
                case PaymentMethod.iDEAL:
                    target = new IdealPaymentResponse();
                    break;
                case PaymentMethod.PayPal:
                    target = new PayPalPaymentResponse();
                    break;
                case PaymentMethod.AfterPay:
                    target = new AfterPayPaymentResponse();
                    break;
                case PaymentMethod.Creditcard:
                    target = new CreditcardPaymentResponse();
                    break;
                case PaymentMethod.Bancontact:
                    target = new BancontactPaymentResponse();
                    break;
                case PaymentMethod.WireTransfer:
                    target = new WireTransferPaymentResponse();
                    break;
                case PaymentMethod.SOFORT:
                    target = new SofortPaymentResponse();
                    break;
                case PaymentMethod.DirectDebit:
                    target = new DirectDebitPaymentResponse();
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
        public override bool CanConvert(Type objectType) => typeof(PaymentResponse).IsAssignableFrom(objectType);
    }
}