using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BusinessLogicWPF.Domain
{

    public class SelectableViewModel : INotifyPropertyChanged
    {
        private string _tteId;
        private string _tteName;
        private int _trainNo;
        private string _trainName;
        private bool _assign;

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

        public bool Assign
        {
            get => _assign;
            set
            {
                if (_assign == value) return;
                _assign = value;
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