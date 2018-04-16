using System;
using System.Collections.Generic;
using System.Linq;
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

namespace OdczytywaczRAMu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Okienko : Window
    {
        RAMReader OdczytywaczRAM { get; set; }
        System.Timers.Timer Licznik { get; set; }
        private bool bytesUnit = true;
        private bool kilobytesUnit = false;
        private bool megabytesUnit = false;

        public Okienko()
        {
            this.OdczytywaczRAM = new RAMReader();
            this.UstawLicznik();
            InitializeComponent();
            this.SprawdzRAM();
            
        }

        private void UstawLicznik()
        {
            this.Licznik = new System.Timers.Timer(60000);
            this.Licznik.Elapsed += Uplynelo60Sekund;
            this.Licznik.AutoReset = true;
            this.Licznik.Enabled = true;
        }

        private void Uplynelo60Sekund(object sender, System.Timers.ElapsedEventArgs e)
        {
            Dispatcher.BeginInvoke((Action)(() => {
                this.SprawdzRAM();
            }));
        }

        public void SprawdzRAM()
        {
            
            var a = Task<Tuple<ulong,ulong>>.Run(() => { return OdczytywaczRAM.SprawdzRAM(); }).Result;

            ulong unit = bytesUnit ? 1 : (kilobytesUnit ? (ulong)1000 : (megabytesUnit ? (ulong)1000000 : 1));
            string unitName = bytesUnit ? "B" : (kilobytesUnit ? "KB" : (megabytesUnit ? "MB" : ""));

            this.EtykietaRAMZajety.Content = string.Format("Ilość zajętej pamięci RAM: {0}{1}", ((a.Item1 - a.Item2) / unit).ToString(), unitName);
            this.EtykieraRAMWolny.Content = string.Format("Ilość wolnej pamięci RAM: {0}{1}", (a.Item2 / unit).ToString(), unitName);
        }

        private void checkUnitStates()
        {
            if (this.bCheckbox == null || this.kbCheckbox == null || this.mbCheckbox == null)
                return;
            this.bytesUnit = this.bCheckbox.IsChecked.HasValue ? this.bCheckbox.IsChecked.Value : false;
            this.kilobytesUnit = this.kbCheckbox.IsChecked.HasValue ? this.kbCheckbox.IsChecked.Value : false;
            this.megabytesUnit = this.mbCheckbox.IsChecked.HasValue ? this.mbCheckbox.IsChecked.Value : false;
        }

        private void bCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            this.checkUnitStates();
            this.SprawdzRAM();
        }

        private void kbCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            this.checkUnitStates();
            this.SprawdzRAM();
        }

        private void mbCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            this.checkUnitStates();
            this.SprawdzRAM();
        }
    }
}
