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
    using System.ComponentModel;
    using System.IO;
    using System.Windows;
    using System.Windows.Controls;

    using BusinessLogicWPF.Helper;
    using BusinessLogicWPF.Model.Json.Creation;

    using MaterialDesignThemes.Wpf;

    using Newtonsoft.Json;

    /// <summary>
    /// Interaction logic for AdminHome.XAML
    /// </summary>
    public partial class AdminHome : UserControl
    {
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
        private void BackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            this.Dispatcher.Invoke(() => ButtonProgressAssist.SetIsIndeterminate(this.ButtonRefresh, true));

            var zoneAndDivisionModel = StaticDbContext.ConnectFireStore.GetCollectionFields<ZoneAndDivisionModel>("Root", "Employee");
            
            var jsonResult = JsonConvert.SerializeObject(zoneAndDivisionModel, Formatting.Indented);
            const string Json = @"ZoneAndDivision.json";

            var jsonFile = Path.Combine(DataHelper.JsonFolderPath, Json);

            if (File.Exists(jsonFile))
            {
                File.Delete(jsonFile);
            }

            using (var streamWriter = new StreamWriter(jsonFile, true))
            {
                streamWriter.WriteLineAsync(jsonResult);
                streamWriter.Close();
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
            ButtonProgressAssist.SetIsIndeterminate(this.ButtonRefresh, false);
        }
    }
}
