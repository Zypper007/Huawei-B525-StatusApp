using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MainApp
{
    /// <summary>
    /// Logika interakcji dla klasy Signal.xaml
    /// </summary>
    public partial class Signal : UserControl, INotifyPropertyChanged
    {
        private int type = -1;
        public int Type
        {
            get
            {
                return (int)GetValue(TypeProperty);
            }
            set
            {
                if (value == type)
                    return;

                SetValue(TypeProperty, value);
                SetType(value);

                type = value;
            }
        }

        public static readonly DependencyProperty TypeProperty = DependencyProperty.Register( "Type", typeof(int), typeof(Signal),
            new PropertyMetadata(0, (DependencyObject obj, DependencyPropertyChangedEventArgs args) => (obj as Signal).Type = (int)args.NewValue )
        );

        private int power = -1;
        public int Power
        {
            get
            {
                return (int)GetValue(PowerProperty);
            }
            set
            {
                if (value == power)
                    return;

                SetValue(PowerProperty, value);
                SetPower(value);

                power = value;
            }
        }

        public static readonly DependencyProperty PowerProperty = DependencyProperty.Register( "Power", typeof(int), typeof(Signal),
            new PropertyMetadata(0, (DependencyObject obj, DependencyPropertyChangedEventArgs args) => (obj as Signal).Power = (int)args.NewValue)
        );

        private BitmapImage signalImage;

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChenged([CallerMemberName] String propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        public BitmapImage SignalImage => signalImage;

        public Signal()
        {
            InitializeComponent();

            Power = 0;
            Type = 0;
        }

        private void SetType(int type)
        {
            string txt = "";

            switch (type)
            {
                case 000:
                    txt = "NO SIGNAL";
                    break;
                case 001:
                    txt = "GSM";
                    break;
                case 002:
                    txt = "GPRS";
                    break;
                case 003:
                    txt = "EDGE";
                    break;
                case 004:
                case 041:
                    txt = "UMTS";
                    break;
                case 009:
                case 045:
                case 065:
                    txt = "HSPA+";
                    break;
                case 019:
                case 101:
                    txt = "LTE";
                    break;
                case 044:
                case 064:
                    txt = "HSPA";
                    break;
                case 046:
                    txt = "DC-HSPA+";
                    break;
                case 1011:
                    txt = "LTE+";
                    break;
            }

            TypeLabel.Content = txt;
        }

        private void SetPower(int power)
        {

            switch (power)
            {
                case 1:
                    SetSignalImage(SignalResources.icon_signal_01);
                    break;
                case 2:
                    SetSignalImage(SignalResources.icon_signal_02);
                    break;
                case 3:
                    SetSignalImage(SignalResources.icon_signal_03);
                    break;
                case 4:
                    SetSignalImage(SignalResources.icon_signal_04);
                    break;
                case 5:
                    SetSignalImage(SignalResources.icon_signal_05);
                    break;
                default:
                    SetSignalImage(SignalResources.icon_signal_00);
                    break;
            }


        }

        private void SetSignalImage(Bitmap bitmap)
        {
            signalImage = new BitmapImage();
            using (var stream = new MemoryStream())
            {
                bitmap.Save(stream, ImageFormat.Png);
                stream.Position = 0;

                signalImage.BeginInit();
                signalImage.StreamSource = stream;
                signalImage.CacheOption = BitmapCacheOption.OnLoad;
                signalImage.EndInit();
            }
            signalImage.Freeze();
            Img.Source = signalImage;
            NotifyPropertyChenged("SignalImage");

        }
    }
}
