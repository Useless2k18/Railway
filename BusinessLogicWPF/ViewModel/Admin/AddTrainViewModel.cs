﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddTrainViewModel.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   The add train view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessLogicWPF.ViewModel.Admin
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Text.RegularExpressions;
    using System.Windows;

    using BusinessLogicWPF.Domain;
    using BusinessLogicWPF.Helper;
    using BusinessLogicWPF.Model;
    using BusinessLogicWPF.Properties;

    /// <summary>
    /// The add train view model.
    /// </summary>
    public class AddTrainViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The train number.
        /// </summary>
        private string trainNumber;

        /// <summary>
        /// The train name.
        /// </summary>
        private string trainName;

        /// <summary>
        /// The train type.
        /// </summary>
        private string trainType;

        /// <summary>
        /// The source station.
        /// </summary>
        private string sourceStation;

        /// <summary>
        /// The destination station.
        /// </summary>
        private string destinationStation;

        /// <summary>
        /// The rake zone.
        /// </summary>
        private string rakeZone;

        /// <summary>
        /// The property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the train number.
        /// </summary>
        public string TrainNumber
        {
            get => this.trainNumber;
            set
            {
                this.ValidateTrainNumber(value);
                this.MutateVerbose(ref this.trainNumber, value, this.RaisePropertyChanged());
            }
        }

        /// <summary>
        /// Gets or sets the train name.
        /// </summary>
        public string TrainName
        {
            get => this.trainName;
            set => this.MutateVerbose(ref this.trainName, value, this.RaisePropertyChanged());
        }

        /// <summary>
        /// Gets or sets the train type.
        /// </summary>
        public string TrainType
        {
            get => this.trainType;
            set => this.MutateVerbose(ref this.trainType, value, this.RaisePropertyChanged());
        }

        /// <summary>
        /// Gets or sets the source station.
        /// </summary>
        public string SourceStation
        {
            get => this.sourceStation;
            set => this.MutateVerbose(ref this.sourceStation, value, this.RaisePropertyChanged());
        }

        /// <summary>
        /// Gets or sets the destination station.
        /// </summary>
        public string DestinationStation
        {
            get => this.destinationStation;
            set => this.MutateVerbose(ref this.destinationStation, value, this.RaisePropertyChanged());
        }

        /// <summary>
        /// Gets or sets the rake zone.
        /// </summary>
        public string RakeZone
        {
            get => this.rakeZone;
            set => this.MutateVerbose(ref this.rakeZone, value, this.RaisePropertyChanged());
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
        /// The validate train number.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <exception cref="ArgumentException">
        /// throws if Train Number is not validated...means less than 5 digits
        /// </exception>
        private void ValidateTrainNumber(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return;
            }

            var regex = new Regex(@"^[0-9]{5}");
            if (regex.Match(value) == Match.Empty)
            {
                throw new ArgumentException("Must be of 5 digits");
            }
        }
    }
}
