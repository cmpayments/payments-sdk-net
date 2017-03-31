namespace CM.Payments.Client.Enums
{
    /// <summary>
    ///     Specifies the VAT category to use for an Afterpay order line
    /// </summary>
    public enum AfterPayVatCategory
    {
        /// <summary>
        ///     High VAT category
        /// </summary>
        High = 1,

        /// <summary>
        ///     Low VAT category
        /// </summary>
        Low = 2,

        /// <summary>
        ///     No-VAT category
        /// </summary>
        Zero = 3,

        /// <summary>
        ///     VAT category undefined
        /// </summary>
        None = 4
    }
}