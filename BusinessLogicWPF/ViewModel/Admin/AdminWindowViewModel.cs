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

    using BusinessLogicWPF.Annotations;
    using BusinessLogicWPF.Domain;
    using BusinessLogicWPF.View.Admin.UserControls;
    using BusinessLogicWPF.View.StationMaster.UserControls;
    using BusinessLogicWPF.ViewModel.StationMaster;

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
        }

        /// <summary>
        /// Gets or sets the demo items.
        /// </summary>
        [NotNull]
        public DemoItem[] DemoItems { get; set; }
    }
}
