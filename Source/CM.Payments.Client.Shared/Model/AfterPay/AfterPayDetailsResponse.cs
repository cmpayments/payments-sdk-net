using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// Specific details for a AfterPay payment.
    /// </summary>
    [PublicAPI]
    public sealed class AfterPayDetailsResponse : AfterPayDetailsRequest, IAuthenticatedResponse
    {
        /// <summary>
        /// The result.
        /// </summary>
        [JsonProperty("result")]
        public ResultResponse Result { get; set; }

        /// <summary>
        /// URL to where an end-user can execute the payment.
        /// </summary>
        string IAuthenticatedResponse.AuthenticationUrl { get; set; }

        /// <summary>
        /// Information about the result.
        /// </summary>
        public class ResultResponse
        {
            /// <summary>
            /// The checksum.
            /// </summary>
            [JsonProperty("checksum")]
            public string Checksum { get; set; }

            /// <summary>
            /// Reference for order supplied by Afterpay.
            /// </summary>
            [JsonProperty("after_pay_order_reference")]
            public string OrderReference { get; set; }

            /// <summary>
            /// Result ID result of the AfterPayrequest:
            /// 0: Accepted by AfterPay provided that it is incombination with statusCode = A 
            /// 1: Exception in the request/response
            /// 2: Validation errors in the request
            /// 3: Rejected(payment refused) by AfterPay
            /// 4: Pending
            /// </summary>
            [JsonProperty("result_id")]
            public int ResultId { get; set; }

            /// <summary>
            /// Status of the order: 
            /// A: accepted, 
            /// W: refused,
            /// P: pending
            /// </summary>
            [JsonProperty("status_code")]
            public string StatusCode { get; set; }

            /// <summary>
            /// Unix timestamp of the entry of order in milli-seconds.
            /// </summary>
            [JsonProperty("timestamp_in")]
            public string TimestampIn { get; set; }

            /// <summary>
            /// Unix timestamp of the processing of the order in milliseconds.
            /// </summary>
            [JsonProperty("timestamp_out")]
            public string TimestampOut { get; set; }

            /// <summary>
            /// Amount in cents that has been invoiced so far.
            /// </summary>
            [JsonProperty("total_invoiced_amount")]
            public int TotalInvoicedAmount { get; set; }

            /// <summary>
            /// Amount in cents that is still left from authorized amount.
            /// </summary>
            [JsonProperty("total_reserved_amount")]
            public int TotalReservedAmount { get; set; }

            /// <summary>
            /// Unique ID for the transaction.
            /// </summary>
            [JsonProperty("transaction_id")]
            public string TransactionId { get; set; }
        }
    }
}