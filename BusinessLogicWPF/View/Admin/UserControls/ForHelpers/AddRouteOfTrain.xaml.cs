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
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Controls;

    using BusinessLogicWPF.Model;
    using BusinessLogicWPF.View.Helpers.UserControls;
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
        private readonly ObservableCollection<Route> routes = new ObservableCollection<Route>();

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
        /// The tree view selected item changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void TreeViewSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
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
        private void ButtonAddRouteOnClick(object sender, RoutedEventArgs e)
        {
            this.routes.Add(
                new Route
                    {
                        StationCode = "ASN",
                        ArrivalTime = "12:00",
                        DepartureTime = "2:00",
                        TteAssignFlag = 0
                    });

            if (this.TextBlockForBlankRow.Visibility == Visibility.Visible)
            {
                this.TextBlockForBlankRow.Visibility = Visibility.Collapsed;
                this.DataGrid.Visibility = Visibility.Visible;
            }

            /*var dialog1 = new SelectionDialog { DataContext = new SelectCoachCategoryViewModel() };

            var result1 = await DialogHost.Show(dialog1, "RootDialog", this.ClosingEventHandler)
                              .ConfigureAwait(false);*/
        }
    }
}
