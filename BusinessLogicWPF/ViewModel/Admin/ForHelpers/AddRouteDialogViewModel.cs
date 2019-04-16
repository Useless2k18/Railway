// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddRouteDialogViewModel.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the AddRouteDialogViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessLogicWPF.ViewModel.Admin.ForHelpers
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    using BusinessLogicWPF.Model;
    using BusinessLogicWPF.Properties;

    /// <summary>
    /// The add route dialog view model.
    /// </summary>
    public class AddRouteDialogViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The station code.
        /// </summary>
        private string stationCode;

        /// <summary>
        /// The departure time.
        /// </summary>
        private string departureTime;

        /// <summary>
        /// The arrival time.
        /// </summary>
        private string arrivalTime;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddRouteDialogViewModel"/> class.
        /// </summary>
        /// <param name="route">
        /// The route.
        /// </param>
        public AddRouteDialogViewModel([CanBeNull] Route route = null)
        {
            if (route == null)
            {
                return;
            }

            this.StationCode = route.StationCode;
            this.DepartureTime = route.DepartureTime;
            this.ArrivalTime = route.ArrivalTime;
        }

        /// <summary>
        /// The property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the station code.
        /// </summary>
        public string StationCode
        {
            get => this.stationCode;
            set
            {
                if (value != null && this.stationCode != value)
                {
                    this.stationCode = value;
                    this.OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the departure time.
        /// </summary>
        public string DepartureTime
        {
            get => this.departureTime;
            set
            {
                if (value != null && this.departureTime != value)
                {
                    this.departureTime = value;
                    this.OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the arrival time.
        /// </summary>
        public string ArrivalTime
        {
            get => this.arrivalTime;
            set
            {
                if (value != null && this.arrivalTime != value)
                {
                    this.arrivalTime = value;
                    this.OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// The on property changed.
        /// </summary>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] [CanBeNull] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
