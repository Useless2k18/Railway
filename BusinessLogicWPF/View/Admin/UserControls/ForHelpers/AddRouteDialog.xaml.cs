// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddRouteDialog.xaml.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Interaction logic for AddRouteDialog.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessLogicWPF.View.Admin.UserControls.ForHelpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    using BusinessLogicWPF.Helper;
    using BusinessLogicWPF.Model;
    using BusinessLogicWPF.Properties;

    using MaterialDesignThemes.Wpf;

    /// <summary>
    /// Interaction logic for AddRouteDialog.XAML
    /// </summary>
    public partial class AddRouteDialog : UserControl
    {
        /// <summary>
        /// The list of stations.
        /// </summary>
        private readonly List<Station> listOfStations;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="AddRouteDialog"/> class.
        /// </summary>
        public AddRouteDialog()
        {
            this.InitializeComponent();

            if (DataHelper.StationsList != null)
            {
                this.listOfStations = DataHelper.StationsList.Stations.Values.ToList();
            }
            
            // Just for deleting already selected station
            /*else if (DataHelper.PreviousSelectedStation != null)
            {
                this.listOfStations.Remove(DataHelper.PreviousSelectedStation);
            }*/

            this.ComboBoxStationCode.ItemsSource = this.listOfStations;
        }

        /// <summary>
        /// The framework element on request bring into view.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void FrameworkElementOnRequestBringIntoView(
            [CanBeNull] object sender,
            [NotNull] RequestBringIntoViewEventArgs e)
        {
            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            // Allows the keyboard to bring the items into view as expected:
            if (Keyboard.IsKeyDown(Key.Down) || Keyboard.IsKeyDown(Key.Up))
            {
                return;
            }            

            e.Handled = true;  
        }

        /// <summary>
        /// The text box station code on lost focus.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void TextBoxStationCodeOnLostFocus(object sender, RoutedEventArgs e)
        {
            if (this.ComboBoxStationCode.SelectedValue as string == DataHelper.Train.SourceStation)
            {
                this.TextBoxArrivalTime.Text = "SRC0";
            }
            else if (this.ComboBoxStationCode.SelectedValue as string == DataHelper.Train.DestinationStation)
            {
                this.TextBoxDepartureTime.Text = "DEST0";
            }
            else
            {
                this.TextBoxDepartureTime.Text = string.Empty;
                this.TextBoxArrivalTime.Text = string.Empty;
            }
        }

        /// <summary>
        /// The button cancel on click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ButtonCancelOnClick(object sender, RoutedEventArgs e)
        {
            DialogHost.CloseDialogCommand.Execute(null, null);
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
            if (string.IsNullOrWhiteSpace(this.ComboBoxStationCode.Text)
                || string.IsNullOrWhiteSpace(this.TextBoxDepartureTime.Text)
                || string.IsNullOrWhiteSpace(this.TextBoxArrivalTime.Text))
            {
                MessageBox.Show("Please fill all the fields");
                return;
            }
            
            if (!DateTime.TryParse(this.TextBoxDepartureTime.Text, out var _))
            {
                if (this.TextBoxDepartureTime.Text == "DEST0"
                    && this.ComboBoxStationCode.SelectedValue as string != DataHelper.Train.DestinationStation)
                {
                    MessageBox.Show("Only Destination Station can have Departure Time as DEST0");
                    return;
                }

                if (this.TextBoxDepartureTime.Text != "DEST0")
                {
                    MessageBox.Show("Please type proper Departure Time!");
                    return;
                }
            }
            
            if (!DateTime.TryParse(this.TextBoxArrivalTime.Text, out var _))
            {
                if (this.TextBoxArrivalTime.Text == "SRC0"
                    && this.ComboBoxStationCode.SelectedValue as string != DataHelper.Train.SourceStation)
                {
                    MessageBox.Show("Only Source Station can have Arrival Time as SRC0");
                    return;
                }

                if (this.TextBoxArrivalTime.Text != "SRC0")
                {
                    MessageBox.Show("Please type proper Arrival Time!");
                    return;
                }
            }

            var route = new Route
                            {
                                StationCode = this.ComboBoxStationCode.SelectedValue as string,
                                DepartureTime = this.TextBoxDepartureTime.Text,
                                ArrivalTime = this.TextBoxArrivalTime.Text
                            };

            route.StationZone = DataHelper.StationsList
                .Stations[route.StationCode ?? throw new InvalidOperationException()].Zone;

            route.StationDivision = DataHelper.StationsList.Stations[route.StationCode].RailwayDivision;

            /*// Just for deleting already selected station
            DataHelper.PreviousSelectedStation = DataHelper.StationsList.Stations[route.StationCode ?? throw new InvalidOperationException()];*/

            DialogHost.CloseDialogCommand.Execute(route, null);
        }
    }
}
