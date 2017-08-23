using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// In depth details of the AfterPay payment response.
    /// </summary>
    [PublicAPI]
    public sealed class AfterPayDetailsResponse : AfterPayDetailsRequest, IDetailsResponse
    {
        /// <summary>
        /// URL to where an end-user can execute the payment.
        /// </summary>
        [JsonProperty("authentication_url")]
        public string AuthenticationUrl { get; set; }

        /// <summary>
        /// Details of the result within the AfterPay payment response.
        /// </summary>
        [JsonProperty("result")]
        public ResultResponse Result { get; set; }

        /// <summary>
        /// Details of the result within the AfterPay payment response.
        /// </summary>
        public class ResultResponse
        {
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty("checksum")]
            public string Checksum { get; set; }

            /// <summary>
            /// 
            /// </summary>
            [JsonProperty("after_pay_order_reference")]
            public string OrderReference { get; set; }

            /// <summary>
            /// 
            /// </summary>
            [JsonProperty("result_id")]
            public int ResultId { get; set; }

            /// <summary>
            /// 
            /// </summary>
            [JsonProperty("status_code")]
            public string StatusCode { get; set; }

            /// <summary>
            /// 
            /// </summary>
            [JsonProperty("timestamp_in")]
            public string TimestampIn { get; set; }

            /// <summary>
            /// 
            /// </summary>
            [JsonProperty("timestamp_out")]
            public string TimestampOut { get; set; }

            /// <summary>
            /// 
            /// </summary>
            [JsonProperty("total_invoiced_amount")]
            public int TotalInvoicedAmount { get; set; }

            /// <summary>
            /// 
            /// </summary>
            [JsonProperty("total_reserved_amount")]
            public int TotalReservedAmount { get; set; }

            /// <summary>
            /// 
            /// </summary>
            [JsonProperty("transaction_id")]
            public string TransactionId { get; set; }
        }
    }
}