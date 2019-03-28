// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoginAsStationMasterViewModel.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the LoginAsStationMasterViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessLogicWPF.ViewModel.LoginAndRegister
{
    using System;
    using System.ComponentModel;

    using BusinessLogicWPF.Domain;
    using BusinessLogicWPF.Properties;

    /// <summary>
    /// The login as station master view model.
    /// </summary>
    public class LoginAsStationMasterViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The user name.
        /// </summary>
        [CanBeNull]
        private string userName;

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
