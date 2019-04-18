// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AdminHome.xaml.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Interaction logic for AdminHome.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessLogicWPF.View.Admin.UserControls
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Windows;
    using System.Windows.Controls;

    using BusinessLogicWPF.Helper;
    using BusinessLogicWPF.Model;
    using BusinessLogicWPF.Model.Json.Creation;

    using MaterialDesignThemes.Wpf;

    using Newtonsoft.Json;

    /// <summary>
    /// Interaction logic for AdminHome.XAML
    /// </summary>
    public partial class AdminHome : UserControl
    {
        /// <summary>
        /// The background worker.
        /// </summary>
        private BackgroundWorker backgroundWorker;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="AdminHome"/> class.
        /// </summary>
        public AdminHome()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// The tile refresh on click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ButtonRefreshOnClick(object sender, RoutedEventArgs e)
        {
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
        private async void BackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            this.Dispatcher.Invoke(() => ButtonProgressAssist.SetIsIndeterminate(this.ButtonRefresh, true));

            #region Zone And Division

            var zoneAndDivisionModel =
                StaticDbContext.ConnectFireStore.GetCollectionFields<ZoneAndDivision>("Root", "Employee");

            DataHelper.ZoneAndDivisionModel = zoneAndDivisionModel;
            
            var jsonResult = JsonConvert.SerializeObject(zoneAndDivisionModel, Formatting.Indented);

            var zoneAndDivisionFile = Path.Combine(DataHelper.JsonFolderPath, Properties.Resources.ZoneAndDivisionJson);

            if (File.Exists(zoneAndDivisionFile))
            {
                File.Delete(zoneAndDivisionFile);
            }

            using (var streamWriter = new StreamWriter(zoneAndDivisionFile, true))
            {
                await streamWriter.WriteLineAsync(jsonResult).ConfigureAwait(false);
                streamWriter.Close();
            }

            #endregion

            #region Stations

            if (DataHelper.ZoneAndDivisionModel != null)
            {
                var stationsList = new StationsList { Stations = new Dictionary<string, Station>() };

                foreach (var zone in DataHelper.ZoneAndDivisionModel.ZoneList)
                {
                    var collectionList = StaticDbContext.ConnectFireStore.GetCollections(
                        "Root",
                        "Stations",
                        "StationDetails",
                        zone);

                    foreach (var collectionReference in collectionList)
                    {
                        var stations = StaticDbContext.ConnectFireStore.GetAllDocumentData<Station>(
                            "Root",
                            "Stations",
                            "StationDetails",
                            zone,
                            collectionReference.Id);

                        foreach (var station in stations)
                        {
                            stationsList.Stations.Add(new KeyValuePair<string, Station>(station.StationCode, station));
                        }
                    }
                }

                DataHelper.StationsList = stationsList;

                var jsonResult2 = JsonConvert.SerializeObject(stationsList, Formatting.Indented);

                var stationsJson = Path.Combine(DataHelper.JsonFolderPath, Properties.Resources.StationsListJson);

                if (File.Exists(stationsJson))
                {
                    File.Delete(stationsJson);
                }

                using (var streamWriter = new StreamWriter(stationsJson, true))
                {
                    await streamWriter.WriteLineAsync(jsonResult2).ConfigureAwait(false);
                    streamWriter.Close();
                }
            }

            #endregion
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
            ButtonProgressAssist.SetIsIndeterminate(this.ButtonRefresh, false);
        }
    }
}
