using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BusinessLogicWPF.Domain
{

    public class SelectableViewModel : INotifyPropertyChanged
    {
        private int _trainNo;
        private string _trainName;
        private string _sourceStation;
        private string _destinationStation;

        public int TrainNo
        {
            get => _trainNo;
            set
            {
                if (_trainNo == value) return;
                _trainNo = value;
                OnPropertyChanged();
            }
        }

        public string TrainName
        {
            get => _trainName;
            set
            {
                if (_trainName == value) return;
                _trainName = value;
                OnPropertyChanged();
            }
        }

        public string SourceStation
        {
            get => _sourceStation;
            set
            {
                if (_sourceStation == value) return;
                _sourceStation = value;
                OnPropertyChanged();
            }
        }

        public string DestinationStation
        {
            get => _destinationStation;
            set
            {
                if (_destinationStation == value) return;
                _destinationStation = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}