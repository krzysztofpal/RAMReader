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
            
            var a = Task<Tuple<int,int>>.Run(() => { return OdczytywaczRAM.SprawdzRAM(); }).Result;
            this.EtykietaRAMZajety.Content = "Ilość zajętej pamięci RAM: " + (a.Item1 - a.Item2).ToString() + "MB";
            this.EtykieraRAMWolny.Content = "Ilość wolnej pamięci RAM: " + a.Item2.ToString() + "MB";
        }


    }
}
