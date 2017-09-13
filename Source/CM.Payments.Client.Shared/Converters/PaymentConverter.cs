using CM.Payments.Client.Model;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace CM.Payments.Client.Converters
{
    internal sealed class PaymentConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, [NotNull] JsonSerializer serializer)
        {
            PaymentResponse target;

            var token = JToken.Load(reader);
            
            var method = token["payment_method"]?.Value<string>();
            switch (method)
            {
                case "iDEAL":
                    target = new IdealPaymentResponse();
                    break;
                case "PayPal":
                    target = new PayPalPaymentResponse();
                    break;
                case "AfterPay":
                    target = new AfterPayPaymentResponse();
                    break;
                case "Creditcard":
                    target = new CreditcardPaymentResponse();
                    break;
                case "Bancontact":
                    target = new BancontactPaymentResponse();
                    break;
                case "WireTransfer":
                    target = new WireTransferPaymentResponse();
                    break;
                case "SOFORT":
                    target = new SofortPaymentResponse();
                    break;
                case "DirectDebit":
                    target = new DirectDebitPaymentResponse();
                    break;
                default:
                    throw new ArgumentException();
            }

            serializer.Populate(token.CreateReader(), target);

            return target;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }
    }
}