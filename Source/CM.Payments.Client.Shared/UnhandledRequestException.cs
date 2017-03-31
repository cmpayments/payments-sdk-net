using System;
using JetBrains.Annotations;

namespace CM.Payments.Client
{
    /// <summary>
    ///     Raised when a request failed without a foreseen condition.
    /// </summary>
    [PublicAPI]
    public sealed class UnhandledRequestException : Exception
    {
        internal UnhandledRequestException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}