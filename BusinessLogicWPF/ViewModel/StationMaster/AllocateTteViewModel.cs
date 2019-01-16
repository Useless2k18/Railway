// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AllocateTteViewModel.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the AllocateTteViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessLogicWPF.ViewModel.StationMaster
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    using BusinessLogicWPF.Annotations;
    using BusinessLogicWPF.GoogleCloudFireStoreLibrary;
    using BusinessLogicWPF.Helper;
    using BusinessLogicWPF.Model;

    /// <summary>
    /// The allocate TTE View Model.
    /// </summary>
    public class AllocateTteViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AllocateTteViewModel"/> class.
        /// </summary>
        public AllocateTteViewModel()
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
        public ObservableCollection<Train> Items1 { get; }

        /// <summary>
        /// Gets the items 2.
        /// </summary>
        [CanBeNull]
        public ObservableCollection<Train> Items2 { get; }

        /// <summary>
        /// Gets the items 3.
        /// </summary>
        [CanBeNull]
        public ObservableCollection<Train> Items3 { get; }

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
        private static ObservableCollection<Train> CreateData()
        {
            // Google Cloud Platform project ID.
            const string ProjectId = "ticketchecker-d4f79";

            try
            {
                StaticDbContext.ConnectFireStore = new ConnectFireStore(ProjectId, @"TicketChecker-1f6bf5c2db0a.json");
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }

            var observableCollectionOfTrain = new ObservableCollection<Train>(
                StaticDbContext.ConnectFireStore.GetAllDocumentData<Train>("ROOT", "TRAIN_DETAILS", "12073"));

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
