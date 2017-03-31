using JetBrains.Annotations;

namespace CM.Payments.Client.Model
{
    /// <summary>
    ///     Details of the financial institution
    /// </summary>
    [PublicAPI]
    public sealed class Issuer
    {
        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        public string ID { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        public string Name { get; set; }
    }
}