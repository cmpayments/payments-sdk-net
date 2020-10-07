using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: AssemblyTitle("CM Payments SDK Client")]
[assembly: AssemblyDescription("CM Payments Software Development Kit")]

#if DEBUG
[assembly: AssemblyConfiguration("DEBUG")]
#else
[assembly: AssemblyConfiguration("RELEASE")]
#endif

[assembly: AssemblyCompany("CM Payments")]
[assembly: AssemblyCopyright("Copyright © 2017")]

[assembly: AssemblyVersion("1.1.11.0")]
[assembly: AssemblyInformationalVersion("1.2.0.0")]
[assembly: AssemblyFileVersion("1.1.11.0")]

[assembly: InternalsVisibleTo("CM.Payments.Client.Test")]
[assembly: InternalsVisibleTo("CM.Payments.Client.Test.40")]