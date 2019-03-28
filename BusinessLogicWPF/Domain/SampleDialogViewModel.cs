// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SampleDialogViewModel.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the SampleDialogViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessLogicWPF.Domain
{
    using System;
    using System.ComponentModel;

    using BusinessLogicWPF.Properties;

    /// <summary>
    /// The sample dialog view model.
    /// </summary>
    public class SampleDialogViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The name.
        /// </summary>
        [CanBeNull]
        private string name;

        /// <summary>
        /// The property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [CanBeNull]
        public string Name
        {
            get => this.name;
            set => this.MutateVerbose(ref this.name, value, this.RaisePropertyChanged());
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
    }
}