using BusinessLogicWPF.Helper;
using BusinessLogicWPF.Model;
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
        public List<string> Stations = new List<string>();
        private static readonly BackgroundWorker BackgroundWorker = new BackgroundWorker();
        private bool _status;

        public SelectTte()
        {
            InitializeComponent();
            ComboBoxDestination.IsEnabled = false;

            if (BackgroundWorker.IsBusy)
            {
                BackgroundWorker.WorkerSupportsCancellation = true;
                BackgroundWorker.CancelAsync();
            }

            BackgroundWorker.DoWork += _backgroundWorker_DoWork;
            BackgroundWorker.RunWorkerCompleted += _backgroundWorker_RunWorkerCompleted;
            BackgroundWorker.RunWorkerAsync();

        }

        private void _backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (BackgroundWorker.CancellationPending)
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
                ComboBoxSource.IsEnabled = ComboBoxTteName.IsEnabled = true;

                foreach (var station in Stations)
                {
                    ComboBoxSource.Items.Add(station);
                    ComboBoxDestination.Items.Add(station);
                }
            }

            Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                new Action(() => { ProgressBar.Visibility = Visibility.Collapsed; }));
        }

        private void ComboBoxSource_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = ComboBoxSource.SelectedItem;
            ComboBoxDestination.Items.Remove(selectedItem);

            if (ComboBoxSource.SelectedItem != null)
                ComboBoxDestination.IsEnabled = true;
        }

        private void ComboBoxDestination_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxDestination.SelectedItem == null) return;

            if (ComboBoxDestination.SelectedItem.ToString().Contains(DataHelper.Data.DestinationStation)) return;

            _status = true;
        }

        private void ButtonProceed_OnClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
