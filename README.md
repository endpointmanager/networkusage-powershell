![Image of networkusage-powershell](https://repository-images.githubusercontent.com/303191282/19622200-0c0a-11eb-98e2-8f3fb81a8aab)
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
(Derived from ConnectionProfile.GetAttributedNetworkUsageAsync(DateTimeOffset, DateTimeOffset, NetworkUsageStates)) 
#### Example (Get-AttributedNetworkUsage)
```ps
Get-AttributedNetworkUsage -ConnectionProfile (Get-InternetConnectionProfile) -StartTime (Get-Date).AddDays(-7)
```

### Get-ConnectionCost
Gets the cost information for the connection.  
(Derived from ConnectionProfile.GetConnectionCost())  

### Get-ConnectionProfiles
Gets a list of profiles for connections, active or otherwise, on the local machine.  
(Derived from NetworkInformation.GetConnectionProfiles())  

### Get-ConnectivityIntervals
Gets the cost information for the connection.  
(Derived from ConnectionProfile.GetConnectionCost())  

### Get-DataPlanStatus
Gets the current domain authentication status for a network connection. Possible values are defined by DomainConnectivityLevel.  
(Derived from ConnectionProfile.GetConnectionCost())  

### Get-DomainConnectivityLevel
Gets the current domain authentication status for a network connection. Possible values are defined by DomainConnectivityLevel.  
(Derived from ConnectionProfile.GetDomainConnectivityLevel())

### Get-InternetConnectionProfile
Gets the connection profile associated with the internet connection currently used by the local machine.  
(Derived from NetworkInformation.GetInternetConnectionProfile())  

### Get-NetworkConnectivityLevel
Gets the network connectivity level for this connection. This value indicates what network resources, if any, are currently available.  
(Derived from ConnectionProfile.GetNetworkConnectivityLevel())  

### Get-NetworkNames
Retrieves names associated with the network with which the connection is currently established.  
(Derived from ConnectionProfile.GetNetworkNames())  

### Get-NetworkUsage
Gets a list of the estimated data traffic and connection duration over a specified period of time, for a specific network usage state.  
(Derived from ConnectionProfile.ConnectionProfile.GetNetworkUsageAsync(DateTimeOffset, DateTimeOffset, DataUsageGranularity, NetworkUsageStates))  
#### Example (Get-NetworkUsage)
```ps
Get-NetworkUsage -ConnectionProfile (Get-InternetConnectionProfile) -Granularity PerDay -StartTime (Get-Date).AddDays(-3)
```

### Get-ProviderNetworkUsage
Returns the bytes sent and bytes received for each MCC and MNC combination (the combination is represented by a ProviderId).  
(Derived from ConnectionProfile.ConnectionProfile.GetProviderNetworkUsageAsync(DateTimeOffset, DateTimeOffset, NetworkUsageStates))  

### Get-SignalBars
Gets a value that indicates the current number of signal bars displayed by the Windows UI for the connection.  
(Derived from ConnectionProfile.GetSignalBars())  

### New-NetworkUsageStates
Returns an object of type [Windows.Networking.Connectivity.NetworkUsageStates], which can be used for cmdlets where -NetworkUsageStates can be passed  

### Setup

* Copy the compiled dll-file (endpointmanager.networkusage.dll) including the folder containing the help files (en-US) to %ProgramFiles%\WindowsPowerShell\Modules\endpointmanager
* OR use "Import-Module endpointmanager.networkusage.dll" within your powershell script

## License

See [LICENSE](LICENSE.md) file for licence rights and limitations (MIT)
