# CM Payments SDK

[![Build Status][badge-build]][build]
[![Nuget][badge-nuget]][nuget]
[![Software License][badge-license]][license]

cmpayments/payments-sdk-net is a nuget package to use CM Payment's services in a .net Framework or .net Core library.

Currently the following payment methods are supported:
- [Afterpay](https://www.afterpay.nl/)
- [Bancontact](https://www.bancontact.com)
- Credit Card ([VISA](https://www.visa.com)/[MasterCard](https://www.mastercard.com))
- [iDEAL](https://www.ideal.nl/)
- [iDEAL QR](https://www.ideal.nl/betalen/wat/via-qr-code/)
- [PayPal](https://www.paypal.com)
- [SOFORT](https://www.sofort.com)
- [WireTransfer](https://en.wikipedia.org/wiki/Wire_transfer)
- Direct debit

## Installation

For installation, reference the [NuGet][] package in your project.

```
PM> Install-Package CM.Payment.SDK
```

## Sample

The \Sample-folder contains a simple example MVC webshop implementing the CM Payments SDK.
Open \Sample\CM.Payments.SDK.Sample.sln in Visual Studio, restore the missing NuGet packages and run the application to see it in action. The payment methods will show a demo account using simulated money transfers. 

## Submitting bugs and feature requests

Bugs and feature request are tracked on [GitHub](https://github.com/cmpayments/iban/payments-sdk-net)

## Copyright and license

The cmpayment/payments-sdk-net library is copyright (C) [CM Payments](https://cmpayments.com/) and licensed for use under the MIT License (MIT). Please see [LICENSE][] for more information.

[badge-build]: https://img.shields.io/appveyor/ci/cm-payments/payments-sdk-net.svg?style=flat-square
[build]: https://ci.appveyor.com/project/cmpayments/payments-sdk-net

[badge-nuget]: 	https://img.shields.io/nuget/v/CM.Payments.SDK.svg
[nuget]: https://www.nuget.org/packages/CM.Payments.SDK/

[badge-license]: https://img.shields.io/badge/license-MIT-brightgreen.svg?style=flat-square
[license]: https://github.com/cmpayments/payments-sdk-net/blob/master/LICENSE
