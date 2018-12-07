﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

// ReSharper disable InconsistentNaming
#pragma warning disable 1591
namespace CM.Payments.Client.Model
{
    /// <summary>
    /// Payment method options
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PaymentMethod
    {
        Ideal,
        IdealQR,
        PayPal,
        AfterPay,
        Creditcard,
        Bancontact,
        WireTransfer,
        Sofort,
        DirectDebit
    }
}
