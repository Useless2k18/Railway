// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SelectTte.xaml.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Interaction logic for SelectTte.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessLogicWPF.View.StationMaster.UserControls.HelperForAllocation
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Threading;

    using BusinessLogicWPF.Helper;
    using BusinessLogicWPF.Model;
    using BusinessLogicWPF.Properties;
    using BusinessLogicWPF.ViewModel.StationMaster.ForHelper;

    using MahApps.Metro.Controls;

    /// <summary>
    /// Interaction logic for Selecting TTE XAML file
    /// </summary>
    public partial class SelectTte : UserControl
    {
        /// <summary>
        /// The status.
        /// </summary>
        private static bool status;

        /// <summary>
        /// The stations.
        /// </summary>
        [NotNull]
        private static List<Station> stations = new List<Station>();

        /// <summary>
        /// The background worker.
        /// </summary>
        [NotNull]
        private readonly BackgroundWorker backgroundWorker = new BackgroundWorker();

        //// public static Dictionary<string, string> TteDetails = new Dictionary<string, string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectTte"/> class.
        /// </summary>
        public SelectTte()
        {
            this.InitializeComponent();

            // Some messy things around
            this.ComboBoxDestination.IsEnabled = false;
            this.DatePickerDestination.IsEnabled = false;
            this.TimePickerSource.IsEnabled = false;
            this.TimePickerDestination.IsEnabled = false;

            this.DatePickerSource.BlackoutDates.AddDatesInPast();
            this.DatePickerDestination.BlackoutDates.AddDatesInPast();
            this.DatePickerSource.DisplayDateEnd =
                this.DatePickerDestination.DisplayDateEnd = DateTime.Now.AddMonths(3);

            if (this.backgroundWorker.IsBusy)
            {
                this.backgroundWorker.WorkerSupportsCancellation = true;
                this.backgroundWorker.CancelAsync();
            }
            else
            {
                this.backgroundWorker.DoWork += this.BackgroundWorkerDoWork;
                this.backgroundWorker.RunWorkerCompleted += this.BackgroundWorkerRunWorkerCompleted;
                this.backgroundWorker.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Gets or sets the TTEs.
        /// </summary>
        [CanBeNull]
        public static List<Tte> Ttes { get; set; }

        /// <summary>
        /// Gets or sets the trains.
        /// </summary>
        [CanBeNull]
        public List<Train> Trains { get; set; }

        /// <summary>
        /// The background worker do work.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void BackgroundWorkerDoWork([NotNull] object sender, [NotNull] DoWorkEventArgs e)
        {
            if (sender == null)
            {
                throw new ArgumentNullException(nameof(sender));
            }

            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            if (this.backgroundWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            this.Dispatcher.BeginInvoke(
                DispatcherPriority.Normal,
                new Action(() => this.ProgressBar.Visibility = Visibility.Visible));

            /*if (StaticDbContext.ConnectFireStore != null)
            {
                stations = StaticDbContext.ConnectFireStore.GetAllDocumentData<Station>(
                               "ROOT",
                               "STATIONS",
                               "STN_DETAILS") ?? throw new InvalidOperationException();
                Ttes = StaticDbContext.ConnectFireStore.GetAllDocumentData<Tte>("ROOT", "TT_DETAILS", "TT");
                this.Trains =
                    StaticDbContext.ConnectFireStore.GetAllDocumentData<Train>("ROOT", "TRAIN_DETAILS", "12073");
            }*/

            /*var d = Trains[0].ROUTE.TryGetValue("1", out var value);
            if (value != null) MessageBox.Show(value.STN_CODE);*/
        }

        /// <summary>
        /// The background worker run worker completed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void BackgroundWorkerRunWorkerCompleted(
            [NotNull] object sender,
            [NotNull] RunWorkerCompletedEventArgs e)
        {
            if (sender == null)
            {
                throw new ArgumentNullException(nameof(sender));
            }

            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            if (e.Cancelled)
            {
                MessageBox.Show("Operation Cancelled");
            }
            else if (e.Error != null)
            {
                MessageBox.Show("Error in Process :" + e.Error);
            }
            else
            {
                this.ComboBoxSource.IsEnabled = this.ComboBoxTteId.IsEnabled = this.ComboBoxTteName.IsEnabled = true;

                /*if (Ttes != null)
                {
                    foreach (var tte in Ttes)
                    {
                        this.ComboBoxTteId.Items.Add(tte.TT_ID);
                        this.ComboBoxTteName.Items.Add(tte.FullName);
                    }
                }

                foreach (var station in stations)
                {
                    this.ComboBoxSource.Items.Add(station.STN_NAME);
                    this.ComboBoxDestination.Items.Add(station.STN_NAME);

                    if (DataHelper.Train != null && station.STN_CODE?.Contains(
                            DataHelper.Train.destinationStation ?? throw new InvalidOperationException()) == true)
                    {
                        this.ComboBoxSource.Items.Remove(station);
                    }
                }*/
            }

            this.ProgressBar.Visibility = Visibility.Collapsed;
            /*this.ComboBoxSource.SelectedItem = stations.FirstOrDefault(
                s => s.STN_CODE != null && DataHelper.Train != null && s.STN_CODE.Contains(
                         DataHelper.Train.sourceStation ?? throw new InvalidOperationException()))?.STN_NAME;*/
        }

        /// <summary>
        /// The combo box TTE Id selection changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ComboBoxTteIdSelectionChanged([NotNull] object sender, [NotNull] SelectionChangedEventArgs e)
        {
            if (sender == null)
            {
                throw new ArgumentNullException(nameof(sender));
            }

            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            if (this.ComboBoxTteId.SelectedItem != null)
            {
                this.ComboBoxTteName.SelectedItem =
                    (Ttes ?? throw new InvalidOperationException()).FirstOrDefault(t => t.TT_ID == this.ComboBoxTteId.SelectedItem as string)?.FullName;
            }
        }

        /// <summary>
        /// The combo box TTE Name selection changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ComboBoxTteNameSelectionChanged([NotNull] object sender, [NotNull] SelectionChangedEventArgs e)
        {
            if (sender == null)
            {
                throw new ArgumentNullException(nameof(sender));
            }

            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            if (this.ComboBoxTteName.SelectedItem != null)
            {
                this.ComboBoxTteId.SelectedItem =
                    (Ttes ?? throw new InvalidOperationException())
                    .FirstOrDefault(t => t.FullName == this.ComboBoxTteName.SelectedItem as string)?.TT_ID;
            }
        }

        /// <summary>
        /// The combo box source selection changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ComboBoxSourceSelectionChanged([NotNull] object sender, [NotNull] SelectionChangedEventArgs e)
        {
            if (sender == null)
            {
                throw new ArgumentNullException(nameof(sender));
            }

            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            var selectedItem = this.ComboBoxSource.SelectedItem;
            this.ComboBoxDestination.Items.Remove(selectedItem);

            //// Stations.Remove(selectedItem.ToString());
            if (this.ComboBoxSource.SelectedItem != null)
            {
                this.ComboBoxDestination.IsEnabled = true;
            }
        }

        /// <summary>
        /// The combo box destination on selection changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ComboBoxDestination_OnSelectionChanged(
            [NotNull] object sender,
            [NotNull] SelectionChangedEventArgs e)
        {
            if (sender == null)
            {
                throw new ArgumentNullException(nameof(sender));
            }

            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            if (this.ComboBoxDestination.SelectedItem == null)
            {
                status = false;
                return;
            }

            if (DataHelper.Train != null)
            {
                var destinationStation = DataHelper.Train.DestinationStation;

                /*status = this.ComboBoxDestination.SelectedItem.ToString().Contains(
                    stations.FirstOrDefault(s => s.STN_CODE == destinationStation)?.STN_NAME
                    ?? throw new InvalidOperationException());*/
            }
        }

        /// <summary>
        /// The picker source key down.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// thrown if Argument is null
        /// </exception>
        private void PickerSourceKeyDown([NotNull] object sender, [NotNull] KeyEventArgs e)
        {
            if (sender == null)
            {
                throw new ArgumentNullException(nameof(sender));
            }

            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            e.Handled = true;
        }

        /// <summary>
        /// The date picker source on selected date changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void DatePickerSourceOnSelectedDateChanged([NotNull] object sender, [NotNull] SelectionChangedEventArgs e)
        {
            if (sender == null)
            {
                throw new ArgumentNullException(nameof(sender));
            }

            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            this.TimePickerSource.IsEnabled = true;
            this.TimePickerSource.SelectedTime = null;

            // Here TimeSpan.FromDays() is used for not black-outing selected date
            // (as train journey may be of 24 hours 😅) 
            if (this.DatePickerSource.SelectedDate != null)
            {
                this.DatePickerDestination.BlackoutDates.Add(
                    new CalendarDateRange(
                        DateTime.Now,
                        this.DatePickerSource.SelectedDate.Value - TimeSpan.FromDays(1)));
            }
        }

        /// <summary>
        /// The date picker destination on selected date changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void DatePickerDestinationOnSelectedDateChanged(
            [NotNull] object sender,
            [NotNull] SelectionChangedEventArgs e)
        {
            if (sender == null)
            {
                throw new ArgumentNullException(nameof(sender));
            }

            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            this.TimePickerDestination.IsEnabled = true;
            this.TimePickerDestination.SelectedTime = null;
        }

        /// <summary>
        /// The time picker source on selected time changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void TimePickerSourceOnSelectedTimeChanged(
            [NotNull] object sender,
            [NotNull] RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            if (sender == null)
            {
                throw new ArgumentNullException(nameof(sender));
            }

            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            this.DatePickerDestination.IsEnabled = true;
            this.TimePickerDestination.SelectedTime = null;
        }

        /// <summary>
        /// The time picker destination on selected time changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void TimePickerDestinationOnSelectedTimeChanged(
            [NotNull] object sender,
            [NotNull] RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            if (sender == null)
            {
                throw new ArgumentNullException(nameof(sender));
            }

            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            if (this.TimePickerSource.SelectedTime == null)
            {
                return;
            }

            var timeSpan = this.TimePickerSource.SelectedTime.Value.TimeOfDay;

            if (this.TimePickerDestination.SelectedTime == null
                || this.TimePickerDestination.SelectedTime.Value.TimeOfDay > timeSpan)
            {
                return;
            }

            if (this.DatePickerSource.SelectedDate != this.DatePickerDestination.SelectedDate)
            {
                return;
            }

            MessageBox.Show("Sorry, but time is invalid!");
            this.TimePickerDestination.SelectedTime = null;
        }

        /// <summary>
        /// The button proceed on click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ButtonProceedOnClick([NotNull] object sender, [NotNull] RoutedEventArgs e)
        {
            if (sender == null)
            {
                throw new ArgumentNullException(nameof(sender));
            }

            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            var id = this.FindChildren<ComboBox>().Count(comboBox => !string.IsNullOrWhiteSpace(comboBox.Text));

            id += this.FindChildren<DatePicker>().Count(datePicker => !string.IsNullOrWhiteSpace(datePicker.Text));

            id += this.FindChildren<MaterialDesignThemes.Wpf.TimePicker>()
                .Count(timePicker => !string.IsNullOrWhiteSpace(timePicker.Text));

            var validData = id == 8;

            if (!validData)
            {
                MessageBox.Show("Please fill all the details!");
            }
            else
            {
                if (status)
                {
                    DataHelper.StatusForEnable = true;
                    this.TextBlockWelcome.Text = "Thanks for Adding";
                    var controls = this.FindChildren<Control>();
                    foreach (var control in controls)
                    {
                        control.IsEnabled = false;
                    }

                    return;
                }

                if (DataHelper.Train != null)
                {
                    /*DataHelper.Train.sourceStation =
                        stations.FirstOrDefault(s => s.STN_NAME == this.ComboBoxDestination.Text)?.STN_CODE;*/

                    this.DataContext = new SelectTteViewModel(DataHelper.Train);
                    this.TextBlockWelcome.Text = "Add another TTE Details";

                    /*this.ComboBoxSource.SelectedItem = stations.FirstOrDefault(
                            s => s.STN_CODE?.Contains(
                                     DataHelper.Train.sourceStation ?? throw new InvalidOperationException()) == true)
                        ?.STN_NAME;*/
                }

                // Waiting for disabling again
                this.ComboBoxDestination.IsEnabled = false;
                this.DatePickerDestination.IsEnabled = false;
                this.TimePickerSource.IsEnabled = false;
                this.TimePickerDestination.IsEnabled = false;
            }
        }
    }
}
