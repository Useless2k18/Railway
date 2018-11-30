using BusinessLogicWPF.Domain;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BusinessLogicWPF.ViewModel.StationMaster
{
    public class StationMasterAllocateTteViewModel : INotifyPropertyChanged
    {
        private readonly ObservableCollection<SelectableViewModel> _items1;
        private readonly ObservableCollection<SelectableViewModel> _items2;
        private readonly ObservableCollection<SelectableViewModel> _items3;

        public StationMasterAllocateTteViewModel()
        {
            _items1 = CreateData();
            _items2 = CreateData();
            _items3 = CreateData();
        }

        private static ObservableCollection<SelectableViewModel> CreateData()
        {
            return new ObservableCollection<SelectableViewModel>
            {
                new SelectableViewModel
                {
                    TteId = "ABC55dd",
                    TteName = "Shekhar Mahato",
                    TrainNo = 12345,
                    TrainName = "HWH MAS Duronto",
                    Assign = false
                },

                new SelectableViewModel
                {
                    TteId = "AHdd54",
                    TteName = "Utsab Goyal",
                    TrainNo = 15125,
                    TrainName = "MAS NJP Express",
                    Assign = false
                },

                new SelectableViewModel
                {
                    TteId = "ABC55dd2q",
                    TteName = "Pinaki Kundu",
                    TrainNo = 54575,
                    TrainName = "BOM HWH MAIL",
                    Assign = false
                }
            };
        }

        public ObservableCollection<SelectableViewModel> Items1 => _items1;
        public ObservableCollection<SelectableViewModel> Items2 => _items2;

        public ObservableCollection<SelectableViewModel> Items3 => _items3;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public IEnumerable<string> Assigns
        {
            get
            {
                yield return "Don't Assign";
                yield return "Assign";
            }
        }
    }
}
