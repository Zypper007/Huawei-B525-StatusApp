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

    class RouterStates
    { 
        private int signalPower;
        public int SignalPower
        {
            get
            {
                return signalPower;
            }
            internal set
            {
                if (value == signalPower)
                    return;

                signalPower = value;
                NotifyPropertyChenged();
            }
        }

        private int networkType;
        public int NetworkType
        {
            get
            {
                return networkType;
            }
            internal set
            {
                if (value == networkType)
                    return;

                networkType = value;
                NotifyPropertyChenged();
            }
        }

        private int currentWifiUser;
        public int CurrentWifiUser
        {
            get
            {
                return currentWifiUser;
            }
            internal set
            {
                if (value == currentWifiUser)
                    return;

                currentWifiUser = value;
                NotifyPropertyChenged();
            }
        }

        private int simPinTimes;
        public int SimPinTimes
        {
            get
            {
                return simPinTimes;
            }
            internal set
            {
                if (value == simPinTimes)
                    return;

                simPinTimes = value;
                NotifyPropertyChenged();
            }
        }

        private int simPukTimes;
        public int SimPukTimes
        {
            get
            {
                return simPukTimes;
            }
            internal set
            {
                if (value == simPukTimes)
                    return;

                simPukTimes = value;
                NotifyPropertyChenged();
            }
        }

        private int rsrq;
        public int RSRQ
        {
            get
            {
                return rsrq;
            }
            internal set
            {
                if (value == rsrq)
                    return;

                rsrq = value;
                NotifyPropertyChenged();
            }
        }

        private int rsrp;
        public int RSRP
        {
            get
            {
                return rsrp;
            }
            internal set
            {
                if (value == rsrp)
                    return;

                rsrp = value;
                NotifyPropertyChenged();
            }
        }

        private int rssi;
        public int RSSI
        {
            get
            {
                return rssi;
            }
            internal set
            {
                if (value == rssi)
                    return;

                rssi = value;
                NotifyPropertyChenged();
            }
        }

        private int rscp;
        public int RSCP
        {
            get
            {
                return rscp;
            }
            internal set
            {
                if (value == rscp)
                    return;

                rscp = value;
                NotifyPropertyChenged();
            }
        }

        private int sinr;
        public int SINR
        {
            get
            {
                return sinr;
            }
            internal set
            {
                if (value == sinr)
                    return;

                sinr = value;
                NotifyPropertyChenged();
            }
        }

        private int ecio;
        public int ECIO
        {
            get
            {
                return ecio;
            }
            internal set
            {
                if (value == ecio)
                    return;

                ecio = value;
                NotifyPropertyChenged();
            }
        }

        private int uploadBandwidth;
        public int UploadBandwidth
        {
            get
            {
                return uploadBandwidth;
            }
            internal set
            {
                if (value == uploadBandwidth)
                    return;

                uploadBandwidth = value;
                NotifyPropertyChenged();
            }
        }

        private int downloadBandwidth;
        public int DownloadBandwidth
        {
            get
            {
                return downloadBandwidth;
            }
            internal set
            {
                if (value == downloadBandwidth)
                    return;

                downloadBandwidth = value;
                NotifyPropertyChenged();
            }
        }

        private int unreadMessage;
        public int UnreadMessage
        {
            get
            {
                return unreadMessage;
            }
            internal set
            {
                if (value == unreadMessage)
                    return;

                unreadMessage = value;
                NotifyPropertyChenged();
            }
        }

        private int dataLimit;
        public int DataLimit
        {
            get
            {
                return dataLimit;
            }
            internal set
            {
                if (value == dataLimit)
                    return;

                dataLimit = value;
                NotifyPropertyChenged();
            }
        }

        private int dataLimitAwoke;
        public int DataLimitAwoke
        {
            get
            {
                return dataLimitAwoke;
            }
            internal set
            {
                if (value == dataLimitAwoke)
                    return;

                dataLimitAwoke = value;
                NotifyPropertyChenged();
            }
        }

        private int monthThreshold;
        public int MonthThreshold
        {
            get
            {
                return monthThreshold;
            }
            internal set
            {
                if (value == monthThreshold)
                    return;

                monthThreshold = value;
                NotifyPropertyChenged();
            }
        }

        private int setMonthData;
        public int SetMonthData
        {
            get
            {
                return setMonthData;
            }
            internal set
            {
                if (value == setMonthData)
                    return;

                setMonthData = value;
                NotifyPropertyChenged();
            }
        }

        private int currentDownloadRate;
        public int CurrentDownloadRate
        {
            get
            {
                return currentDownloadRate;
            }
            internal set
            {
                if (value == currentDownloadRate)
                    return;

                currentDownloadRate = value;
                NotifyPropertyChenged();
            }
        }

        private int currentUploadRate;
        public int CurrentUploadRate
        {
            get
            {
                return currentUploadRate;
            }
            internal set
            {
                if (value == currentUploadRate)
                    return;

                currentUploadRate = value;
                NotifyPropertyChenged();
            }
        }

        private int providerNumeric;
        public int ProviderNumeric
        {
            get
            {
                return providerNumeric;
            }
            internal set
            {
                if (value == providerNumeric)
                    return;

                providerNumeric = value;
                NotifyPropertyChenged();
            }
        }


        private bool roamingStatus;
        public bool RoamingStatus
        {
            get
            {
                return roamingStatus;
            }
            internal set
            {
                if (value == roamingStatus)
                    return;

                roamingStatus = value;
                NotifyPropertyChenged();
            }
        }

        private bool trafficMaxLimit;
        public bool TrafficMaxLimit
        {
            get
            {
                return trafficMaxLimit;
            }
            internal set
            {
                if (value == trafficMaxLimit)
                    return;

                trafficMaxLimit = value;
                NotifyPropertyChenged();
            }
        }

        private bool smsStorageFull;
        public bool SmsStorageFull
        {
            get
            {
                return smsStorageFull;
            }
            internal set
            {
                if (value == smsStorageFull)
                    return;

                smsStorageFull = value;
                NotifyPropertyChenged();
            }
        }

        private bool simLockStatus;
        public bool SimLockStatus
        {
            get
            {
                return simLockStatus;
            }
            internal set
            {
                if (value == simLockStatus)
                    return;

                simLockStatus = value;
                NotifyPropertyChenged();
            }
        }

        private bool simStatus;
        public bool SimStatus
        {
            get
            {
                return simStatus;
            }
            internal set
            {
                if (value == simStatus)
                    return;

                simStatus = value;
                NotifyPropertyChenged();
            }
        }

        private bool wifiStatus;
        public bool WifiStatus
        {
            get
            {
                return wifiStatus;
            }
            internal set
            {
                if (value == wifiStatus)
                    return;

                wifiStatus = value;
                NotifyPropertyChenged();
            }
        }

        private bool flyMode;
        public bool FlyMode
        {
            get
            {
                return flyMode;
            }
            internal set
            {
                if (value == flyMode)
                    return;

                flyMode = value;
                NotifyPropertyChenged();
            }
        }

        private bool usbUp;
        public bool UsbUp
        {
            get
            {
                return usbUp;
            }
            internal set
            {
                if (value == usbUp)
                    return;

                usbUp = value;
                NotifyPropertyChenged();
            }
        }

        private ulong currentMonthDownload;
        public ulong CurrentMonthDownload
        {
            get
            {
                return currentMonthDownload;
            }
            internal set
            {
                if (value == currentMonthDownload)
                    return;

                currentMonthDownload = value;
                NotifyPropertyChenged();
            }
        }

        private ulong currentMonthUpload;
        public ulong CurrentMonthUpload
        {
            get
            {
                return currentMonthUpload;
            }
            internal set
            {
                if (value == currentMonthUpload)
                    return;

                currentMonthUpload = value;
                NotifyPropertyChenged();
            }
        }

        private ulong currentUpload;
        public ulong CurrentUpload
        {
            get
            {
                return currentUpload;
            }
            internal set
            {
                if (value == currentUpload)
                    return;

                currentUpload = value;
                NotifyPropertyChenged();
            }
        }

        private ulong currentDownload;
        public ulong CurrentDownload
        {
            get
            {
                return currentDownload;
            }
            internal set
            {
                if (value == currentDownload)
                    return;

                currentDownload = value;
                NotifyPropertyChenged();
            }
        }

        private ulong totalUpload;
        public ulong TotalUpload
        {
            get
            {
                return totalUpload;
            }
            internal set
            {
                if (value == totalUpload)
                    return;

                totalUpload = value;
                NotifyPropertyChenged();
            }
        }

        private ulong totalDownload;
        public ulong TotalDownload
        {
            get
            {
                return totalDownload;
            }
            internal set
            {
                if (value == totalDownload)
                    return;

                totalDownload = value;
                NotifyPropertyChenged();
            }
        }


        private string webUIVersion;
        public string WebUIVersion
        {
            get
            {
                return webUIVersion;
            }
            internal set
            {
                if (value == webUIVersion)
                    return;

                webUIVersion = value;
                NotifyPropertyChenged();
            }
        }

        private string softwareVersion;
        public string SoftwareVersion
        {
            get
            {
                return softwareVersion;
            }
            internal set
            {
                if (value == softwareVersion)
                    return;

                softwareVersion = value;
                NotifyPropertyChenged();
            }
        }

        private string deviceName;
        public string DeviceName
        {
            get
            {
                return deviceName;
            }
            internal set
            {
                if (value == deviceName)
                    return;

                deviceName = value;
                NotifyPropertyChenged();
            }
        }

        private string primaryDns;
        public string PrimaryDns
        {
            get
            {
                return primaryDns;
            }
            internal set
            {
                if (value == primaryDns)
                    return;

                primaryDns = value;
                NotifyPropertyChenged();
            }
        }

        private string secondaryDns;
        public string SecondaryDns
        {
            get
            {
                return secondaryDns;
            }
            internal set
            {
                if (value == secondaryDns)
                    return;

                secondaryDns = value;
                NotifyPropertyChenged();
            }
        }

        private string providerFullName;
        public string ProviderFullName
        {
            get
            {
                return providerFullName;
            }
            internal set
            {
                if (value == providerFullName)
                    return;

                providerFullName = value;
                NotifyPropertyChenged();
            }
        }

        private string providerShortName;
        public string ProviderShortName
        {
            get
            {
                return providerShortName;
            }
            internal set
            {
                if (value == providerShortName)
                    return;

                providerShortName = value;
                NotifyPropertyChenged();
            }
        }

        private string monthLastClearTime;
        public string MonthLastClearTime
        {
            get
            {
                return monthLastClearTime;
            }
            internal set
            {
                if (value == monthLastClearTime)
                    return;

                monthLastClearTime = value;
                NotifyPropertyChenged();
            }
        }

        private TimeSpan currentConnectTime;
        public TimeSpan CurrentConnectTime
        {
            get
            {
                return currentConnectTime;
            }
            internal set
            {
                if (value == currentConnectTime)
                    return;

                currentConnectTime = value;
                NotifyPropertyChenged();
            }
        }

        private TimeSpan totalConnectTime;
        public TimeSpan TotalConnectTime
        {
            get
            {
                return totalConnectTime;
            }
            internal set
            {
                if (value == totalConnectTime)
                    return;

                totalConnectTime = value;
                NotifyPropertyChenged();
            }
        }


        private void NotifyPropertyChenged([CallerMemberName] String propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}

