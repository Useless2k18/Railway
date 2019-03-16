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

    using BusinessLogicWPF.Annotations;
    using BusinessLogicWPF.Domain;
    using BusinessLogicWPF.GoogleCloudFireStoreLibrary;
    using BusinessLogicWPF.Helper;
    using BusinessLogicWPF.View.Admin.UserControls;

    using MaterialDesignThemes.Wpf;

    /// <summary>
    /// The admin window view model.
    /// </summary>
    public class AdminWindowViewModel
    {
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
                                     new DemoItem(
                                         "Add Train",
                                         new AddTrain { DataContext = new AddTrainViewModel() }),
                                     new DemoItem("Add Station", new AddStation()), new DemoItem("Add TTE", new AddTte())
                                 };

            // Google Cloud Platform project ID.
            const string ProjectId = "ticketchecker-d4f79";

            try
            {
                StaticDbContext.ConnectFireStore = new ConnectFireStore(ProjectId, @"TicketChecker-1f6bf5c2db0a.json");
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }
        }

        /// <summary>
        /// Gets or sets the demo items.
        /// </summary>
        [NotNull]
        public DemoItem[] DemoItems { get; set; }
    }
}
