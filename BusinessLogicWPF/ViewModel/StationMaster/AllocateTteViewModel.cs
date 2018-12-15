using BusinessLogicWPF.Domain;
using BusinessLogicWPF.GoogleCloudFireStoreLibrary;
using BusinessLogicWPF.Helper;
using BusinessLogicWPF.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace BusinessLogicWPF.ViewModel.StationMaster
{
    public class AllocateTteViewModel : INotifyPropertyChanged
    {
        private readonly ObservableCollection<Train> _items1;
        private readonly ObservableCollection<Train> _items2;
        private readonly ObservableCollection<Train> _items3;

        public AllocateTteViewModel()
        {
            _items1 = CreateData();
            _items2 = CreateData();
            _items3 = CreateData();
        }

        private static ObservableCollection<SelectableViewModel> CreateData1()
        {
            return new ObservableCollection<SelectableViewModel>
            {
                new SelectableViewModel
                {
                    TrainNo = "12345",
                    TrainName = "HWH MAS Duronto",
                    SourceStation = "Howrah",
                    DestinationStation = "Chennai"
                },

                new SelectableViewModel
                {
                    TrainNo = "15125",
                    TrainName = "MAS NJP Express",
                    SourceStation = "Chennai",
                    DestinationStation = "New Jalpaiguri"
                },

                new SelectableViewModel
                {
                    TrainNo = "54575",
                    TrainName = "BOM HWH MAIL",
                    SourceStation = "Mumbai",
                    DestinationStation = "Howrah"
                },

                new SelectableViewModel
                {
                    TrainNo = "12073",
                    TrainName = "HWH BBS Janashatbdi",
                    SourceStation = "Howrah",
                    DestinationStation = "Bhubaneswar"
                }
            };
        }

        private static ObservableCollection<Train> CreateData()
        {
            // Google Cloud Platform project ID.
            const string projectId = "ticketchecker-d4f79";

            try
            {
                StaticDbContext.ConnectFireStore = new ConnectFireStore(projectId, @"TicketChecker-1f6bf5c2db0a.json");
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }

            var observableCollectionOfTrain = new ObservableCollection<Train>(
                StaticDbContext.ConnectFireStore.GetAllDocumentData<Train>("ROOT", "TRAIN_DETAILS", "12073"));

            return observableCollectionOfTrain;
        }

        public ObservableCollection<Train> Items1 => _items1;
        public ObservableCollection<Train> Items2 => _items2;

        public ObservableCollection<Train> Items3 => _items3;

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
