using JetBrains.Annotations;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// 
    /// </summary>
    [PublicAPI]
    public interface IAuthenticatedResponse
    {
        /// <summary>
        /// URL to where an end-user can execute the payment.
        /// </summary>
        string AuthenticationUrl { get; set; }
    }
}
