using OdczytywaczRAMu.Services;
using OdczytywaczRAMu.ViewModels;
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
        private TimeMeasuring Licznik { get; set; }
        private RAMReader OdczytywaczRAM { get; set; }
        private RamReaderViewModel ViewModel;


        public Okienko()
        {
            this.OdczytywaczRAM = new RAMReader();
            this.Licznik = new TimeMeasuring(60000, Uplynelo60Sekund);
            InitializeComponent();
            this.ViewModel = (RamReaderViewModel)this.Resources["vm"];
            this.SprawdzRAM();
            
        }


        private void Uplynelo60Sekund()
        {
            
            Dispatcher.BeginInvoke((Action)(() => {
                SprawdzRAM();
            }));
        }

        public void SprawdzRAM()
        {
            
            var a = Task<Tuple<ulong,ulong>>.Run(() => { return OdczytywaczRAM.SprawdzRAM(); }).Result;

            this.ViewModel.OccupiedRam = a.Item1 - a.Item2;
            this.ViewModel.AvaliableRam = a.Item2;
            
        }
    }
}
