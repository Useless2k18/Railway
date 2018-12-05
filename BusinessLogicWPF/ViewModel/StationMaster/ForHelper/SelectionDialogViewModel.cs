using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using BusinessLogicWPF.Annotations;

namespace BusinessLogicWPF.ViewModel.StationMaster.ForHelper
{
    public class SelectionDialogViewModel : INotifyPropertyChanged
    {
        private DateTime _date;
        private DateTime _time;
        private string _validatingTime;
        private DateTime? _futureValidatingDate;

        public SelectionDialogViewModel()
        {
            Date = DateTime.Now;
            Time = DateTime.Now;
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
