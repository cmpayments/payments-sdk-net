using JetBrains.Annotations;
using System;

namespace CM.Payments.Client
{
    /// <summary>
    /// Raised when a request failed without a foreseen condition.
    /// </summary>
    [PublicAPI]
    public sealed class UnhandledRequestException : Exception
    {
        /// <summary>
        /// Create an exception for an unhandled or faulty request.
        /// </summary>
        /// <param name="message">Message of the exception.</param>
        /// <param name="innerException">Details of the exception.</param>
        public UnhandledRequestException(string message, Exception innerException)
            : base(message, innerException)
        {       
        }

        /// <summary>
        /// Create an exception for an unhandled or faulty request.
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="message">Message of the exception.</param>
        internal UnhandledRequestException(int statusCode, string message)
            : base(message)
        {
            this.StatusCode = statusCode;
        }

        /// <summary>
        /// Status code of the HTTP response.
        /// </summary>
        public int? StatusCode { get; set; }
    }
}