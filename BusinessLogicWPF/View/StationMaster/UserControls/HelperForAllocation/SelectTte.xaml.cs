using BusinessLogicWPF.Helper;
using BusinessLogicWPF.Model;
using BusinessLogicWPF.ViewModel.StationMaster.ForHelper;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace BusinessLogicWPF.View.StationMaster.UserControls.HelperForAllocation
{
    /// <summary>
    /// Interaction logic for SelectTte.xaml
    /// </summary>
    public partial class SelectTte : UserControl
    {
        private readonly BackgroundWorker _backgroundWorker = new BackgroundWorker();
        private static bool _status;

        public static List<Station> Stations = new List<Station>();
        public static List<Tte> Ttes { get; set; }
        public List<Train> Trains { get; set; }
        //public static Dictionary<string, string> TteDetails = new Dictionary<string, string>();

        public SelectTte()
        {
            InitializeComponent();

            // Some messy things around
            ComboBoxDestination.IsEnabled = false;
            DatePickerDestination.IsEnabled = false;
            TimePickerSource.IsEnabled = false;
            TimePickerDestination.IsEnabled = false;

            DatePickerSource.BlackoutDates.AddDatesInPast();
            DatePickerDestination.BlackoutDates.AddDatesInPast();
            DatePickerSource.DisplayDateEnd = DatePickerDestination.DisplayDateEnd = DateTime.Now.AddMonths(3);

            if (_backgroundWorker.IsBusy)
            {
                _backgroundWorker.WorkerSupportsCancellation = true;
                _backgroundWorker.CancelAsync();
            }

            else
            {
                _backgroundWorker.DoWork += _backgroundWorker_DoWork;
                _backgroundWorker.RunWorkerCompleted += _backgroundWorker_RunWorkerCompleted;
                _backgroundWorker.RunWorkerAsync();
            }
        }

        private void _backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (_backgroundWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                new Action(() => { ProgressBar.Visibility = Visibility.Visible; }));

            Stations = StaticDbContext.ConnectFireStore.GetAllDocumentData<Station>("ROOT", "STATIONS", "STN_DETAILS");
            Ttes = StaticDbContext.ConnectFireStore.GetAllDocumentData<Tte>("ROOT", "TT_DETAILS", "TT");
            Trains = StaticDbContext.ConnectFireStore.GetAllDocumentData<Train>("ROOT", "TRAIN_DETAILS", "12073");

            /*var d = Trains[0].ROUTE.TryGetValue("1", out var value);
            if (value != null) MessageBox.Show(value.STN_CODE);*/
        }

        private void _backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
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
                ComboBoxSource.IsEnabled = ComboBoxTteId.IsEnabled = ComboBoxTteName.IsEnabled = true;

                foreach (var tte in Ttes)
                {
                    ComboBoxTteId.Items.Add(tte.TT_ID);
                    ComboBoxTteName.Items.Add(tte.FullName);
                }

                foreach (var station in Stations)
                {
                    ComboBoxSource.Items.Add(station.STN_NAME);
                    ComboBoxDestination.Items.Add(station.STN_NAME);

                    if (station.STN_CODE != null &&
                        station.STN_CODE.Contains(DataHelper.Train.DEST_STN ?? throw new InvalidOperationException()))
                        ComboBoxSource.Items.Remove(station);
                }
            }

            ProgressBar.Visibility = Visibility.Collapsed;
            ComboBoxSource.SelectedItem = Stations.FirstOrDefault(s =>
                s.STN_CODE != null && s.STN_NAME != null &&
                    s.STN_CODE.Contains(DataHelper.Train.SRC_STN ?? throw new InvalidOperationException()))
                ?.STN_NAME;
        }

        private void ComboBoxTteId_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxTteId.SelectedItem != null)
                ComboBoxTteName.SelectedItem =
                    Ttes.FirstOrDefault(t => t.TT_ID == ComboBoxTteId.SelectedItem as string)?.FullName;
        }

        private void ComboBoxTteName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxTteName.SelectedItem != null)
                ComboBoxTteId.SelectedItem =
                    Ttes.FirstOrDefault(t => t.FullName == ComboBoxTteName.SelectedItem as string)
                        ?.TT_ID;
        }

        private void ComboBoxSource_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = ComboBoxSource.SelectedItem;
            ComboBoxDestination.Items.Remove(selectedItem);
            //Stations.Remove(selectedItem.ToString());

            if (ComboBoxSource.SelectedItem != null)
                ComboBoxDestination.IsEnabled = true;
        }

        private void ComboBoxDestination_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxDestination.SelectedItem == null)
            {
                _status = false;
                return;
            }

            var destinationStation = DataHelper.Train.DEST_STN;

            _status = ComboBoxDestination.SelectedItem.ToString().Contains(
                Stations.FirstOrDefault(s => s.STN_CODE == destinationStation)?.STN_NAME ??
                throw new InvalidOperationException());
        }

        private void PickerSource_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void DatePickerSource_OnSelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            TimePickerSource.IsEnabled = true;
            TimePickerSource.SelectedTime = null;

            // Here TimeSpan.FromDays() is used for not black-outing selected date
            // (as train journey may be of 24 hours 😅) 

            if (DatePickerSource.SelectedDate != null)
                DatePickerDestination.BlackoutDates.Add(new CalendarDateRange(DateTime.Now,
                    DatePickerSource.SelectedDate.Value - TimeSpan.FromDays(1)));
        }

        private void DatePickerDestination_OnSelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            TimePickerDestination.IsEnabled = true;
            TimePickerDestination.SelectedTime = null;
        }

        private void TimePickerSource_OnSelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            DatePickerDestination.IsEnabled = true;
            TimePickerDestination.SelectedTime = null;
        }

        private void TimePickerDestination_OnSelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            if (TimePickerSource.SelectedTime == null) return;

            var timeSpan = TimePickerSource.SelectedTime.Value.TimeOfDay;

            if (TimePickerDestination.SelectedTime == null ||
                TimePickerDestination.SelectedTime.Value.TimeOfDay > timeSpan) return;

            if (DatePickerSource.SelectedDate != DatePickerDestination.SelectedDate) return;

            MessageBox.Show("Sorry, but time is invalid!");
            TimePickerDestination.SelectedTime = null;
        }

        private void ButtonProceed_OnClick(object sender, RoutedEventArgs e)
        {
            var id = this
                .FindChildren<ComboBox>()
                .Count(comboBox => !string.IsNullOrWhiteSpace(comboBox.Text));

            id += this
                .FindChildren<DatePicker>()
                .Count(datePicker => !string.IsNullOrWhiteSpace(datePicker.Text));

            id += this
                .FindChildren<MaterialDesignThemes.Wpf.TimePicker>()
                .Count(timePicker => !string.IsNullOrWhiteSpace(timePicker.Text));

            var validData = id == 8;

            if (!validData)
                MessageBox.Show("Please fill all the details!");
            else
            {
                if (_status)
                {
                    DataHelper.StatusForEnable = true;
                    TextBlockWelcome.Text = "Thanks for Adding";
                    var controls = this.FindChildren<Control>();
                    foreach (var control in controls)
                    {
                        control.IsEnabled = false;
                    }
                    return;
                }

                DataHelper.Train.SRC_STN = Stations.FirstOrDefault(s => s.STN_NAME == ComboBoxDestination.Text)?.STN_CODE;

                DataContext = new SelectTteViewModel(DataHelper.Train);
                TextBlockWelcome.Text = "Add another TTE Details";

                ComboBoxSource.SelectedItem =
                    Stations.FirstOrDefault(s =>
                        s.STN_CODE != null &&
                            s.STN_CODE.Contains(DataHelper.Train.SRC_STN ?? throw new InvalidOperationException()))
                        ?.STN_NAME;

                // Waiting for disabling again
                ComboBoxDestination.IsEnabled = false;
                DatePickerDestination.IsEnabled = false;
                TimePickerSource.IsEnabled = false;
                TimePickerDestination.IsEnabled = false;
            }
        }
    }
}
