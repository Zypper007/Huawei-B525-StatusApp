using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Router
{

    // klasa mapuje odpowiedzi na zmienne w c#
    // zawiera wewnętrzne klasy dla ułatwienia łatwiejszych zapytań
    // klasy wewnętrzne mogą być rzutowane nie jawnie w do klasy zewnętrznej
    // klasa zewnętrzna może być rzuto nie jawnie do klas wewnętrznych


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

            public static implicit operator RouterStates(ApiMonitoring self) => new RouterStates() { Monitoring = self};

            public override string ToString()
            {
                return $"Monitoring:\n" +
                    $"\t SignalPower: {SignalPower}\n" +
                    $"\t NetworkType: {NetworkType}\n" +
                    $"\t CurrentWifiUser: {CurrentWifiUser}\n" +
                    $"\t RoamingStatus: {RoamingStatus}\n" +
                    $"\t SimLockStatus: {SimLockStatus}\n" +
                    $"\t SimStatus: {SimStatus}\n" +
                    $"\t WifiStatus: {WifiStatus}\n" +
                    $"\t FlyMode: {FlyMode}\n" +
                    $"\t FlyMoUsbUpde: {UsbUp}\n" +
                    $"\t PrimaryDns: {PrimaryDns}\n" +
                    $"\t SecondaryDns: {SecondaryDns}\n";
            }
        }

        public class ApiBasicInformation
        {
            public string DeviceName { get; internal set; }
            public string SoftwareVersion { get; internal set; }
            public string WebUIVersion { get; internal set; }

            public static implicit operator RouterStates(ApiBasicInformation self) => new RouterStates() { BasicInformation = self };

            public override string ToString()
            {
                return $"BasicInformation:\n" +
                    $"\t DeviceName: {DeviceName}\n" +
                    $"\t SoftwareVersion: {SoftwareVersion}\n" +
                    $"\t WebUIVersion: {WebUIVersion}\n";
            }
        }

        public class ApiPinStatus
        {
            public int SimPinTimes { get; internal set; }
            public int SimPukTimes { get; internal set; }

            public static implicit operator RouterStates(ApiPinStatus self) => new RouterStates() { PinStatus = self };

            public override string ToString()
            {
                return $"PinStatus:\n" +
                    $"\t SimPinTimes: {SimPinTimes}\n" +
                    $"\t SimPukTimes: {SimPukTimes}\n";
            }
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

            public static implicit operator RouterStates(ApiDeviceSignal self) => new RouterStates() { DeviceSignal = self };

            public override string ToString()
            {
                return $"DeviceSignal:\n" +
                   $"\t RSRQ: {RSRQ}\n" +
                   $"\t RSRP: {RSRP}\n" +
                   $"\t RSSI: {RSSI}\n" +
                   $"\t SINR: {SINR}\n" +
                   $"\t RSCP: {RSCP}\n" +
                   $"\t ECIO: {ECIO}\n" +
                   $"\t UploadBandwidth: {UploadBandwidth}\n" +
                   $"\t DownloadBandwidth: {DownloadBandwidth}\n";
            }
        }

        public class ApiNotifications
        {
            public int UnreadMessage { get; internal set; }
            public bool SmsStorageFull { get; internal set; }

            public static implicit operator RouterStates(ApiNotifications self) => new RouterStates() { Notifications = self };

            public override string ToString()
            {
                return $"Notifications:\n" +
                   $"\t UnreadMessage: {UnreadMessage}\n" +
                   $"\t SmsStorageFull: {SmsStorageFull}\n";
            }
        }

        public class ApiMonthStatistics
        {
            public ulong CurrentMonthDownload { get; internal set; }
            public ulong CurrentMonthUpload { get; internal set; }
            public string MonthLastClearTime { get; internal set; }

            public static implicit operator RouterStates(ApiMonthStatistics self) => new RouterStates() { MonthStatistics = self };

            public override string ToString()
            {
                return $"MonthStatistics:\n" +
                   $"\t CurrentMonthDownload: {CurrentMonthDownload}\n" +
                   $"\t CurrentMonthUpload: {CurrentMonthUpload}\n" +
                   $"\t MonthLastClearTime: {MonthLastClearTime}\n";
            }
        }

        public class ApiStartDate
        {
            public int DataLimit { get; internal set; }
            public int DataLimitAwoke { get; internal set; }
            public int MonthThreshold { get; internal set; }
            public int SetMonthData { get; internal set; }
            public bool TrafficMaxLimit { get; internal set; }

            public static implicit operator RouterStates(ApiStartDate self) => new RouterStates() { StartDate = self };

            public override string ToString()
            {
                return $"StartDate:\n" +
                   $"\t DataLimit: {DataLimit}\n" +
                   $"\t DataLimitAwoke: {DataLimitAwoke}\n" +
                   $"\t MonthThreshold: {MonthThreshold}\n" +
                   $"\t SetMonthData: {SetMonthData}\n" +
                   $"\t TrafficMaxLimit: {TrafficMaxLimit}\n";
            }
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

            public static implicit operator RouterStates(ApiTrafficStatistics self) => new RouterStates() { TrafficStatistics = self };

            public override string ToString()
            {
                return $"TrafficStatistics:\n" +
                   $"\t CurrentConnectTime: {CurrentConnectTime}\n" +
                   $"\t CurrentUpload: {CurrentUpload}\n" +
                   $"\t CurrentDownload: {CurrentDownload}\n" +
                   $"\t CurrentDownloadRate: {CurrentDownloadRate}\n" +
                   $"\t CurrentUploadRate: {CurrentUploadRate}\n" +
                   $"\t TotalUpload: {TotalUpload}\n" +
                   $"\t TotalDownload: {TotalDownload}\n" +
                   $"\t TotalConnectTime: {TotalConnectTime}\n";
            }
        }

        public class ApiCurrentPlmn
        {
            public string ProviderFullName { get; internal set; }
            public string ProviderShortName { get; internal set; }
            public int ProviderNumeric { get; internal set; }

            public static implicit operator RouterStates(ApiCurrentPlmn self) => new RouterStates() { CurrentPlmn = self };

            public override string ToString()
            {
                return $"CurrentPlmn:\n" +
                   $"\t ProviderFullName: {ProviderFullName}\n" +
                   $"\t ProviderShortName: {ProviderShortName}\n" +
                   $"\t ProviderNumeric: {ProviderNumeric}\n";
            }
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

        public RouterStates(){}

        public RouterStates(
            ApiMonitoring Monitoring,
            ApiBasicInformation BasicInformation,
            ApiPinStatus PinStatus,
            ApiDeviceSignal DeviceSignal,
            ApiNotifications Notifications,
            ApiMonthStatistics MonthStatistics,
            ApiStartDate StartDate,
            ApiTrafficStatistics TrafficStatistics,
            ApiCurrentPlmn CurrentPlmn
        )
        {
             this.Monitoring = Monitoring;
            this.BasicInformation = BasicInformation;
            this.PinStatus = PinStatus;
            this.DeviceSignal = DeviceSignal;
            this.Notifications = Notifications;
            this.MonthStatistics = MonthStatistics;
            this.StartDate = StartDate;
            this.TrafficStatistics = TrafficStatistics;
            this.CurrentPlmn = CurrentPlmn;
        }

        public static implicit operator ApiMonitoring(RouterStates self) => self.Monitoring;
        public static implicit operator ApiBasicInformation(RouterStates self) => self.BasicInformation;
        public static implicit operator ApiPinStatus(RouterStates self) => self.PinStatus;
        public static implicit operator ApiDeviceSignal(RouterStates self) => self.DeviceSignal;
        public static implicit operator ApiNotifications(RouterStates self) => self.Notifications;
        public static implicit operator ApiMonthStatistics(RouterStates self) => self.MonthStatistics;
        public static implicit operator ApiStartDate(RouterStates self) => self.StartDate;
        public static implicit operator ApiTrafficStatistics(RouterStates self) => self.TrafficStatistics;
        public static implicit operator ApiCurrentPlmn(RouterStates self) => self.CurrentPlmn;

        public override string ToString()
        {
            return "\n====================================\n\n" +
                Monitoring +
                BasicInformation +
                PinStatus +
                DeviceSignal +
                Notifications +
                MonthStatistics +
                StartDate +
                TrafficStatistics +
                CurrentPlmn +
                "\n====================================\n\n";
        }
    }
}

