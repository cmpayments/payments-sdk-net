using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    [PublicAPI]
    public sealed class AfterPayDetailsResponse : AfterPayDetailsRequest, IAuthenticatedResponse
    {
        [JsonProperty("result")]
        public ResultResponse Result { get; set; }

        string IAuthenticatedResponse.AuthenticationUrl { get; set; }

        public class ResultResponse
        {
            [JsonProperty("checksum")]
            public string Checksum { get; set; }

            [JsonProperty("after_pay_order_reference")]
            public string OrderReference { get; set; }

            [JsonProperty("result_id")]
            public int ResultId { get; set; }

            [JsonProperty("status_code")]
            public string StatusCode { get; set; }

            [JsonProperty("timestamp_in")]
            public string TimestampIn { get; set; }

            [JsonProperty("timestamp_out")]
            public string TimestampOut { get; set; }

            [JsonProperty("total_invoiced_amount")]
            public int TotalInvoicedAmount { get; set; }

            [JsonProperty("total_reserved_amount")]
            public int TotalReservedAmount { get; set; }

            [JsonProperty("transaction_id")]
            public string TransactionId { get; set; }
        }
    }
}