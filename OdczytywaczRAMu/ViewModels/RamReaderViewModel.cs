using OdczytywaczRAMu.ViewModels.Commands;
using OdczytywaczRAMu.ViewModels.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OdczytywaczRAMu.ViewModels
{
    public class RamReaderViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private InformationWeightUnitEnum _unitType;
        public InformationWeightUnitEnum UnitType
        {
            get { return _unitType; }
            set
            {
                _unitType = value;
                OnPropertyChanged(nameof(UnitType));
                OnPropertyChanged(nameof(AvaliableRamText));
                OnPropertyChanged(nameof(OccupiedRamText));
                OnPropertyChanged(nameof(WholeRAM));
            }
        }

        private ulong _avaliableRam;
        public ulong AvaliableRam
        {
            get { return _avaliableRam; }
            set
            {
                _avaliableRam = value;
                OnPropertyChanged(nameof(AvaliableRam));
                OnPropertyChanged(nameof(AvaliableRamText));
                OnPropertyChanged(nameof(WholeRAM));
            }
        }

        private ulong _occupiedRam;
        public ulong OccupiedRam
        {
            get { return _occupiedRam; }
            set
            {
                _occupiedRam = value;
                OnPropertyChanged(nameof(OccupiedRam));
                OnPropertyChanged(nameof(OccupiedRamText));
                OnPropertyChanged(nameof(WholeRAM));
            }
        }

        public string AvaliableRamText
        {
            get
            {
                return getUnitsText(this.AvaliableRam);
            }
        }

        public string OccupiedRamText
        {
            get
            {
                return getUnitsText(this.OccupiedRam);
            }
        }

        public string WholeRAM
        {
            get
            {
                return getUnitsText(this.OccupiedRam + this.AvaliableRam);
            }
        }

        public ICommand ChangeUnitCommand { get; set; }

        public RamReaderViewModel()
        {
            UnitType = InformationWeightUnitEnum.Bytes;
            ChangeUnitCommand = new ChangeInformationWeightUnitCommand(executemethod, canexecutemethod);
        }

        private bool canexecutemethod(object parameter)
        {
            return parameter != null;
        }

        private void executemethod(object parameter)
        {
            UnitType = (InformationWeightUnitEnum)int.Parse((string)parameter);
        }


        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private string getUnitsText(ulong value)
        {
            ulong ram;
            switch (this.UnitType)
            {
                case InformationWeightUnitEnum.Bytes: { ram = value; break; }
                case InformationWeightUnitEnum.KiloBytes: { ram = value / 1000; break; }
                case InformationWeightUnitEnum.MegaBytes: { ram = value / 1000000; break; }
                default: { ram = value; break; }
            }

            return string.Format("{0}{1}", ram.ToString(), this.UnitType.GetUnitName());
        }
    }
}
