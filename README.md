# networkusage-powershell

This repo contains a PowerShell module that provides several cmdlets to retrieve connection profiles that provide connectivity, usage, and data plan information for established network connections.
It's functionality is derived from the official Windows.Networking.Connectivity Namespace from the Windows Runtime API.
The project uses the new Windows 10 WinRT API Pack (Microsoft.Windows.SDK.Contracts) which was published in late 2019 for the first time.

## Requirements

* Windows 10
* .NET Framework 4.6 or higher

## Available cmdlets

After the module is loaded (see Setup)...
* Use "Get-Command -Module endpointmanager.networkusage" to get a full list of cmdlets provided by this module.
* Please use e.g. "Get-Help Get-NetworkUsage -Examples" to get examples of how to use the corresponding cmdlet.

### Get-AttributedNetworkUsage

Gets network usage data for each individual application.
(Derived from the ConnectionProfile.GetAttributedNetworkUsageAsync(DateTimeOffset, DateTimeOffset, NetworkUsageStates) Method)

### Get-ConnectionCost
### Get-ConnectionProfiles
### Get-ConnectivityIntervals
### Get-DataPlanStatus
### Get-DomainConnectivityLevel
### Get-InternetConnectionProfile
### Get-NetworkConnectivityLevel
### Get-NetworkNames
### Get-NetworkUsage
### Get-ProviderNetworkUsage
### Get-SignalBars
### New-NetworkUsageStates

### Setup

* Copy the compiled dll-file (endpointmanager.networkusage.dll) including the folder containing the help files (en-US) to %ProgramFiles%\WindowsPowerShell\Modules\endpointmanager
* OR use "Import-Module endpointmanager.networkusage.dll" within your powershell script

## License

See [LICENSE](LICENSE.md) file for licence rights and limitations (MIT)