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
    using System.Collections.ObjectModel;
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

            this.DataGrid.ItemsSource = this.routes;
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

        private void ButtonAcceptOnClick(object sender, RoutedEventArgs e)
        {
            DataHelper.Accept = true;
        }
    }
}
