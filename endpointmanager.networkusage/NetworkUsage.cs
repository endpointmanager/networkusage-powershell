using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;
using Windows.Networking.Connectivity;
using endpointmanager.connectivity;

namespace endpointmanager.networkusage
{
    [Cmdlet("Get", "ConnectionProfiles")]
    [OutputType(typeof(Windows.Networking.Connectivity.ConnectionProfile))]
    public class GetConnectionProfilesCommand : Cmdlet
    {
        protected override void ProcessRecord()
        {
            foreach (Windows.Networking.Connectivity.ConnectionProfile profiles in WinRTConnectivity.GetConnectionProfiles())
            {
                WriteObject(profiles);
            }
        }
    }

    [Cmdlet("Get", "ConnectionCost")]
    [OutputType(typeof(Windows.Networking.Connectivity.ConnectionCost))]
    public class GetConnectionCostCommand : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public Windows.Networking.Connectivity.ConnectionProfile ConnectionProfile
        {
            get { return connectionProfile; }
            set { connectionProfile = value; }
        }
        private Windows.Networking.Connectivity.ConnectionProfile connectionProfile;

        protected override void ProcessRecord()
        {
            WriteObject(connectionProfile.GetConnectionCost());
        }
    }

    [Cmdlet("Get", "DataPlanStatus")]
    [OutputType(typeof(Windows.Networking.Connectivity.DataPlanStatus))]
    public class GetDataPlanStatusCommand : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public Windows.Networking.Connectivity.ConnectionProfile ConnectionProfile
        {
            get { return connectionProfile; }
            set { connectionProfile = value; }
        }
        private Windows.Networking.Connectivity.ConnectionProfile connectionProfile;

        protected override void ProcessRecord()
        {
            WriteObject(connectionProfile.GetDataPlanStatus());
        }
    }

    [Cmdlet("Get", "NetworkNames")]
    [OutputType(typeof(string))]
    public class GetNetworkNamesCommand : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public Windows.Networking.Connectivity.ConnectionProfile ConnectionProfile
        {
            get { return connectionProfile; }
            set { connectionProfile = value; }
        }
        private Windows.Networking.Connectivity.ConnectionProfile connectionProfile;

        protected override void ProcessRecord()
        {
            foreach (string networkName in connectionProfile.GetNetworkNames())
            {
                WriteObject(networkName);
            }
        }
    }

    [Cmdlet("Get", "SignalBars")]
    [OutputType(typeof(System.Nullable<byte>))]
    public class GetSignalBarsCommand : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public Windows.Networking.Connectivity.ConnectionProfile ConnectionProfile
        {
            get { return connectionProfile; }
            set { connectionProfile = value; }
        }
        private Windows.Networking.Connectivity.ConnectionProfile connectionProfile;

        protected override void ProcessRecord()
        {
            WriteObject(connectionProfile.GetSignalBars());
        }
    }

    [Cmdlet("Get", "DomainConnectivityLevel")]
    [OutputType(typeof(DomainConnectivityLevel))]
    public class GetDomainConnectivityLevelCommand : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public Windows.Networking.Connectivity.ConnectionProfile ConnectionProfile
        {
            get { return connectionProfile; }
            set { connectionProfile = value; }
        }
        private Windows.Networking.Connectivity.ConnectionProfile connectionProfile;

        protected override void ProcessRecord()
        {
            WriteObject(connectionProfile.GetDomainConnectivityLevel());
        }
    }


    [Cmdlet("Get", "NetworkConnectivityLevel")]
    [OutputType(typeof(NetworkConnectivityLevel))]
    public class GetNetworkConnectivityLevelCommand : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public Windows.Networking.Connectivity.ConnectionProfile ConnectionProfile
        {
            get { return connectionProfile; }
            set { connectionProfile = value; }
        }
        private Windows.Networking.Connectivity.ConnectionProfile connectionProfile;

        protected override void ProcessRecord()
        {
            WriteObject(connectionProfile.GetNetworkConnectivityLevel());
        }
    }

    [Cmdlet("Get", "InternetConnectionProfile")]
    [OutputType(typeof(Windows.Networking.Connectivity.ConnectionProfile))]
    public class GetInternetConnectionProfileCommand : Cmdlet
    {
        protected override void ProcessRecord()
        {
            WriteObject(WinRTConnectivity.GetInternetConnectionProfile());
        }
    }

    [Cmdlet("Get", "AttributedNetworkUsage")]
    [OutputType(typeof(Windows.Networking.Connectivity.AttributedNetworkUsage))]
    public class GetAttributedNetworkUsageCommand : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public Windows.Networking.Connectivity.ConnectionProfile ConnectionProfile
        {
            get { return connectionProfile; }
            set { connectionProfile = value; }
        }
        private Windows.Networking.Connectivity.ConnectionProfile connectionProfile;

        [Parameter(Mandatory = false)]
        public DateTime StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }
        private DateTime startTime = DateTime.Now.AddDays(-60);

        [Parameter(Mandatory = false)]
        public DateTime EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }
        private DateTime endTime = DateTime.Now;

        [Parameter(Mandatory = false)]
        public NetworkUsageStates NetworkUsageStates
        {
            get { return networkUsageStates; }
            set { networkUsageStates = value; }
        }
        private NetworkUsageStates networkUsageStates = new NetworkUsageStates { Roaming = TriStates.DoNotCare, Shared = TriStates.DoNotCare };


        protected override void ProcessRecord()
        {
            IReadOnlyList<AttributedNetworkUsage> networkUsageList = WinRTConnectivity.GetAttributedNetworkUsage(connectionProfile, startTime, endTime, networkUsageStates);
            if (networkUsageList.Count > 0)
            {
                foreach (AttributedNetworkUsage networkUsage in networkUsageList)
                {
                    WriteObject(networkUsage);
                }
            }
        }
    }
    
    [Cmdlet("Get", "NetworkUsage")]
    [OutputType(typeof(Windows.Networking.Connectivity.NetworkUsage))]
    public class GetNetworkUsageCommand : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public Windows.Networking.Connectivity.ConnectionProfile ConnectionProfile
        {
            get { return connectionProfile; }
            set { connectionProfile = value; }
        }
        private Windows.Networking.Connectivity.ConnectionProfile connectionProfile;

        [Parameter(Mandatory = false)]
        public Windows.Networking.Connectivity.DataUsageGranularity Granularity
        {
            get { return granularity; }
            set { granularity = value; }
        }
        private Windows.Networking.Connectivity.DataUsageGranularity granularity = DataUsageGranularity.Total;

        [Parameter(Mandatory = false)]
        public DateTime StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }
        private DateTime startTime = DateTime.Now.AddDays(-60);

        [Parameter(Mandatory = false)]
        public DateTime EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }
        private DateTime endTime = DateTime.Now;

        [Parameter(Mandatory = false)]
        public NetworkUsageStates NetworkUsageStates
        {
            get { return networkUsageStates; }
            set { networkUsageStates = value; }
        }
        private NetworkUsageStates networkUsageStates = new NetworkUsageStates { Roaming = TriStates.DoNotCare, Shared = TriStates.DoNotCare };

        protected override void ProcessRecord()
        {
            IReadOnlyList<NetworkUsage> networkUsageList = WinRTConnectivity.GetNetworkUsage(ConnectionProfile, startTime, endTime, granularity, networkUsageStates);
            if (networkUsageList.Count > 0)
            {
                foreach (NetworkUsage networkUsage in networkUsageList)
                {
                    WriteObject(networkUsage);
                }
            }
        }
    }

    [Cmdlet("Get", "ConnectivityIntervals")]
    [OutputType(typeof(Windows.Networking.Connectivity.ConnectivityInterval))]
    public class GetConnectivityIntervalsCommand : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public Windows.Networking.Connectivity.ConnectionProfile ConnectionProfile
        {
            get { return connectionProfile; }
            set { connectionProfile = value; }
        }
        private Windows.Networking.Connectivity.ConnectionProfile connectionProfile;

        [Parameter(Mandatory = false)]
        public DateTime StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }
        private DateTime startTime = DateTime.Now.AddDays(-60);

        [Parameter(Mandatory = false)]
        public DateTime EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }
        private DateTime endTime = DateTime.Now;

        [Parameter(Mandatory = false)]
        public NetworkUsageStates NetworkUsageStates
        {
            get { return networkUsageStates; }
            set { networkUsageStates = value; }
        }
        private NetworkUsageStates networkUsageStates = new NetworkUsageStates { Roaming = TriStates.DoNotCare, Shared = TriStates.DoNotCare };

        protected override void ProcessRecord()
        {
            IReadOnlyList<ConnectivityInterval> connectivityIntervalList = WinRTConnectivity.GetConnectivityIntervals(ConnectionProfile, startTime, endTime, networkUsageStates);
            if (connectivityIntervalList.Count > 0)
            {
                foreach (ConnectivityInterval connectivityInterval in connectivityIntervalList)
                {
                    WriteObject(connectivityInterval);
                }
            }
        }
    }

    [Cmdlet("Get", "ProviderNetworkUsage")]
    [OutputType(typeof(Windows.Networking.Connectivity.ConnectivityInterval))]
    public class GetProviderNetworkUsageCommand : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public Windows.Networking.Connectivity.ConnectionProfile ConnectionProfile
        {
            get { return connectionProfile; }
            set { connectionProfile = value; }
        }
        private Windows.Networking.Connectivity.ConnectionProfile connectionProfile;

        [Parameter(Mandatory = false)]
        public DateTime StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }
        private DateTime startTime = DateTime.Now.AddDays(-60);

        [Parameter(Mandatory = false)]
        public DateTime EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }
        private DateTime endTime = DateTime.Now;

        [Parameter(Mandatory = false)]
        public NetworkUsageStates NetworkUsageStates
        {
            get { return networkUsageStates; }
            set { networkUsageStates = value; }
        }
        private NetworkUsageStates networkUsageStates = new NetworkUsageStates { Roaming = TriStates.DoNotCare, Shared = TriStates.DoNotCare };

        protected override void ProcessRecord()
        {
            IReadOnlyList<ProviderNetworkUsage> networkUsageList = WinRTConnectivity.GetProviderNetworkUsage(ConnectionProfile, startTime, endTime, networkUsageStates);
            if (networkUsageList.Count > 0)
            {
                foreach (ProviderNetworkUsage networkUsage in networkUsageList)
                {
                    WriteObject(networkUsage);
                }
            }
        }
    }

    [Cmdlet("New", "NetworkUsageStates")] 
    [OutputType(typeof(NetworkUsageStates))]
    public class GetNetworkUsageStatesCommand : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public Windows.Networking.Connectivity.TriStates Roaming
        {
            get { return roaming; }
            set { roaming = value; }
        }
        private Windows.Networking.Connectivity.TriStates roaming;

        [Parameter(Mandatory = true)]
        public Windows.Networking.Connectivity.TriStates Shared
        {
            get { return shared; }
            set { shared = value; }
        }
        private Windows.Networking.Connectivity.TriStates shared;

        protected override void ProcessRecord()
        {
            NetworkUsageStates result = new NetworkUsageStates { Roaming = roaming, Shared = shared };
            WriteObject(result);
        }
    }
}
