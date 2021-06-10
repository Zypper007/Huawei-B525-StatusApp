using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ReactiveExtensions;
using Hardcodet.Wpf.TaskbarNotification;
using Router;
using System.Windows.Media.Imaging;
using System.IO;

namespace MainApp
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool IsConnected => routerAPI.IsConnected;
        public RouterStates DataBindingValue => ((NotifyProprertyChangeObserver<RouterStates>)observer).Value;


        private RouterApi routerAPI;
        private IObserver<RouterStates> observer;

        private Regex regForInput = new Regex(@"^[0-9|\.]+");
        private Regex regForValidIP = new Regex(@"^[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}$");

        public MainWindow()
        {
            InitializeComponent();
            TaskbarIcon.Icon = SetTaskbarIcon(SignalControl.SignalImage);
            SignalControl.PropertyChanged += ChangeIconbar;
        }

        private System.Drawing.Icon SetTaskbarIcon(BitmapImage image)
        {
            System.Drawing.Bitmap bitmap;

            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(image));
                enc.Save(outStream);
                bitmap = new System.Drawing.Bitmap(outStream);
                bitmap.MakeTransparent();
                //return new Bitmap(bitmap);
            }
            return System.Drawing.Icon.FromHandle(bitmap.GetHicon());
        }

        private void ChangeIconbar(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            TaskbarIcon.Icon = SetTaskbarIcon(SignalControl.SignalImage);
        }

        private void AddressInput_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !regForInput.IsMatch(e.Text);
        }

        private void AddressButton_Click(object sender, RoutedEventArgs e)
        {
            routerAPI = new RouterApi();
            observer = new NotifyProprertyChangeObserver<RouterStates>();

            var self = sender as Button;
            self.IsEnabled = false;
            
            if(regForValidIP.IsMatch(AddressInput.Text))
            {
                try
                {
                    var observable = routerAPI.Connect(new Uri($"http://{AddressInput.Text}"));
                    observable.Subscribe(observer);
                    observable.Subscribe(new ConsoleLogObserver<RouterStates>());

                    DataContext = (NotifyProprertyChangeObserver<RouterStates>)observer;

                }
                catch (Exception err)
                {
                    MessageBox.Show("Wystąpił błąd: " + err.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                    self.IsEnabled = true;

                }
            } 
            else
            {
                MessageBox.Show("Niepoprawny adres IP", "Adres IP", MessageBoxButton.OK, MessageBoxImage.Information);
                self.IsEnabled = true;
            }

        }



    }
}
