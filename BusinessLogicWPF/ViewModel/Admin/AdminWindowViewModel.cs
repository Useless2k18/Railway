// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AdminWindowViewModel.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the AdminWindowViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessLogicWPF.ViewModel.Admin
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Windows;

    using BusinessLogicWPF.Domain;
    using BusinessLogicWPF.GoogleCloudFireStoreLibrary;
    using BusinessLogicWPF.Helper;
    using BusinessLogicWPF.Properties;
    using BusinessLogicWPF.View.Admin.UserControls;

    using MaterialDesignThemes.Wpf;

    /// <summary>
    /// The admin window view model.
    /// </summary>
    public class AdminWindowViewModel
    {
        /// <summary>
        /// The files.
        /// </summary>
        [NotNull]
        private static readonly string Files = Directory.GetCurrentDirectory();

        /// <summary>
        /// The secret folder.
        /// </summary>
        [NotNull]
        private static readonly string SecretFolder = Path.Combine(Files, "Secret");

        /// <summary>
        /// Initializes a new instance of the <see cref="AdminWindowViewModel"/> class.
        /// </summary>
        /// <param name="snackBarMessageQueue">
        /// The snack bar message queue.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// thrown if Argument is null
        /// </exception>
        public AdminWindowViewModel([NotNull] ISnackbarMessageQueue snackBarMessageQueue)
        {
            if (snackBarMessageQueue == null)
            {
                throw new ArgumentNullException(nameof(snackBarMessageQueue));
            }

            this.DemoItems = new[]
                                 {
                                     new DemoItem("Home", new AdminHome()),
                                     new DemoItem("Add Train", new AddTrain { DataContext = new AddTrainViewModel() }),
                                     new DemoItem(
                                         "Add Station",
                                         new AddStation { DataContext = new AddStationViewModel() }),
                                     new DemoItem("Add TTE", new AddTte())
                                 };

            var di = new DirectoryInfo(SecretFolder);
            var jsonFiles = di.GetFiles("*.json");
            if (jsonFiles.Length == 0)
            {
                MessageBox.Show(
                    "Please copy the service-account-key.json file into the Secret Folder of the App Directory!\n" +
                    "Navigate to https://console.developers.google.com/apis/credentials to create a service account key\n" + 
                    "Note: Please Remember to give Owner permission to the service account key.\n" + 
                    "Don\'t forget to change your account to uselessgroup2k18@gmail.com first");
                DataHelper.ExitCode = -1;
                Application.Current.Shutdown(DataHelper.ExitCode);
                Process.Start(SecretFolder);
                Process.Start("https://console.developers.google.com/apis/credentials");
                return;
            }

            DataHelper.ExitCode = 0;

            // Google Cloud Platform project ID.
            const string ProjectId = "ticketchecker-d4f79";

            try
            {
                StaticDbContext.ConnectFireStore = new ConnectFireStore(ProjectId, Path.Combine(SecretFolder, jsonFiles[0].FullName));
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                DataHelper.ExitCode = -1;
                Application.Current.Shutdown(DataHelper.ExitCode);
            }
        }

        /// <summary>
        /// Gets or sets the demo items.
        /// </summary>
        [NotNull]
        public DemoItem[] DemoItems { get; set; }
    }
}
