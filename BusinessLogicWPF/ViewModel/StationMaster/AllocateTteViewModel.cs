using BusinessLogicWPF.Domain;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BusinessLogicWPF.ViewModel.StationMaster
{
    public class AllocateTteViewModel : INotifyPropertyChanged
    {
        private readonly ObservableCollection<SelectableViewModel> _items1;
        private readonly ObservableCollection<SelectableViewModel> _items2;
        private readonly ObservableCollection<SelectableViewModel> _items3;

        public AllocateTteViewModel()
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
                    TrainNo = 12345,
                    TrainName = "HWH MAS Duronto",
                    SourceStation = "Howrah",
                    DestinationStation = "Chennai"
                },

                new SelectableViewModel
                {
                    TrainNo = 15125,
                    TrainName = "MAS NJP Express",
                    SourceStation = "Chennai",
                    DestinationStation = "New Jalpaiguri"
                },

                new SelectableViewModel
                {
                    TrainNo = 54575,
                    TrainName = "BOM HWH MAIL",
                    SourceStation = "Mumbai",
                    DestinationStation = "Howrah"
                },

                new SelectableViewModel
                {
                    TrainNo = 12073,
                    TrainName = "HWH BBS Janashatbdi",
                    SourceStation = "Howrah",
                    DestinationStation = "Bhubaneswar"
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

        private Action<PropertyChangedEventArgs> RaisePropertyChanged()
        {
            return args => PropertyChanged?.Invoke(this, args);
        }
    }
}
