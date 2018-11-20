using BusinessLogicWPF.Domain;
using System;
using System.ComponentModel;

namespace BusinessLogicWPF.ViewModel.LoginAndRegister
{
    public class LoginAsStationMasterViewModel : INotifyPropertyChanged
    {
        private string _userName;

        public string Username
        {
            get => _userName;
            set => this.MutateVerbose(ref _userName, value, RaisePropertyChanged());
        }

        private Action<PropertyChangedEventArgs> RaisePropertyChanged()
        {
            return args => PropertyChanged?.Invoke(this, args);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
