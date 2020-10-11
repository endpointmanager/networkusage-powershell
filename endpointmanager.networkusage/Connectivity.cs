using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.Connectivity;

namespace endpointmanager.connectivity
{
    class WinRTConnectivity
    {

        private static async Task<IReadOnlyList<Windows.Networking.Connectivity.AttributedNetworkUsage>> GetAttributedNetworkUsageAsync(ConnectionProfile connectionProfile, DateTime startTime, DateTime endTime, NetworkUsageStates networkUsageStates)
        {
            try
            {
                DateTimeOffset StartTimeOffset = new DateTimeOffset(startTime);
                DateTimeOffset EndTimeOffset = new DateTimeOffset(endTime);
                return await connectionProfile.GetAttributedNetworkUsageAsync(StartTimeOffset, EndTimeOffset, networkUsageStates);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<IReadOnlyList<AttributedNetworkUsage>> GetAttributedNetworkUsageSync(ConnectionProfile connectionProfile, DateTime startTime, DateTime endTime, NetworkUsageStates networkUsageStates)
        {
            return await GetAttributedNetworkUsageAsync(connectionProfile, startTime, endTime, networkUsageStates);
        }

        public static IReadOnlyList<AttributedNetworkUsage> GetAttributedNetworkUsage(ConnectionProfile connectionProfile, DateTime startTime, DateTime endTime, NetworkUsageStates networkUsageStates)
        {
            Task<IReadOnlyList<AttributedNetworkUsage>> task = Task.Run(() => GetAttributedNetworkUsageSync(connectionProfile, startTime, endTime, networkUsageStates));
            return task.Result;
        }


        private static async Task<IReadOnlyList<ProviderNetworkUsage>> GetProviderNetworkUsageAsync(ConnectionProfile connectionProfile, DateTime startTime, DateTime endTime, NetworkUsageStates networkUsageStates)
        {
            try
            {
                DateTimeOffset StartTimeOffset = new DateTimeOffset(startTime);
                DateTimeOffset EndTimeOffset = new DateTimeOffset(endTime);

                return await connectionProfile.GetProviderNetworkUsageAsync(StartTimeOffset, EndTimeOffset, networkUsageStates);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static async Task<IReadOnlyList<NetworkUsage>> GetNetworkUsageAsync(ConnectionProfile connectionProfile, DateTime startTime, DateTime endTime, DataUsageGranularity granularity, NetworkUsageStates networkUsageStates)
        {
            try
            {
                DateTimeOffset StartTimeOffset = new DateTimeOffset(startTime);
                DateTimeOffset EndTimeOffset = new DateTimeOffset(endTime);
               
                return await connectionProfile.GetNetworkUsageAsync(StartTimeOffset, EndTimeOffset, granularity, networkUsageStates);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static async Task<IReadOnlyList<ConnectivityInterval>> GetConnectivityIntervalsAsync(ConnectionProfile connectionProfile, DateTime startTime, DateTime endTime, NetworkUsageStates networkUsageStates)
        {
            try
            {
                DateTimeOffset StartTimeOffset = new DateTimeOffset(startTime);
                DateTimeOffset EndTimeOffset = new DateTimeOffset(endTime);

                return await connectionProfile.GetConnectivityIntervalsAsync(StartTimeOffset, EndTimeOffset, networkUsageStates);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<IReadOnlyList<NetworkUsage>> GetNetworkUsageSync(ConnectionProfile connectionProfile, DateTime startTime, DateTime endTime, DataUsageGranularity granularity, NetworkUsageStates networkUsageStates)
        {
            return await GetNetworkUsageAsync(connectionProfile, startTime, endTime, granularity, networkUsageStates);
        }

        static async Task<IReadOnlyList<ConnectivityInterval>> GetConnectivityIntervalsSync(ConnectionProfile connectionProfile, DateTime startTime, DateTime endTime, NetworkUsageStates networkUsageStates)
        {
            return await GetConnectivityIntervalsAsync(connectionProfile, startTime, endTime, networkUsageStates);
        }

        public static async Task<IReadOnlyList<ProviderNetworkUsage>> GetProviderNetworkUsageSync(ConnectionProfile connectionProfile, DateTime startTime, DateTime endTime, NetworkUsageStates networkUsageStates)
        {
            return await GetProviderNetworkUsageAsync(connectionProfile, startTime, endTime, networkUsageStates);
        }

        public static IReadOnlyList<ProviderNetworkUsage> GetProviderNetworkUsage(ConnectionProfile connectionProfile, DateTime startTime, DateTime endTime, NetworkUsageStates networkUsageStates)
        {
            Task<IReadOnlyList<ProviderNetworkUsage>> task = Task.Run(() => GetProviderNetworkUsageSync(connectionProfile, startTime, endTime, networkUsageStates));
            return task.Result;
        }

        public static IReadOnlyList<NetworkUsage> GetNetworkUsage(ConnectionProfile connectionProfile, DateTime startTime, DateTime endTime, DataUsageGranularity granularity, NetworkUsageStates networkUsageStates)
        {
            Task<IReadOnlyList<NetworkUsage>> task = Task.Run(() => GetNetworkUsageSync(connectionProfile, startTime, endTime, granularity, networkUsageStates));
            return task.Result;
        }

        public static IReadOnlyList<ConnectivityInterval> GetConnectivityIntervals(ConnectionProfile connectionProfile, DateTime startTime, DateTime endTime, NetworkUsageStates networkUsageStates)
        {
            Task<IReadOnlyList<ConnectivityInterval>> task = Task.Run(() => GetConnectivityIntervalsSync(connectionProfile, startTime, endTime, networkUsageStates));
            return task.Result;
        }

        public static IReadOnlyList<Windows.Networking.Connectivity.ConnectionProfile> GetConnectionProfiles()
        {
            return NetworkInformation.GetConnectionProfiles();
        }

        public static Windows.Networking.Connectivity.ConnectionProfile GetInternetConnectionProfile()
        {
            return NetworkInformation.GetInternetConnectionProfile();
        }
    }
}
