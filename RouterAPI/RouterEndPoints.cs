using System;

namespace Router
{
	internal static class RouterEndPoints
	{
		//zwaraca odpowiedź :
		/*<?xml version="1.0" encoding="UTF-8"?>
		<response>
			<ConnectionStatus>901</ConnectionStatus>
			<WifiConnectionStatus></WifiConnectionStatus>
			<SignalStrength></SignalStrength>
			<SignalIcon>3</SignalIcon>
			<CurrentNetworkType>19</CurrentNetworkType>
			<CurrentServiceDomain>3</CurrentServiceDomain>
			<RoamingStatus>0</RoamingStatus>
			<BatteryStatus></BatteryStatus>
			<BatteryLevel></BatteryLevel>
			<BatteryPercent></BatteryPercent>
			<simlockStatus>0</simlockStatus>
			<PrimaryDns>212.2.127.254</PrimaryDns>
			<SecondaryDns>212.2.96.52</SecondaryDns>
			<PrimaryIPv6Dns></PrimaryIPv6Dns>
			<SecondaryIPv6Dns></SecondaryIPv6Dns>
			<CurrentWifiUser>7</CurrentWifiUser>
			<TotalWifiUser>64</TotalWifiUser>
			<currenttotalwifiuser>32</currenttotalwifiuser>
			<ServiceStatus>2</ServiceStatus>
			<SimStatus>1</SimStatus>
			<WifiStatus>1</WifiStatus>
			<CurrentNetworkTypeEx>101</CurrentNetworkTypeEx>
			<maxsignal>5</maxsignal>
			<wifiindooronly>0</wifiindooronly>
			<wififrequence>1</wififrequence>
			<classify>cpe</classify>
			<flymode>0</flymode>
			<cellroam>1</cellroam>
			<usbup>0</usbup>
		</response>*/
		internal static string ApiMonitoringStatus = "api/monitoring/status";

		// zwraca odpowiedź:
		/*<?xml version="1.0" encoding="UTF-8"?>
		<response>
			<UnreadMessage>0</UnreadMessage>
			<SmsStorageFull>0</SmsStorageFull>
			<OnlineUpdateStatus>10</OnlineUpdateStatus>
		</response>*/
		internal static string ApiMonitoringCheckNotifications = "api/monitoring/check-notifications";

		// zwraca odpowiedź:
		/*<?xml version="1.0" encoding="UTF-8"?>
		<response>
			<CurrentMonthDownload>217292003681</CurrentMonthDownload>
			<CurrentMonthUpload>23679007805</CurrentMonthUpload>
			<MonthDuration>1731261</MonthDuration>
			<MonthLastClearTime>2021-4-2</MonthLastClearTime>
		</response>*/
		internal static string ApiMonitoringMonthStatistics = "api/monitoring/month_statistics";

		// zwraca odpowiedź:
		/*<?xml version="1.0" encoding="UTF-8"?>
		<response>
			<StartDay>1</StartDay>
			<DataLimit>0MB</DataLimit>
			<DataLimitAwoke>0</DataLimitAwoke>
			<MonthThreshold>90</MonthThreshold>
			<SetMonthData>0</SetMonthData>
			<trafficmaxlimit>0</trafficmaxlimit>
			<turnoffdataenable>0</turnoffdataenable>
			<turnoffdataswitch>0</turnoffdataswitch>
			<turnoffdataflag>0</turnoffdataflag>
		</response>*/
		internal static string ApiMonitoringStartDate = "api/monitoring/start_date";

		// zwraca odpowiedź
		/*<?xml version="1.0" encoding="UTF-8"?>
		<response>
			<CurrentConnectTime>71370</CurrentConnectTime>
			<CurrentUpload>1141907955</CurrentUpload>
			<CurrentDownload>4279786342</CurrentDownload>
			<CurrentDownloadRate>156</CurrentDownloadRate>
			<CurrentUploadRate>1490</CurrentUploadRate>
			<TotalUpload>23679682682</TotalUpload>
			<TotalDownload>217298263292</TotalDownload>
			<TotalConnectTime>1731515</TotalConnectTime>
			<showtraffic>1</showtraffic>
		</response> */
		internal static string ApiMonitoringTrafficStatistics = "api/monitoring/traffic-statistics";

		// zwraca odpowiedź
		/*<?xml version="1.0" encoding="UTF-8"?>
		<response>
			<productfamily>LTE</productfamily>
			<classify>cpe</classify>
			<multimode>0</multimode>
			<restore_default_status>0</restore_default_status>
			<sim_save_pin_enable>0</sim_save_pin_enable>
			<devicename>B525s-23a</devicename>
			<SoftwareVersion>11.236.01.02.69</SoftwareVersion>
			<WebUIVersion>21.100.31.00.03</WebUIVersion>
		</response> */
		internal static string ApiDeviceBasicInformation = "api/device/basic_information";

		// zwraca odpowiedź
		/*<?xml version="1.0" encoding="UTF-8"?>
		<response>
			<pci>0</pci>
			<sc></sc>
			<cell_id>3313439</cell_id>
			<rsrq>-9dB</rsrq>
			<rsrp>-105dBm</rsrp>
			<rssi>-79dBm</rssi>
			<sinr>6dB</sinr>
			<rscp></rscp>
			<ecio></ecio>
			<mode>7</mode>
			<ulbandwidth>20MHz</ulbandwidth>
			<dlbandwidth>20MHz</dlbandwidth>
			<txpower>PPusch:14dBm PPucch:4dBm PSrs:19dBm PPrach:22dBm</txpower>
			<tdd></tdd>
			<ul_mcs>mcsUpCarrier1:20</ul_mcs>
			<dl_mcs>mcsDownCarrier1Code0:2 mcsDownCarrier1Code1:15 </dl_mcs>
			<earfcn>DL:2850 UL:20850</earfcn>
			<rrc_status>1</rrc_status>
			<rac></rac>
			<lac></lac>
			<tac>11019</tac>
			<band>7</band>
			<nei_cellid>No1:494No2:493</nei_cellid>
			<plmn>26001</plmn>
			<ims>0</ims>
		</response> */
		internal static string ApiDeviceSignal = "api/device/signal";

		// zwraca odpowedz
		/*<?xml version="1.0" encoding="UTF-8"?>
		<response>
			<SimState>257</SimState>
			<PinOptState>258</PinOptState>
			<SimPinTimes>3</SimPinTimes>
			<SimPukTimes>10</SimPukTimes>
			<Checkboxchecked>1</Checkboxchecked>
		</response> */
		internal static string ApiPinStatus = "api/pin/status";

		// zwraca odpowiedz 
		/*<?xml version="1.0" encoding="UTF-8"?>
		<response>
			<State>0</State>
			<FullName>Cyfrowy Polsat</FullName>
			<ShortName>CP</ShortName>
			<Numeric>26001</Numeric>
			<Rat>7</Rat>
			<Spn></Spn>
		</response> */
		internal static string ApiNetCurrentPlmn = "api/net/current-plmn";
	}
}

