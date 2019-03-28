// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StationMasterWindowViewModel.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the StationMasterWindowViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable BadListLineBreaks
namespace BusinessLogicWPF.ViewModel.StationMaster
{
    using System;

    using BusinessLogicWPF.Domain;
    using BusinessLogicWPF.Properties;
    using BusinessLogicWPF.View.StationMaster.UserControls;

    using MaterialDesignThemes.Wpf;

    /// <summary>
    /// The station master window view model.
    /// </summary>
    public class StationMasterWindowViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StationMasterWindowViewModel"/> class.
        /// </summary>
        /// <param name="snackBarMessageQueue">
        /// The snack bar message queue.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// thrown if Argument is null
        /// </exception>
        public StationMasterWindowViewModel([NotNull] ISnackbarMessageQueue snackBarMessageQueue)
        {
            if (snackBarMessageQueue == null)
            {
                throw new ArgumentNullException(nameof(snackBarMessageQueue));
            }

            this.DemoItems = new[]
                                 {
                                     new DemoItem("Home", new StationMasterHome()),
                                     new DemoItem("Allocate TTE", new AllocateTte { DataContext = new AllocateTteViewModel() }),
                                     new DemoItem("History", new History())
                                 };
        }

        /// <summary>
        /// Gets or sets the demo items.
        /// </summary>
        [NotNull]
        public DemoItem[] DemoItems { get; set; }
    }
}
