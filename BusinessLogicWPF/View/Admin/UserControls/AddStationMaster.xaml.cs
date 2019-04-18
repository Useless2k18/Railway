// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddStationMaster.xaml.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Interaction logic for AddStationMaster.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessLogicWPF.View.Admin.UserControls
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Threading;

    using BusinessLogicWPF.Helper;
    using BusinessLogicWPF.Model;
    using BusinessLogicWPF.Properties;

    using MahApps.Metro.Controls;

    using MaterialDesignThemes.Wpf;

    /// <summary>
    /// Interaction logic for AddStationMaster.XAML
    /// </summary>
    public partial class AddStationMaster : UserControl
    {
        /// <summary>
        /// The station master Id.
        /// </summary>
        private string stationMasterId;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="AddStationMaster"/> class.
        /// </summary>
        public AddStationMaster()
        {
            this.InitializeComponent();
            
            this.ComboBoxZoneName.ItemsSource = DataHelper.ZoneAndDivisionModel.ZoneList;
        }

        /// <summary>
        /// The combo box zone name on selection changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ComboBoxZoneNameOnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.ComboBoxZoneName.SelectedItem == null)
            {
                return;
            }
            
            var b = DataHelper.ZoneAndDivisionModel.DivisionList.TryGetValue(
                this.ComboBoxZoneName.SelectedItem.ToString(),
                out var divisionsList);

            if (b)
            {
                this.ComboBoxDivisionName.ItemsSource = divisionsList;
                this.ComboBoxDivisionName.IsEnabled = true;
            }
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
        /// The button refresh on click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ButtonRefreshOnClick(object sender, RoutedEventArgs e)
        {
            this.Refresh();
            this.ComboBoxDivisionName.IsEnabled = false;
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
            if (string.IsNullOrWhiteSpace(this.TextBoxStationMasterName.Text)
                || string.IsNullOrWhiteSpace(this.ComboBoxZoneName.Text)
                || string.IsNullOrWhiteSpace(this.ComboBoxDivisionName.Text))
            {
                MessageBox.Show("Please fill up all the fields!");
                return;
            }

            if (!this.TextBoxStationMasterName.Text.Contains(" "))
            {
                if (MessageBox.Show(
                        $"Is \"{this.TextBoxStationMasterName.Text}\" Full Name of the Station Master?",
                        "Confirmation of Full Name",
                        MessageBoxButton.YesNo) == MessageBoxResult.No)
                {
                    return;
                }
            }

            var backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += this.BackgroundWorkerDoWork;
            backgroundWorker.RunWorkerCompleted += this.BackgroundWorkerRunWorkerCompleted;

            try
            {
                backgroundWorker.RunWorkerAsync();
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
        private async void BackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            var stationMasterName = string.Empty;
            var zone = string.Empty;
            var division = string.Empty;

            this.Dispatcher.Invoke(
                () =>
                    {
                        ButtonProgressAssist.SetIsIndicatorVisible(this.ButtonAccept, true);
                        stationMasterName = this.TextBoxStationMasterName.Text;
                        zone = this.ComboBoxZoneName.Text;
                        division = this.ComboBoxDivisionName.Text;
                    },
                DispatcherPriority.Normal);

            var id = StaticDbContext.ConnectFireStore.GetAllDocumentId(
                "Root",
                "Employee",
                zone,
                division,
                "StationMaster");

            var max = 0;

            if (id.Count != 0)
            {
                max = Convert.ToInt32(id.OrderByDescending(i => int.Parse(i.Substring(8))).First().Substring(8));
            }

            this.stationMasterId = $"{(int)EnumEmployeeGroups.GroupB:D2}" + 
                                   $"{(int)EnumEmployeeType.StationMaster:D2}" + 
                                   $"{DataHelper.ZoneAndDivisionModel.ZoneList.IndexOf(zone):D2}" + 
                                   $"{DataHelper.ZoneAndDivisionModel.DivisionList[zone].IndexOf(division):D2}" + 
                                   $"{(max + 1):D7}";

            var stationMaster = new StationMaster
                                    {
                                        Name = stationMasterName, 
                                        Id = this.stationMasterId
                                    };

            var noOfStationMaster = 0;

            var divisionField =
                StaticDbContext.ConnectFireStore.GetCollectionFields("Root", "Employee", zone, division);

            if (divisionField != null)
            {
                noOfStationMaster = Convert.ToInt32(divisionField["noOfStationMaster"]);
            }

            noOfStationMaster++;

            await StaticDbContext.ConnectFireStore.AddOrUpdateCollectionDataAsync(
                new Dictionary<string, int> { { "noOfStationMaster", noOfStationMaster } },
                "Root",
                "Employee",
                zone,
                division);

            await StaticDbContext.ConnectFireStore.AddOrUpdateCollectionDataAsync(
                stationMaster,
                "Root",
                "Employee",
                zone,
                division,
                "StationMaster",
                stationMaster.Id);
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
            MessageBox.Show("You have successfully added Station Master" + $"\nName: {this.TextBoxStationMasterName.Text}\nId: {this.stationMasterId}");
            ButtonProgressAssist.SetIsIndicatorVisible(this.ButtonAccept, false);
        }

        /// <summary>
        /// The refresh.
        /// </summary>
        private void Refresh()
        {
            foreach (var textBox in this.FindChildren<TextBox>())
            {
                textBox.Clear();
            }

            foreach (var comboBox in this.FindChildren<ComboBox>())
            {
                comboBox.SelectedIndex = 1;
            }

            ErrorLabelHelper.Reset();
        }
    }
}
