using System;

namespace BusinessLogicWPF.Domain
{

    public class SelectableViewModel
    {
        private string _trainNo;
        private string _trainName;
        private string _sourceStation;
        private string _destinationStation;

        public string TrainNo
        {
            get => _trainNo;
            set
            {
                if (_trainNo != null && _trainNo == value) return;
                _trainNo = value;
            }
        }

        public string TrainName
        {
            get => _trainName;
            set
            {
                if (string.Equals(_trainName, value, StringComparison.Ordinal)) return;
                _trainName = value;
            }
        }

        public string SourceStation
        {
            get => _sourceStation;
            set
            {
                if (_sourceStation != null && _sourceStation == value) return;
                _sourceStation = value;
            }
        }

        public string DestinationStation
        {
            get => _destinationStation;
            set
            {
                if (value != null && _destinationStation == value) return;
                _destinationStation = value;
            }
        }
    }
}