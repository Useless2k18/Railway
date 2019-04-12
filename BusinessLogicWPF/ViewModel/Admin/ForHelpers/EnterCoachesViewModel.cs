// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnterCoachesViewModel.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the EnterCoachesViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessLogicWPF.ViewModel.Admin.ForHelpers
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;

    using BusinessLogicWPF.Domain;
    using BusinessLogicWPF.Helper;
    using BusinessLogicWPF.Properties;

    /// <inheritdoc />
    /// <summary>
    /// The enter coaches view model.
    /// </summary>
    public class EnterCoachesViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnterCoachesViewModel"/> class.
        /// </summary>
        public EnterCoachesViewModel()
        {
            this.CoachName = DataHelper.SelectedCoach;
            this.SomeCollection = new ObservableCollection<string>();
            this.TestCommand = new RelayCommand<object>(this.CommandMethod);
        }

        /// <inheritdoc />
        /// <summary>
        /// The property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the some collection.
        /// </summary>
        public ObservableCollection<string> SomeCollection { get; set; }

        /// <summary>
        /// Gets or sets the coach name.
        /// </summary>
        public string CoachName { get; set; }

        /// <summary>
        /// Gets the test command.
        /// </summary>
        public ICommand TestCommand { get; }

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

        /// <summary>
        /// The command method.
        /// </summary>
        /// <param name="parameter">
        /// The parameter.
        /// </param>
        private void CommandMethod(object parameter)
        {
            this.SomeCollection.Add("Some dummy string");
        }
    }
}
