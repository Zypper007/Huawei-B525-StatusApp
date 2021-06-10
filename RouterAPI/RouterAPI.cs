using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using ReactiveExtensions;
using System.Xml;
using System.Net;
using System.Timers;

namespace Router
{
    public class RouterApi
    {
        public double UpdateInterval {
            get => UpdateOncePerWhile != null && UpdateOncePerWhile.Enabled ? UpdateOncePerWhile.Interval : UpdateIntervalDefault;
            set
            {
                if (UpdateOncePerWhile.Enabled) UpdateOncePerWhile.Interval = value;
                UpdateIntervalDefault = value;
            }
        }
        public bool IsConnected { get; private set; } = false;

        private double UpdateIntervalDefault = 15000;
        // klient http do wykonywana zapytań
        private HttpClient httpClient;
        // strumien obserwowany
        private BehaviorSubject<RouterStates> routerStates;
        // ostatni czas
        private DateTime lastTime;
        private Timer UpdatePerSecound;
        private Timer UpdateOncePerWhile;
        


        public RouterApi ()
	    {
            httpClient = new HttpClient();
        }


        // klasa zwraca stumień do obserwacji
        public IObservable<RouterStates> Connect(Uri url)
        {
            // ustawienie postawowego adresu url, powinno być adresem routera
            httpClient.BaseAddress = url;
            // wysłanie zapytania get w celu uzyskania odpowiedzi z ciasteczkiem sesji
            // nie ma możliwości zweryfikowania serwera http czy to ruter bo nie wysyła żadnych tego typu informacji
            var request = httpClient.GetAsync("");
           
            var response = request.Result;
            if (response.EnsureSuccessStatusCode().StatusCode == HttpStatusCode.OK)
            {
                // ustawienie sessionID do cookies
                var sessionID = from header in response.Headers where header.Key == "Set-Cookie" select header.Value;
                httpClient.DefaultRequestHeaders.Add("Cookie", sessionID.First());

                var MonitoringTask = GetApiMonitoring();
                var BasicInformationTask = GetApiBasicInformation();
                var PinStatusTask = GetApiPinStatus();
                var DeviceSignalTask = GetApiDeviceSignal();
                var NotificationsTask = GetApiNotifications();
                var MonthStatisticsTask = GetApiMonthStatistics();
                var StartDateTask = GetApiStartDate();
                var TrafficStatisticsTask = GetApiTrafficStatistics();
                var CurrentPlmnTask = GetApiCurrentPlmn();

                var s = MonitoringTask.Result;

                Task.WaitAll(new Task[] {
                    MonitoringTask,
                    BasicInformationTask,
                    PinStatusTask,
                    DeviceSignalTask,
                    NotificationsTask,
                    MonthStatisticsTask,
                    StartDateTask,
                    TrafficStatisticsTask,
                    CurrentPlmnTask
                });

                routerStates = new BehaviorSubject<RouterStates>(new RouterStates(
                    MonitoringTask.Result,
                    BasicInformationTask.Result,
                    PinStatusTask.Result,
                    DeviceSignalTask.Result,
                    NotificationsTask.Result,
                    MonthStatisticsTask.Result,
                    StartDateTask.Result,
                    TrafficStatisticsTask.Result,
                    CurrentPlmnTask.Result
                ));

                lastTime = DateTime.Now;

                UpdatePerSecound = new Timer(1000);
                UpdatePerSecound.Elapsed += UpdateTime;
                UpdatePerSecound.Start();

                UpdateOncePerWhile = new Timer(UpdateInterval);

                IsConnected = true;

                return routerStates;
            }
            else
            {
                throw new HttpRequestException("Nie odnaleziono routera");
            }
        }

        public void Disconnect()
        {
            UpdatePerSecound.Stop();
            UpdateOncePerWhile.Stop();
            routerStates.Close();
            UpdateOncePerWhile = null;
            UpdatePerSecound = null;
            routerStates = null;
        }

        private void UpdateStatsOnce(object sender, ElapsedEventArgs args)
        {
            Task.Run(async () =>
            {
                var MonitoringStatus = await GetApiMonitoring();
                var SignalStatus = await GetApiDeviceSignal();
                var NotificationsStatus = await GetApiNotifications();
                var MonthStatisticsStatus = await GetApiMonthStatistics();
                var StartStatus = await GetApiStartDate();
                var TraficStatisticsStatus = await GetApiTrafficStatistics();

                var NewRouterStatus = routerStates.LastValue;

                NewRouterStatus.Monitoring = MonitoringStatus;
                NewRouterStatus.DeviceSignal = SignalStatus;
                NewRouterStatus.Notifications = NotificationsStatus;
                NewRouterStatus.MonthStatistics = MonthStatisticsStatus;
                NewRouterStatus.StartDate = StartStatus;
                NewRouterStatus.TrafficStatistics = TraficStatisticsStatus;

                routerStates.Push(NewRouterStatus);
            });

            

        }

        private void UpdateTime(object sender, ElapsedEventArgs args)
        {
            var deltaTime = args.SignalTime - lastTime;
            lastTime = args.SignalTime;

            var NewRouterStates = routerStates.LastValue;
            NewRouterStates.TrafficStatistics.CurrentConnectTime += deltaTime;
            NewRouterStates.TrafficStatistics.TotalConnectTime += deltaTime;

            routerStates.Push(NewRouterStates);
        }

        // funkcja get do pobierania danuch i tworzenie dokument XML
        // zwraca wyjątek jeśli nie uda się pobrać.
        private async Task<XmlDocument> _get(string path)
        {
            var request = httpClient.GetAsync(path);
            var response = request.Result;
            response.EnsureSuccessStatusCode();
            
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(await response.Content.ReadAsStringAsync());

                return xmlDoc;
        }

        
        private async Task<RouterStates.ApiMonitoring> GetApiMonitoring()
        {
            var xmlDoc = await _get(RouterEndPoints.ApiMonitoringStatus);

            return new RouterStates.ApiMonitoring()
            {
                SignalPower = xmlDoc.GetElementsByTagName("SignalIcon")[0].ToInt32(),
                NetworkType = xmlDoc.GetElementsByTagName("CurrentNetworkTypeEx")[0].ToInt32(),
                CurrentWifiUser = xmlDoc.GetElementsByTagName("CurrentWifiUser")[0].ToInt32(),
                RoamingStatus = xmlDoc.GetElementsByTagName("RoamingStatus")[0].ToBoolean(),
                SimLockStatus = xmlDoc.GetElementsByTagName("simlockStatus")[0].ToBoolean(),
                SimStatus = xmlDoc.GetElementsByTagName("SimStatus")[0].ToBoolean(),
                WifiStatus = xmlDoc.GetElementsByTagName("WifiStatus")[0].ToBoolean(),
                FlyMode = xmlDoc.GetElementsByTagName("flymode")[0].ToBoolean(),
                UsbUp = xmlDoc.GetElementsByTagName("usbup")[0].ToBoolean(),
                PrimaryDns = xmlDoc.GetElementsByTagName("PrimaryDns")[0].InnerText,
                SecondaryDns = xmlDoc.GetElementsByTagName("SecondaryDns")[0].InnerText
            };
        }

        private async Task<RouterStates.ApiBasicInformation> GetApiBasicInformation()
        {
            var xmlDoc = await _get(RouterEndPoints.ApiDeviceBasicInformation);

            return new RouterStates.ApiBasicInformation()
            {
                DeviceName = xmlDoc.GetElementsByTagName("devicename")[0].InnerText,
                SoftwareVersion = xmlDoc.GetElementsByTagName("SoftwareVersion")[0].InnerText,
                WebUIVersion = xmlDoc.GetElementsByTagName("WebUIVersion")[0].InnerText
            };
        }

        private async Task<RouterStates.ApiPinStatus> GetApiPinStatus()
        {
            var xmlDoc = await _get(RouterEndPoints.ApiPinStatus);

            return new RouterStates.ApiPinStatus()
            {
                SimPinTimes = xmlDoc.GetElementsByTagName("SimPinTimes")[0].ToInt32(),
                SimPukTimes = xmlDoc.GetElementsByTagName("SimPukTimes")[0].ToInt32()
            };
        }

        private async Task<RouterStates.ApiDeviceSignal> GetApiDeviceSignal()
        {
            var xmlDoc = await _get(RouterEndPoints.ApiDeviceSignal);
            
            var r = new RouterStates.ApiDeviceSignal()
            {
                RSRQ = xmlDoc.GetElementsByTagName("rsrq")[0].ToInt32(),
                RSRP = xmlDoc.GetElementsByTagName("rsrp")[0].ToInt32(),
                RSSI = xmlDoc.GetElementsByTagName("rssi")[0].ToInt32(),
                SINR = xmlDoc.GetElementsByTagName("sinr")[0].ToInt32(),
                RSCP = xmlDoc.GetElementsByTagName("rscp")[0].ToInt32(),
                ECIO = xmlDoc.GetElementsByTagName("ecio")[0].ToInt32(),
                UploadBandwidth = xmlDoc.GetElementsByTagName("ulbandwidth")[0].ToInt32(),
                DownloadBandwidth = xmlDoc.GetElementsByTagName("dlbandwidth")[0].ToInt32()
            };
            return r;
        }

        private async Task<RouterStates.ApiNotifications> GetApiNotifications()
        {
            var xmlDoc = await _get(RouterEndPoints.ApiMonitoringCheckNotifications);

            return new RouterStates.ApiNotifications()
            {
                UnreadMessage = xmlDoc.GetElementsByTagName("UnreadMessage")[0].ToInt32(),
                SmsStorageFull = xmlDoc.GetElementsByTagName("SmsStorageFull")[0].ToBoolean()
            };
        }

        private async Task<RouterStates.ApiMonthStatistics> GetApiMonthStatistics()
        {
            var xmlDoc = await _get(RouterEndPoints.ApiMonitoringMonthStatistics);

            return new RouterStates.ApiMonthStatistics()
            {
                CurrentMonthDownload = xmlDoc.GetElementsByTagName("CurrentMonthDownload")[0].ToUInt64(),
                CurrentMonthUpload = xmlDoc.GetElementsByTagName("CurrentMonthUpload")[0].ToUInt64(),
                MonthLastClearTime = xmlDoc.GetElementsByTagName("MonthLastClearTime")[0].InnerText
            };
        }

        private async Task<RouterStates.ApiStartDate> GetApiStartDate()
        {
            var xmlDoc = await _get(RouterEndPoints.ApiMonitoringStartDate);

            return new RouterStates.ApiStartDate()
            {
                DataLimit = xmlDoc.GetElementsByTagName("DataLimit")[0].ToInt32(),
                DataLimitAwoke = xmlDoc.GetElementsByTagName("DataLimitAwoke")[0].ToInt32(),
                MonthThreshold = xmlDoc.GetElementsByTagName("MonthThreshold")[0].ToInt32(),
                SetMonthData = xmlDoc.GetElementsByTagName("SetMonthData")[0].ToInt32(),
                TrafficMaxLimit = xmlDoc.GetElementsByTagName("trafficmaxlimit")[0].ToBoolean()
            };
        }

        private async Task<RouterStates.ApiTrafficStatistics> GetApiTrafficStatistics()
        {
            var xmlDoc = await _get(RouterEndPoints.ApiMonitoringTrafficStatistics);

            return new RouterStates.ApiTrafficStatistics()
            {
                CurrentConnectTime = xmlDoc.GetElementsByTagName("CurrentConnectTime")[0].ToTimeSpan(),
                TotalConnectTime = xmlDoc.GetElementsByTagName("TotalConnectTime")[0].ToTimeSpan(),
                CurrentUpload = xmlDoc.GetElementsByTagName("CurrentUpload")[0].ToUInt64(),
                CurrentDownload = xmlDoc.GetElementsByTagName("CurrentDownload")[0].ToUInt64(),
                CurrentDownloadRate = xmlDoc.GetElementsByTagName("CurrentDownloadRate")[0].ToInt32(),
                CurrentUploadRate = xmlDoc.GetElementsByTagName("CurrentUploadRate")[0].ToInt32(),
                TotalUpload = xmlDoc.GetElementsByTagName("TotalUpload")[0].ToUInt64(),
                TotalDownload = xmlDoc.GetElementsByTagName("TotalDownload")[0].ToUInt64()
            };
        }

        private async Task<RouterStates.ApiCurrentPlmn> GetApiCurrentPlmn()
        {
            var xmlDoc = await _get(RouterEndPoints.ApiNetCurrentPlmn);

            return new RouterStates.ApiCurrentPlmn()
            {
                ProviderFullName = xmlDoc.GetElementsByTagName("FullName")[0].InnerText,
                ProviderShortName = xmlDoc.GetElementsByTagName("ShortName")[0].InnerText,
                ProviderNumeric = xmlDoc.GetElementsByTagName("Numeric")[0].ToInt32()
            };
        }
    }

}
