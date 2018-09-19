using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using FluentValidation;
using JetBrains.Annotations;

namespace CM.Payments.Client.Validators
{
    internal abstract class BaseValidator<T> : AbstractValidator<T>
    {

#if !NETSTANDARD1_6
        private static readonly IEnumerable<string> CurrencySymbols = CultureInfo.GetCultures(CultureTypes.SpecificCultures)
            .Select(x => new RegionInfo(x.LCID).ISOCurrencySymbol)
            .Distinct()
            .OrderBy(x => x);
#endif

        protected BaseValidator()
        {
        }

        /// <summary>
        /// Check if provided string is a valid postal code.
        /// </summary>
        /// <param name="postal">The postal.</param>
        /// <returns></returns>
        internal static bool BeAValidPostalCode([NotNull] string postal)
        {
            return Regex.IsMatch(postal, @"^[1-9][0-9]{3}\s?([a-zA-Z]{2})?$");
        }

        /// <summary>
        /// Check if provided string is a valid iban.
        /// </summary>
        /// <param name="iban">The iban.</param>
        /// <returns></returns>
        internal static bool BeAValidIban([NotNull] string iban)
        {
            return Regex.IsMatch(iban, @"^[A-Z]{2}[0-9]{2}[A-Z]{4}[0-9]{10}$");
        }

        /// <summary>
        /// Check if provided string is a valid currency.
        /// </summary>
        /// <param name="currency">The iban.</param>
        /// <returns></returns>
        internal static bool BeAValidCurrency([NotNull] string currency)
        {
#if NETSTANDARD1_6
            // There isn't a good way to enumerate all supported cultures in .NET Core < 2.0. 
            // In .NET Core 2.0 the respective queries to the underlying localisation systems have been implemented for windows and *nix, making this API available.
            return true;
#else
            return CurrencySymbols?.Any(s => s.Equals(currency, StringComparison.InvariantCultureIgnoreCase)) ?? false;
#endif
        }
    }
}
