// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoginAsTteViewModel.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the LoginAsTteViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessLogicWPF.ViewModel.LoginAndRegister
{
    using System;
    using System.ComponentModel;

    using BusinessLogicWPF.Annotations;
    using BusinessLogicWPF.Domain;

    /// <summary>
    /// The login as TTE view model.
    /// </summary>
    public class LoginAsTteViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The user name.
        /// </summary>
        [CanBeNull]
        private string userName;

        /// <summary>
        /// The OTP.
        /// </summary>
        [CanBeNull]
        private string otp;

        /// <summary>
        /// The property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        [CanBeNull]
        public string Username
        {
            get => this.userName;
            set => this.MutateVerbose(ref this.userName, value, this.RaisePropertyChanged());
        }

        /// <summary>
        /// Gets or sets the OTP.
        /// </summary>
        [CanBeNull]
        public string Otp
        {
            get => this.otp;
            set => this.MutateVerbose(ref this.otp, value, this.RaisePropertyChanged());
        }

        /// <summary>
        /// The raise property changed.
        /// </summary>
        /// <returns>
        /// The <see cref="Action"/>.
        /// </returns>
        [NotNull]
        private Action<PropertyChangedEventArgs> RaisePropertyChanged() =>
            args => this.PropertyChanged?.Invoke(this, args);
    }
}
