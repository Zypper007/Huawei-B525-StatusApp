using ReactiveExtensions;
using Router;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MainApp
{
    // Konwertuje TimeSpan to przejrzystej formy daty
    public class TimeSpanToDateConventer : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is TimeSpan)
            {
                var v = (TimeSpan)value;
                return v.ToString(@"%d\ \d\a\y\s\ hh\:mm\:ss");
            }
            else throw new Exception("value is not type of TimeSpan");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    // Konwertuje DateTime do czytelnej formy
    public class DateFromStringConventer : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var date = DateTime.Parse(value as string);
                return date.ToString(@"dd MMMM yyyy");
            }
            catch (Exception err)
            {
                Debug.Print(err.Message);
                return String.Empty;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    // Konwertuje byte do KB, MB, GB, TB
    public class BytesConventer : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ulong)
            {
                var bytes = (ulong)value;
                string[] Suffix = { "B", "KB", "MB", "GB", "TB" };
                int i;
                double dblSByte = bytes;

                for (i = 0; i < Suffix.Length && bytes >= 1024; i++, bytes /= 1024)
                {
                    dblSByte = bytes / 1024.0;
                }

                return String.Format("{0:0.##} {1}", dblSByte, Suffix[i]);
            }
            else throw new Exception("value isn't ulong");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    // Wyśwetla szybkość łącza na sekundę
    public class BytesPerSecondConventer : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return String.Format("{0:0.00} Mb/s", (int)value / 1024.0f);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public enum SignalEnum
    {
        Value,
        Color,
        Type
    }
    public static class SignalColros
    {
        public static SolidColorBrush VeryPoor = new SolidColorBrush(Color.FromRgb(82, 0, 0));
        public static SolidColorBrush Poor = new SolidColorBrush(Color.FromRgb(0xC2, 00, 00));
        public static SolidColorBrush Fair = new SolidColorBrush(Color.FromRgb(0xC3, 0x7A, 06));
        public static SolidColorBrush Good = new SolidColorBrush(Color.FromRgb(0xE7, 0xE0, 00));
        public static SolidColorBrush Exelent = new SolidColorBrush(Color.FromRgb(0x5D, 0xED, 04));
        public static SolidColorBrush None = new SolidColorBrush(Color.FromArgb(0x00, 0xff, 0xff, 0xff));
    }


    public class RSRQconventer : IValueConverter
    {
        readonly MainWindow myWin = (MainWindow)App.Current.MainWindow;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var v = (int)value;
            var param = (SignalEnum)parameter;
            int exellent = -10, good = -15, fair = -20;

            switch (param)
            {
                case SignalEnum.Value:
                    if (!myWin.IsConnected)
                        return String.Empty;
                    return $"{v} dB";

                case SignalEnum.Color:
                    if (!myWin.IsConnected)
                        return SignalColros.None;

                    if (v >= exellent)
                        return SignalColros.Exelent;
                    else if (v >= good)
                        return SignalColros.Good;
                    else if (v >= fair)
                        return SignalColros.Fair;
                    else return SignalColros.None;

                case SignalEnum.Type:
                    if (!myWin.IsConnected)
                        return String.Empty;

                    if (v >= exellent)
                        return "Exelent";
                    else if (v >= good)
                        return "Good";
                    else if (v >= fair)
                        return "Fair to poor";
                    else return "No signal";

                default:
                    throw new Exception("Parametr isn't set");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class RSSIconventer : IValueConverter
    {
        readonly MainWindow myWin = (MainWindow)App.Current.MainWindow;

        bool is4G(int typeSignal)
        {
            switch (typeSignal)
            {
                case 19:
                case 101:
                case 1011:
                    return true;
                default:
                    return false;
            }
        }

        void SetRange(bool is4G, out int exellent, out int good, out int fair, out int poor)
        {
            if (is4G)
            {
                exellent = -65;
                good = -75;
                fair = -85;
                poor = -95;
            }
            else
            {
                exellent = -70;
                good = -85;
                fair = -100;
                poor = -110;
            }
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var v = (int)value;
            var param = (SignalEnum)parameter;
            int exellent, good, fair, poor;

            SetRange(is4G(myWin.DataBindingValue.Monitoring.NetworkType), out exellent, out good, out fair, out poor);

            switch (param)
            {
                case SignalEnum.Value:
                    if (!myWin.IsConnected)
                        return String.Empty;
                    return $"{v} dBm";

                case SignalEnum.Color:
                    if (!myWin.IsConnected)
                        return SignalColros.None;

                    if (v >= exellent)
                        return SignalColros.Exelent;
                    else if (v < exellent && v >= good)
                        return SignalColros.Good;
                    else if (v < good && v >= fair)
                        return SignalColros.Fair;
                    else if (v < fair && v >= poor)
                        return SignalColros.Poor;
                    else return SignalColros.None;

                case SignalEnum.Type:
                    if (!myWin.IsConnected)
                        return String.Empty;

                    if (v >= exellent)
                        return "Exelent";
                    else if (v < exellent && v >= good)
                        return "Good";
                    else if (v < good && v >= fair)
                        return "Fair";
                    else if (v < fair && v >= poor)
                        return "Poor";
                    else return "No signal";

                default:
                    throw new Exception("Parametr isn't set");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class RSCPconventer : IValueConverter
    {
        readonly MainWindow myWin = (MainWindow)App.Current.MainWindow;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var v = (int)value;
            var param = (SignalEnum)parameter;
            int exellent = -60, good = -75, fair = -85, poor = -95, veryPoor = -124;

            switch (param)
            {
                case SignalEnum.Value:
                    if (!myWin.IsConnected)
                        return String.Empty;
                    return v;

                case SignalEnum.Color:
                    if (!myWin.IsConnected)
                        return SignalColros.None;

                    if (v <= 0 && v >= exellent)
                        return SignalColros.Exelent;
                    else if (v >= good)
                        return SignalColros.Good;
                    else if (v >= fair)
                        return SignalColros.Fair;
                    else if (v >= poor)
                        return SignalColros.Poor;
                    else if (v >= veryPoor)
                        return SignalColros.VeryPoor;
                    else return SignalColros.None;

                case SignalEnum.Type:
                    if (!myWin.IsConnected)
                        return String.Empty;

                    if (v <= 0 && v >= exellent)
                        return "Exellent";
                    else if (v >= good)
                        return "Good";
                    else if (v >= fair)
                        return "Fair";
                    else if (v >= poor)
                        return "Poor";
                    else if (v >= veryPoor)
                        return "Very poor";
                    else return "No Signal";

                default:
                    throw new Exception("Parametr isn't set");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class SINRconventer : IValueConverter
    {
        readonly MainWindow myWin = (MainWindow)App.Current.MainWindow;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var v = (int)value;
            var param = (SignalEnum)parameter;
            int exellent = 20, good = 13, fair = 0;

            switch (param)
            {
                case SignalEnum.Value:
                    if (!myWin.IsConnected)
                        return String.Empty;
                    return $"{v} dB";

                case SignalEnum.Color:
                    if (!myWin.IsConnected)
                        return SignalColros.None;

                    if (v >= exellent)
                        return SignalColros.Exelent;
                    else if (v >= good)
                        return SignalColros.Good;
                    else if (v >= fair)
                        return SignalColros.Fair;
                    else return SignalColros.None;

                case SignalEnum.Type:
                    if (!myWin.IsConnected)
                        return String.Empty;

                    if (v >= exellent)
                        return "Exelent";
                    else if (v >= good)
                        return "Good";
                    else if (v >= fair)
                        return "Fair to poor";
                    else return "No signal";

                default:
                    throw new Exception("Parametr isn't set");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class ECIOconventer : IValueConverter
    {
        readonly MainWindow myWin = (MainWindow)App.Current.MainWindow;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var v = (int)value;
            var param = (SignalEnum)parameter;
            int exellent = -6, good = -10, fair = -20;

            switch (param)
            {
                case SignalEnum.Value:
                    if (!myWin.IsConnected)
                        return String.Empty;
                    return $"{v} dB";

                case SignalEnum.Color:
                    if (!myWin.IsConnected)
                        return SignalColros.None;

                    if (v >= exellent && v <= 0)
                        return SignalColros.Exelent;
                    else if (v >= good)
                        return SignalColros.Good;
                    else if (v >= fair)
                        return SignalColros.Poor;
                    else return SignalColros.None;

                case SignalEnum.Type:
                    if (!myWin.IsConnected)
                        return String.Empty;

                    if (v >= exellent)
                        return "Exelent";
                    else if (v >= good)
                        return "Good";
                    else if (v >= fair)
                        return "Fair to poor";
                    else return "No signal";

                default:
                    throw new Exception("Parametr isn't set");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
 
    public class MHZconventer : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return $"{value} Mhz";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class BitmapImageToIcon : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is BitmapImage)
            {
                var val = (value as BitmapImage);

                return new System.Drawing.Icon(val.StreamSource);
            }
            else throw new Exception("value isin't type of BitmapImage");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class SignalFontSizeConventer : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double)
            {
                return (double)value * 0.6;
            }
            else throw new Exception("value is not double");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
