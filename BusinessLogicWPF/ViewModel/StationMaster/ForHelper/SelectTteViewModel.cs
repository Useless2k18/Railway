// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SelectTteViewModel.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the SelectTteViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessLogicWPF.ViewModel.StationMaster.ForHelper
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    using BusinessLogicWPF.Annotations;
    using BusinessLogicWPF.Helper;
    using BusinessLogicWPF.Model;

    using Cinch;

    /// <summary>
    /// The select TTE view model.
    /// </summary>
    public class SelectTteViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The date.
        /// </summary>
        private DateTime date;

        /// <summary>
        /// The time.
        /// </summary>
        private DateTime time;

        /// <summary>
        /// The TTE Id.
        /// </summary>
        [NotNull]
        private string tteId = string.Empty;

        /// <summary>
        /// The TTE Name.
        /// </summary>
        [NotNull]
        private string tteName = string.Empty;

        /// <summary>
        /// The source station.
        /// </summary>
        [CanBeNull]
        private string sourceStation;

        /// <summary>
        /// The destination station.
        /// </summary>
        [CanBeNull]
        private string destinationStation;

        /// <summary>
        /// The source date.
        /// </summary>
        [NotNull]
        private string sourceDate = string.Empty;

        /// <summary>
        /// The source time.
        /// </summary>
        [NotNull]
        private string sourceTime = string.Empty;

        /// <summary>
        /// The destination date.
        /// </summary>
        [NotNull]
        private string destinationDate = string.Empty;

        /// <summary>
        /// The destination time.
        /// </summary>
        [NotNull]
        private string destinationTime = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectTteViewModel"/> class.
        /// </summary>
        /// <param name="train">
        /// The train.
        /// </param>
        public SelectTteViewModel([NotNull] Train train)
        {
            this.Date = DateTime.Now;
            this.Time = DateTime.Now;
            DataHelper.Train = train ?? throw new ArgumentNullException(nameof(train));
            this.ClearCommand = new SimpleCommand<object, object>(this.CanExecuteClearCommand, this.ExecuteClearCommand);
        }

        /// <summary>
        /// The property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the TTE Id.
        /// </summary>
        [NotNull]
        public string TteId
        {
            get => this.tteId;
            set
            {
                if (this.tteId == value)
                {
                    return;
                }

                this.tteId = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the TTE Name.
        /// </summary>
        [NotNull]
        public string TteName
        {
            get => this.tteName;
            set
            {
                if (this.tteName == value)
                {
                    return;
                }

                this.tteName = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the source station.
        /// </summary>
        [NotNull]
        public string SourceStation
        {
            get => this.sourceStation ?? throw new InvalidOperationException();
            set
            {
                if (this.sourceStation == value)
                {
                    return;
                }

                this.sourceStation = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the destination station.
        /// </summary>
        [NotNull]
        public string DestinationStation
        {
            get => this.destinationStation ?? throw new InvalidOperationException();
            set
            {
                if (this.destinationStation == value)
                {
                    return;
                }

                this.destinationStation = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the source time.
        /// </summary>
        [NotNull]
        public string SourceTime
        {
            get => this.sourceTime;
            set
            {
                if (this.sourceTime == value)
                {
                    return;
                }

                this.sourceTime = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the source date.
        /// </summary>
        [NotNull]
        public string SourceDate
        {
            get => this.sourceDate;
            set
            {
                if (this.sourceDate == value)
                {
                    return;
                }

                this.sourceDate = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the destination date.
        /// </summary>
        [NotNull]
        public string DestinationDate
        {
            get => this.destinationDate;
            set
            {
                if (this.destinationDate == value)
                {
                    return;
                }

                this.destinationDate = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the destination time.
        /// </summary>
        [NotNull]
        public string DestinationTime
        {
            get => this.destinationTime;
            set
            {
                if (this.destinationTime == value)
                {
                    return;
                }

                this.destinationTime = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        public DateTime Date
        {
            get => this.date;
            set
            {
                this.date = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        public DateTime Time
        {
            get => this.time;
            set
            {
                this.time = value;
                this.OnPropertyChanged();
            }
        }
        
        /// <summary>
        /// Gets the clear command.
        /// </summary>
        [NotNull]
        public SimpleCommand<object, object> ClearCommand { get; }

        /// <summary>
        /// The on property changed.
        /// </summary>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        protected virtual void OnPropertyChanged([CallerMemberName][CanBeNull] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// The execute clear command.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        private void ExecuteClearCommand([NotNull] object args)
        {
            if (args == null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            this.TteId = string.Empty;
            this.TteName = string.Empty;
            this.SourceStation = string.Empty;
            this.DestinationStation = string.Empty;
            this.SourceDate = string.Empty;
            this.SourceTime = string.Empty;
            this.DestinationDate = string.Empty;
            this.DestinationTime = string.Empty;
        }

        /// <summary>
        /// The can execute clear command.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool CanExecuteClearCommand([NotNull] object args)
        {
            if (args == null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            return true;
        }
    }
}
