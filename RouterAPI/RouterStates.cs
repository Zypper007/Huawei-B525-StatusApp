using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RouterAPI
{

    // klasa mapuje odpowiedzi na zmienne w c#
    // zawiera wewnętrzne klasy dla ułatwienia łatwiejszych zapytań


    public class RouterStates
    { 
        public class ApiMonitoring
        {
            public int SignalPower { get; internal set; }
            public int NetworkType { get; internal set; }
            public int CurrentWifiUser { get; internal set; }
            public bool RoamingStatus { get; internal set; }
            public bool SimLockStatus { get; internal set; }
            public bool SimStatus { get; internal set; }
            public bool WifiStatus { get; internal set; }
            public bool FlyMode { get; internal set; }
            public bool UsbUp { get; internal set; }
            public string PrimaryDns { get; internal set; }
            public string SecondaryDns { get; internal set; }
        }

        public class ApiBasicInformation
        {
            public string DeviceName { get; internal set; }
            public string SoftwareVersion { get; internal set; }
            public string WebUIVersion { get; internal set; }
        }
        
        public class ApiPinStatus
        {
            public int SimPinTimes { get; internal set; }
            public int SimPukTimes { get; internal set; }
        }

        public class ApiDeviceSignal
        {
            public int RSRQ { get; internal set; }
            public int RSRP { get; internal set; }
            public int RSSI { get; internal set; }
            public int SINR { get; internal set; }
            public int RSCP { get; internal set; }
            public int ECIO { get; internal set; }
            public int UploadBandwidth { get; internal set; }
            public int DownloadBandwidth { get; internal set; }
        }

        public class ApiNotifications
        {
            public int UnreadMessage { get; internal set; }
            public bool SmsStorageFull { get; internal set; }
        }

        public class ApiMonthStatistics
        {
            public ulong CurrentMonthDownload { get; internal set; }
            public ulong CurrentMonthUpload { get; internal set; }
            public string MonthLastClearTime { get; internal set; }
        }

        public class ApiStartDate
        {
            public int DataLimit { get; internal set; }
            public int DataLimitAwoke { get; internal set; }
            public int MonthThreshold { get; internal set; }
            public int SetMonthData { get; internal set; }
            public bool TrafficMaxLimit { get; internal set; }
        }

        public class ApiTrafficStatistics
        {
            public TimeSpan CurrentConnectTime { get; internal set; }
            public ulong CurrentUpload { get; internal set; }
            public ulong CurrentDownload { get; internal set; }
            public int CurrentDownloadRate { get; internal set; }
            public int CurrentUploadRate { get; internal set; }
            public ulong TotalUpload { get; internal set; }
            public ulong TotalDownload { get; internal set; }
            public TimeSpan TotalConnectTime { get; internal set; }
        }

        public class ApiCurrentPlmn
        {
            public string ProviderFullName { get; internal set; }
            public string ProviderShortName { get; internal set; }
            public int ProviderNumeric { get; internal set; }
        }

        public ApiMonitoring Monitoring { get; internal set; }
        public ApiBasicInformation BasicInformation { get; internal set; }
        public ApiPinStatus PinStatus { get; internal set; }
        public ApiDeviceSignal DeviceSignal { get; internal set; }
        public ApiNotifications Notifications { get; internal set; }
        public ApiMonthStatistics MonthStatistics { get; internal set; }
        public ApiStartDate StartDate { get; internal set; }
        public ApiTrafficStatistics TrafficStatistics { get; internal set; }
        public ApiCurrentPlmn CurrentPlmn { get; internal set; }
    }
}

