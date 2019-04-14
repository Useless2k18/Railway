// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddRouteOfTrain.xaml.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Interaction logic for AddRouteOfTrain.XAML
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessLogicWPF.View.Admin.UserControls.ForHelpers
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Threading;

    using BusinessLogicWPF.ExtensionMethods;
    using BusinessLogicWPF.Helper;
    using BusinessLogicWPF.Model;
    using BusinessLogicWPF.ViewModel.Admin.ForHelpers;

    using MaterialDesignThemes.Wpf;

    /// <summary>
    /// Interaction logic for AddRouteOfTrain.XAML
    /// </summary>
    public partial class AddRouteOfTrain : UserControl
    {
        /// <summary>
        /// The background worker.
        /// </summary>
        private BackgroundWorker backgroundWorker;
        
        /// <summary>
        /// The routes.
        /// </summary>
        private ObservableCollection<Route> routes = new ObservableCollection<Route>();

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BusinessLogicWPF.View.Admin.UserControls.ForHelpers.AddRouteOfTrain" /> class.
        /// </summary>
        public AddRouteOfTrain()
        {
            this.InitializeComponent();

            if (DataHelper.Train != null)
            {
                this.TextBlockRouteHeader.Text += DataHelper.Train.TrainNumber;
            }

            this.DataGrid.ItemsSource = this.routes;
        }

        /// <summary>
        /// The get ITH digit from right end.
        /// </summary>
        /// <param name="n">
        /// The n.
        /// </param>
        /// <param name="i">
        /// The i.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        private static int GetIthDigitFromRightEnd(int n, int i)
        {
            return (int)((n / Math.Pow(10, i - 1)) % 10);
        }

        /// <summary>
        /// The button delete on click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ButtonDeleteOnClick(object sender, RoutedEventArgs e)
        {
            var selectedRow = ExtendedVisualTreeHelper.GetVisualParent<DataGridRow>(sender as DependencyObject).Item;

            if (this.routes.Contains((Route)selectedRow))
            {
                this.routes.Remove((Route)selectedRow);
            }

            if (this.routes.Count == 0)
            {
                this.TextBlockForBlankRow.Visibility = Visibility.Visible;
                this.DataGrid.Visibility = Visibility.Collapsed;
            }

            this.DataGrid.ItemsSource = this.routes;
        }

        /// <summary>
        /// The button add route on click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private async void ButtonAddRouteOnClick(object sender, RoutedEventArgs e)
        {
            var dialog1 = new AddRouteDialog { DataContext = new AddRouteDialogViewModel() };

            var result1 = await DialogHost.Show(dialog1, "RootDialog")
                              .ConfigureAwait(false);

            if (result1 != null)
            {
                this.Dispatcher.Invoke(
                    () =>
                        {
                            this.routes.Add((Route)result1);
                            this.routes = new ObservableCollection<Route>(this.routes.DistinctBy(r => r.StationCode));
                            this.DataGrid.ItemsSource = this.routes;

                            if (this.routes.Count != 0)
                            {
                                this.TextBlockForBlankRow.Visibility = Visibility.Collapsed;
                                this.DataGrid.Visibility = Visibility.Visible;
                            }
                        },
                    DispatcherPriority.Normal);
            }
        }

        /// <summary>
        /// The button edit on click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private async void ButtonEditOnClick(object sender, RoutedEventArgs e)
        {
            var selectedRow = ExtendedVisualTreeHelper.GetVisualParent<DataGridRow>(sender as DependencyObject).Item;

            var dialog2 = new AddRouteDialog { DataContext = new AddRouteDialogViewModel((Route)selectedRow) };

            var result2 = await DialogHost.Show(dialog2, "RootDialog")
                              .ConfigureAwait(false);

            if (result2 != null)
            {
                this.Dispatcher.Invoke(
                    () =>
                        {
                            this.routes.Remove((Route)selectedRow);
                            this.routes.Add((Route)result2);
                            this.routes = new ObservableCollection<Route>(this.routes.DistinctBy(r => r.StationCode));
                            this.DataGrid.ItemsSource = this.routes;
                        },
                    DispatcherPriority.Normal);
            }
        }

        /// <summary>
        /// The button accept on click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ButtonAcceptOnClick(object sender, RoutedEventArgs e)
        {
            if (DataHelper.Train != null)
            {
                if (this.routes.Count == 0)
                {
                    MessageBox.Show($"Please add routes for the Train {DataHelper.Train.TrainNumber}");
                    return;
                }

                if (this.routes.Any(r => r.StationCode == DataHelper.Train.SourceStation) == false)
                {
                    MessageBox.Show($"Please add a route details for Source Station {DataHelper.Train.SourceStation}");
                    return;
                }

                if (this.routes.Any(r => r.StationCode == DataHelper.Train.DestinationStation) == false)
                {
                    MessageBox.Show(
                        $"Please add a route details for Destination Station {DataHelper.Train.DestinationStation}");
                    return;
                }
            }

            MessageBox.Show("Congratulations! You have added a new Train into the Database");
            if (DataHelper.Train != null)
            {
                if (MessageBox.Show(
                        "Lets Confirm" 
                        + $"\nTrain Number: {DataHelper.Train.TrainNumber}"
                        + $"\nTrain Name: {DataHelper.Train.TrainName}"
                        + $"\nTrain Type: {DataHelper.Train.Type}"
                        + $"\nSource Station: {DataHelper.Train.SourceStation}"
                        + $"\nDestination Station: {DataHelper.Train.DestinationStation}"
                        + $"\nRake Zone: {DataHelper.Train.RakeZone}",
                        "Confirm Message",
                        MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
                {
                    MessageBox.Show("Ok... Data is not added");
                    return;
                }
            }

            if (DataHelper.Train != null)
            {
                DataHelper.Train.Route = this.routes.ToList();
            }

            this.backgroundWorker = new BackgroundWorker();
            this.backgroundWorker.DoWork += this.BackgroundWorkerDoWork;
            this.backgroundWorker.RunWorkerCompleted += this.BackgroundWorkerRunWorkerCompleted;
            try
            {
                this.backgroundWorker.RunWorkerAsync();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        /// <summary>
        /// The background worker do work.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void BackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            if (DataHelper.Train != null)
            {
                StaticDbContext.ConnectFireStore?.AddOrUpdateCollectionDataAsync(
                    DataHelper.Train,
                    "Root",
                    "TrainDetails",
                    $"{GetIthDigitFromRightEnd(DataHelper.Train.TrainNumber, 5)}XXXX",
                    $"Y{GetIthDigitFromRightEnd(DataHelper.Train.TrainNumber, 4)}XXX",
                    "Trains",
                    DataHelper.Train.TrainNumber.ToString());
            }
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
        private void BackgroundWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Refresh();

            DataHelper.Accept = true;
        }

        /// <summary>
        /// The refresh.
        /// </summary>
        private void Refresh()
        {
            this.routes.Clear();
        }
    }
}
