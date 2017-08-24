using JetBrains.Annotations;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// Interface for a details response.
    /// </summary>
    [PublicAPI]
    public interface IDetailsResponse
    {
        /// <summary>
        /// URL to where an end-user can execute the payment.
        /// </summary>
        string AuthenticationUrl { get; set; }
    }
}