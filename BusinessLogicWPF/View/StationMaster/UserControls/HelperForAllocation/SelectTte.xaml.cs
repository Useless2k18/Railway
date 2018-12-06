using BusinessLogicWPF.Collections;
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
        private static RailwayDbContext _context;
        private readonly BackgroundWorker _backgroundWorker = new BackgroundWorker();
        private static bool _status;

        public static List<string> Stations = new List<string>();
        public static Dictionary<string, string> TteDetails = TteCollection.GetChoices();

        public SelectTte()
        {
            InitializeComponent();
            ComboBoxDestination.IsEnabled = false;

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

            _context = new RailwayDbContext();
            Stations = _context.Stations.Select(s => s.StationName).ToList();
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

                foreach (var tteDetail in TteDetails)
                {
                    ComboBoxTteId.Items.Add(tteDetail.Key);
                    ComboBoxTteName.Items.Add(tteDetail.Value);
                }

                foreach (var station in Stations)
                {
                    ComboBoxSource.Items.Add(station);
                    ComboBoxDestination.Items.Add(station);

                    if (station.Contains(DataHelper.Data.DestinationStation))
                        ComboBoxSource.Items.Remove(station);
                }
            }

            ProgressBar.Visibility = Visibility.Collapsed;
            ComboBoxSource.SelectedItem = Stations.FirstOrDefault(s => s.Contains(DataHelper.Data.SourceStation));
            /*Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                new Action(() => { ProgressBar.Visibility = Visibility.Collapsed; }));*/
        }

        private void ComboBoxTteId_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxTteId.SelectedItem != null)
                ComboBoxTteName.SelectedItem = TteDetails[(string)ComboBoxTteId.SelectedItem];
        }

        private void ComboBoxTteName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxTteName.SelectedItem != null)
                ComboBoxTteId.SelectedItem = TteDetails.FirstOrDefault(x => x.Value == (string)ComboBoxTteName.SelectedItem).Key;
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
                    Stations.FirstOrDefault(s => s.Contains(DataHelper.Data.SourceStation));
            }
        }
    }
}
