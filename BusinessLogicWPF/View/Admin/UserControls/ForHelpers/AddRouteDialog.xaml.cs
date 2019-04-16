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
    using System.Windows;
    using System.Windows.Controls;

    using BusinessLogicWPF.Helper;
    using BusinessLogicWPF.Model;

    using MaterialDesignThemes.Wpf;

    /// <summary>
    /// Interaction logic for AddRouteDialog.XAML
    /// </summary>
    public partial class AddRouteDialog : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddRouteDialog"/> class.
        /// </summary>
        public AddRouteDialog()
        {
            this.InitializeComponent();
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
            if (this.TextBoxStationCode.Text == DataHelper.Train.SourceStation)
            {
                this.TextBoxArrivalTime.Text = "SRC0";
            }
            else if (this.TextBoxStationCode.Text == DataHelper.Train.DestinationStation)
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
            if (string.IsNullOrWhiteSpace(this.TextBoxStationCode.Text)
                || string.IsNullOrWhiteSpace(this.TextBoxDepartureTime.Text)
                || string.IsNullOrWhiteSpace(this.TextBoxArrivalTime.Text))
            {
                MessageBox.Show("Please fill all the fields");
                return;
            }
            
            if (!DateTime.TryParse(this.TextBoxDepartureTime.Text, out var _))
            {
                if (this.TextBoxDepartureTime.Text == "DEST0"
                    && this.TextBoxStationCode.Text != DataHelper.Train.DestinationStation)
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
                    && this.TextBoxStationCode.Text != DataHelper.Train.SourceStation)
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
                                StationCode = this.TextBoxStationCode.Text,
                                DepartureTime = this.TextBoxDepartureTime.Text,
                                ArrivalTime = this.TextBoxArrivalTime.Text
                            };
            DialogHost.CloseDialogCommand.Execute(route, null);
        }
    }
}
