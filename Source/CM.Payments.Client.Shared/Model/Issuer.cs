using JetBrains.Annotations;

namespace CM.Payments.Client.Model
{
    /// <summary>
    /// Details of the financial institution
    /// </summary>
    [PublicAPI]
    public sealed class Issuer
    {
        /// <summary>
        /// Unique identifier of the issuer.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Name of the issuer.
        /// </summary>
        public string Name { get; set; }
    }
}