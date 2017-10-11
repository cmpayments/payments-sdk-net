# Change Log
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/)
and this project adheres to [Semantic Versioning](http://semver.org/).

## [1.0.0] - 2017-03-xx
- Initial release

## [1.1.0] - 2017-07-03
- Added direct debit data, convert and validator models
- Added XML comments

## [1.1.1] - 2017-07-06
- Added build number to YAML for AppVeyor

## [1.1.2] - 2017-07-06
- Removed duplicate build-tag in assemble file version of the YAML

## [1.1.3] - 2017-07-07
- Altered UTC DateTime conversion to match format "2017-07-07T12:00:00Z"

## [1.1.4] - 2017-07-24
- Added missing properties for the direct debit payment response.
- Added missing properties for the payment response.

## [1.1.5] - 2017-07-24
- Altered build configurations for dotnet core project to be compatible with AppVeyor.

## [1.1.6] - 2017-08-21
- Add: Added missing Recurring property in credit card details
- Change: Return actual PSP error response instead of default static message
- Change: Moved URL properties to base request details

## [1.1.7] - 2017-08-21
- Restore output path to default for CM.Payments.Client.Core project

## [1.1.8] - 2017-08-24
- Added authentication URL in response details interface for generic use
 
## [1.1.9] - 2017-09-13
- Changed hardcoded client base uri to optional constructor parameter.

## [1.1.10] - 2017-09-13
- Removed charge validation rule to check the usage of WireTransfer.
- Removed charge validation rule to check currency.