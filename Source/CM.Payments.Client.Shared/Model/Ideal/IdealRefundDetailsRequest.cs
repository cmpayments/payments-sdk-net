using JetBrains.Annotations;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// In depth details of the iDEAL refund request.
    /// </summary>
    [PublicAPI]
    public sealed class IdealRefundDetailsRequest : RefundDetailsRequest
    {
        internal override PaymentMethod Method => PaymentMethod.iDEAL;
    }
}