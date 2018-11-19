using BusinessLogicWPF.Domain;
using System;
using System.ComponentModel;

namespace BusinessLogicWPF.ViewModel.LoginAndRegister
{
    public class LoginAsAdminViewModel : INotifyPropertyChanged
    {
        private string _userName;
        private string _otp;

        public string Username
        {
            get => _userName;
            set => this.MutateVerbose(ref _userName, value, RaisePropertyChanged());
        }

        public string Otp
        {
            get => _otp;
            set => this.MutateVerbose(ref _otp, value, RaisePropertyChanged());
        }

        private Action<PropertyChangedEventArgs> RaisePropertyChanged()
        {
            return args => PropertyChanged?.Invoke(this, args);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
