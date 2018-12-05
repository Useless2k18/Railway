using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using BusinessLogicWPF.Helper;
using BusinessLogicWPF.Model;
using BusinessLogicWPF.ViewModel.StationMaster.ForHelper;
using MahApps.Metro.Controls.Dialogs;
using MaterialDesignThemes.Wpf;

namespace BusinessLogicWPF.View.StationMaster.UserControls.HelperForAllocation
{
    /// <summary>
    /// Interaction logic for SelectionDialog.xaml
    /// </summary>
    public partial class SelectionDialog : UserControl
    {
        private static RailwayDbContext _context;
        private static readonly BackgroundWorker BackgroundWorker = new BackgroundWorker();

        public IList<string> SourceStations { get; set; }
        public IList<string> DestinationStations { get; set; }

        public SelectionDialog()
        {
        }
        
        public SelectionDialog(int index)
        :base()
        {
            InitializeComponent();
            DataContext = new SelectionDialogViewModel();

            BackgroundWorker.DoWork += _backgroundWorker_DoWork;
            BackgroundWorker.RunWorkerCompleted += _backgroundWorker_RunWorkerCompleted;
            BackgroundWorker.RunWorkerAsync();


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
                ComboBoxSource.IsEnabled = ComboBoxDestination.IsEnabled = ComboBoxTteName.IsEnabled = true;

                ComboBoxSource.ItemsSource = SourceStations;
                ComboBoxDestination.ItemsSource = DestinationStations;
            }

            Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                new Action(() => { ProgressBar.Visibility = Visibility.Collapsed; }));
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
            SourceStations = _context.Stations.Select(s => s.StationName).ToList();
            DestinationStations = _context.Stations.Select(s => s.StationName).ToList();
        }
    }
}
