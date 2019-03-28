// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StationMasterWindow.xaml.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Interaction logic for StationMasterWindow.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessLogicWPF.View.StationMaster.Window
{
    using System;
    using System.ComponentModel;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls.Primitives;
    using System.Windows.Input;
    using System.Windows.Media;

    using BusinessLogicWPF.Properties;
    using BusinessLogicWPF.ViewModel.StationMaster;

    using MaterialDesignThemes.Wpf;

    /// <summary>
    /// Interaction logic for Station Master Window XAML file
    /// </summary>
    public partial class StationMasterWindow : Window
    {
        /// <summary>
        /// The snack-bar.
        /// </summary>
        [CanBeNull]
        private static Snackbar snackbar;

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BusinessLogicWPF.View.StationMaster.Window.StationMasterWindow" /> class.
        /// </summary>
        public StationMasterWindow()
        {
            this.InitializeComponent();

            Task.Factory.StartNew(() => Thread.Sleep(2000)).ContinueWith(
                t => this.MainSnackbar.MessageQueue.Enqueue("Hello Station Master"),
                TaskScheduler.FromCurrentSynchronizationContext());

            this.DataContext = new StationMasterWindowViewModel(this.MainSnackbar.MessageQueue);

            snackbar = this.MainSnackbar;
        }

        /// <summary>
        /// The UI element on preview mouse left button up.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void UiElementOnPreviewMouseLeftButtonUp([NotNull] object sender, [NotNull] MouseButtonEventArgs e)
        {
            if (sender == null)
            {
                throw new ArgumentNullException(nameof(sender));
            }

            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            // until we had a StaysOpen to Drawer, this will help with scroll bars
            var dependencyObject = Mouse.Captured as DependencyObject;
            while (dependencyObject != null)
            {
                if (dependencyObject is ScrollBar)
                {
                    return;
                }

                dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
            }

            this.MenuToggleButton.IsChecked = false;
        }

        /// <summary>
        /// The station master window on closing.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void StationMasterWindowOnClosing([NotNull] object sender, [NotNull] CancelEventArgs e)
        {
            if (sender == null)
            {
                throw new ArgumentNullException(nameof(sender));
            }

            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }
        }

        /// <summary>
        /// The close dialog host on dialog closing.
        /// </summary>
        /// <param name="eventArgs">
        /// The event args.
        /// </param>
        private void CloseDialogHostOnDialogClosing([NotNull] DialogClosingEventArgs eventArgs)
        {
            if (eventArgs == null)
            {
                throw new ArgumentNullException(nameof(eventArgs));
            }

            if (!object.Equals(eventArgs.Parameter, true))
            {
                return;
            }

            this.Close();
        }
    }
}
