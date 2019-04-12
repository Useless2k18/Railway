// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddRouteOfTrainViewModel.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the AddRouteOfTrainViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessLogicWPF.ViewModel.Admin.ForHelpers
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    using BusinessLogicWPF.GoogleCloudFireStoreLibrary;
    using BusinessLogicWPF.Helper;
    using BusinessLogicWPF.Model;
    using BusinessLogicWPF.Properties;
    using BusinessLogicWPF.ViewModel.StationMaster;

    /// <inheritdoc />
    /// <summary>
    /// The add route of train view model.
    /// </summary>
    public class AddRouteOfTrainViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddRouteOfTrainViewModel"/> class.
        /// </summary>
        public AddRouteOfTrainViewModel()
        {
            this.Items1 = CreateData();
            this.Items2 = CreateData();
            this.Items3 = CreateData();
        }

        /// <summary>
        /// The property changed of Allocate TTE View Model.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets The items 1.
        /// </summary>
        [CanBeNull]
        public ObservableCollection<Route> Items1 { get; }

        /// <summary>
        /// Gets the items 2.
        /// </summary>
        [CanBeNull]
        public ObservableCollection<Route> Items2 { get; }

        /// <summary>
        /// Gets the items 3.
        /// </summary>
        [CanBeNull]
        public ObservableCollection<Route> Items3 { get; }

        /// <summary>
        /// The on property changed.
        /// </summary>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        protected virtual void OnPropertyChanged([CallerMemberName] [CanBeNull] string propertyName = null) =>
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        /// <summary>
        /// The create data.
        /// </summary>
        /// <returns>
        /// The <see cref="ObservableCollection{T}"/>.
        /// </returns>
        [CanBeNull]
        private static ObservableCollection<Route> CreateData()
        {
            var observableCollectionOfTrain = new ObservableCollection<Route>
                                                  {
                                                      new Route
                                                          {
                                                              StationCode = "ASN",
                                                              ArrivalTime = "12:00",
                                                              DepartureTime = "02:00",
                                                              TteAssignFlag = 0
                                                          },
                                                      new Route
                                                          {
                                                              StationCode = "ASN",
                                                              ArrivalTime = "12:00",
                                                              DepartureTime = "02:00",
                                                              TteAssignFlag = 0
                                                          }
                                                  };

            return observableCollectionOfTrain;
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
