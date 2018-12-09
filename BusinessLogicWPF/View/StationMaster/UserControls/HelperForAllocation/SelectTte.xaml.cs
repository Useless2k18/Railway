using BusinessLogicWPF.GoogleCloudFireStoreLibrary;
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
        //public static Dictionary<string, string> TteDetails = new Dictionary<string, string>();

        public SelectTte()
        {
            InitializeComponent();
            ComboBoxDestination.IsEnabled = false;
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

            // Google Cloud Platform project ID.
            const string projectId = "ticketchecker-d4f79";

            var connect = new ConnectFireStore(projectId, @"TicketChecker-1f6bf5c2db0a.json");

            Stations = connect.GetAllDocumentData<Station>("ROOT", "STATIONS", "STN_DETAILS");
            Ttes = connect.GetAllDocumentData<Tte>("ROOT", "TT_DETAILS", "TT");
            var station = new Station
            {
                STN_CODE = "ASN",
                STN_NAME = "Asansol Junction",
                STN_PIN = "713303"
            };
            //connect.AddCollectionData(station, "ROOT", "STATIONS", "STN_DETAILS", station.STN_CODE).Wait();
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

                    if (station.STN_NAME != null && station.STN_NAME.Contains(DataHelper.Data.DestinationStation))
                        ComboBoxSource.Items.Remove(station);
                }
            }

            ProgressBar.Visibility = Visibility.Collapsed;
            ComboBoxSource.SelectedItem = Stations.FirstOrDefault(s =>
                s.STN_NAME != null && s.STN_NAME.Contains(DataHelper.Data.SourceStation))
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
            if (ComboBoxDestination.SelectedItem == null) return;

            if (!ComboBoxDestination.SelectedItem.ToString().Contains(DataHelper.Data.DestinationStation)) return;

            _status = true;
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

                DataHelper.Data.SourceStation = ComboBoxDestination.Text;

                DataContext = new SelectTteViewModel(DataHelper.Data);
                TextBlockWelcome.Text = "Add another TTE Details";
                ComboBoxSource.SelectedItem =
                    Stations.FirstOrDefault(s =>
                        s.STN_NAME != null && s.STN_NAME.Contains(DataHelper.Data.SourceStation))?.STN_NAME;
            }
        }

        private void PickerSource_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            e.Handled = true;
        }
    }
}
