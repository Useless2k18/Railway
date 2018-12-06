using BusinessLogicWPF.Domain;
using BusinessLogicWPF.Helper;
using Cinch;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BusinessLogicWPF.ViewModel.StationMaster.ForHelper
{
    public class SelectTteViewModel : INotifyPropertyChanged
    {
        private DateTime _date;
        private DateTime _time;
        private string _validatingTime;
        private DateTime? _futureValidatingDate;
        private string _tteId = string.Empty;
        private string _tteName = string.Empty;
        private string _sourceStation;
        private string _destinationStation;
        private string _sourceDate = string.Empty;
        private string _sourceTime = string.Empty;
        private string _destinationDate = string.Empty;
        private string _destinationTime = string.Empty;

        public SimpleCommand<object, object> ClearCommand { get; }

        public SelectTteViewModel(SelectableViewModel data)
        {
            Date = DateTime.Now;
            Time = DateTime.Now;
            DataHelper.Data = data;
            ClearCommand = new SimpleCommand<object, object>(CanExecuteClearCommand, ExecuteClearCommand);
        }

        public string TteId
        {
            get => _tteId;
            set
            {
                if (_tteId == value) return;
                _tteId = value;
                OnPropertyChanged();
            }
        }

        public string TteName
        {
            get => _tteName;
            set
            {
                if (_tteName == value) return;
                _tteName = value;
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

        public string SourceTime
        {
            get => _sourceTime;
            set
            {
                if (_sourceTime == value) return;
                _sourceTime = value;
                OnPropertyChanged();
            }
        }

        public string SourceDate
        {
            get => _sourceDate;
            set
            {
                if (_sourceDate == value) return;
                _sourceDate = value;
                OnPropertyChanged();
            }
        }

        public string DestinationDate
        {
            get => _destinationDate;
            set
            {
                if (_destinationDate == value) return;
                _destinationDate = value;
                OnPropertyChanged();
            }
        }

        public string DestinationTime
        {
            get => _destinationTime;
            set
            {
                if (_destinationTime == value) return;
                _destinationTime = value;
                OnPropertyChanged();
            }
        }

        private void ExecuteClearCommand(object args)
        {
            TteId = string.Empty;
            TteName = string.Empty;
            SourceStation = string.Empty;
            DestinationStation = string.Empty;
            SourceDate = string.Empty;
            SourceTime = string.Empty;
            DestinationDate = string.Empty;
            DestinationTime = string.Empty;
        }

        private bool CanExecuteClearCommand(object args)
        {
            return true;
        }

        public DateTime Date
        {
            get => _date;
            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }

        public DateTime Time
        {
            get => _time;
            set
            {
                _time = value;
                OnPropertyChanged();
            }
        }

        public string ValidatingTime
        {
            get => _validatingTime;
            set
            {
                _validatingTime = value;
                OnPropertyChanged();
            }
        }

        public DateTime? FutureValidatingDate
        {
            get => _futureValidatingDate;
            set
            {
                _futureValidatingDate = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
