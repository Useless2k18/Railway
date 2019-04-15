// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddStationViewModel.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the AddStationViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessLogicWPF.ViewModel.Admin
{
    using System;
    using System.ComponentModel;
    using System.Text.RegularExpressions;

    using BusinessLogicWPF.Domain;
    using BusinessLogicWPF.Properties;

    /// <summary>
    /// The add station view model.
    /// </summary>
    public class AddStationViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The zone name.
        /// </summary>
        private string zoneName;

        /// <summary>
        /// The division name.
        /// </summary>
        private string divisionName;

        /// <summary>
        /// The station code.
        /// </summary>
        private string stationCode;

        /// <summary>
        /// The station name.
        /// </summary>
        private string stationName;

        /// <summary>
        /// The pin code.
        /// </summary>
        private string pinCode;

        /// <summary>
        /// The property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the zone name.
        /// </summary>
        public string ZoneName
        {
            get => this.zoneName;
            set => this.MutateVerbose(ref this.zoneName, value, this.RaisePropertyChanged());
        }

        /// <summary>
        /// Gets or sets the division name.
        /// </summary>
        public string DivisionName
        {
            get => this.divisionName;
            set => this.MutateVerbose(ref this.divisionName, value, this.RaisePropertyChanged());
        }

        /// <summary>
        /// Gets or sets the station code.
        /// </summary>
        public string StationCode
        {
            get => this.stationCode;
            set => this.MutateVerbose(ref this.stationCode, value, this.RaisePropertyChanged());
        }

        /// <summary>
        /// Gets or sets the station name.
        /// </summary>
        public string StationName
        {
            get => this.stationName;
            set => this.MutateVerbose(ref this.stationName, value, this.RaisePropertyChanged());
        }

        /// <summary>
        /// Gets or sets the pin code.
        /// </summary>
        public string PinCode
        {
            get => this.pinCode;
            set
            {
                this.ValidatePinCode(value);
                this.MutateVerbose(ref this.pinCode, value, this.RaisePropertyChanged());
            }
        }

        /// <summary>
        /// The raise property changed.
        /// </summary>
        /// <returns>
        /// The <see cref="Action"/>.
        /// </returns>
        [CanBeNull]
        private Action<PropertyChangedEventArgs> RaisePropertyChanged() =>
            args => this.PropertyChanged?.Invoke(this, args);

        /// <summary>
        /// The validate pin code.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <exception cref="ArgumentException">
        /// </exception>
        private void ValidatePinCode(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return;
            }

            var regex = new Regex(@"^[0-9]{6}");

            if (regex.Match(value) == Match.Empty)
            {
                throw new ArgumentException("Pin Code must be of 6 digits");
            }
        }
    }
}
