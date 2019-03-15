// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AllocateTte.xaml.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Interaction logic for AllocateTte.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessLogicWPF.View.StationMaster.UserControls
{
    using System;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;

    using BusinessLogicWPF.Annotations;
    using BusinessLogicWPF.Model;
    using BusinessLogicWPF.View.Helpers.UserControls;
    using BusinessLogicWPF.ViewModel.StationMaster;
    using BusinessLogicWPF.ViewModel.StationMaster.ForHelper;

    using MaterialDesignThemes.Wpf;

    /// <summary>
    /// Interaction logic for Allocate TTE XAML
    /// </summary>
    public partial class AllocateTte : UserControl
    {
        /// <summary>
        /// The background worker.
        /// </summary>
        [CanBeNull]
        private BackgroundWorker backgroundWorker = new BackgroundWorker();

        /// <summary>
        /// Initializes a new instance of the <see cref="AllocateTte"/> class.
        /// </summary>
        public AllocateTte()
        {
            this.InitializeComponent();
            this.DataContext = new AllocateTteViewModel();
        }

        /// <summary>
        /// The button assign_ on click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private async void ButtonAssign_OnClick([NotNull] object sender, [NotNull] RoutedEventArgs e)
        {
            if (sender == null)
            {
                throw new ArgumentNullException(nameof(sender));
            }

            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            try
            {
                var item = (sender as FrameworkElement)?.DataContext;
                var index = this.ListView1.Items.IndexOf(item ?? throw new InvalidOperationException());
                var data = (Train)this.ListView1.Items[index];

                var dialog = new SelectionDialog { DataContext = new SelectTteViewModel(data) };

                var result = await DialogHost.Show(dialog, "RootDialog", this.ClosingEventHandler)
                                 .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// The closing event handler.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="eventArgs">
        /// The event args.
        /// </param>
        private void ClosingEventHandler([CanBeNull] object sender, [CanBeNull] DialogClosingEventArgs eventArgs)
        {
        }
    }
}
