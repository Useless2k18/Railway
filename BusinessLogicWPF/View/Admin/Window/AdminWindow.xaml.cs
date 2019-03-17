// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AdminWindow.xaml.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Interaction logic for AdminWindow.XAML
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessLogicWPF.View.Admin.Window
{
    using System;
    using System.ComponentModel;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls.Primitives;
    using System.Windows.Input;
    using System.Windows.Media;

    using BusinessLogicWPF.Annotations;
    using BusinessLogicWPF.Helper;
    using BusinessLogicWPF.ViewModel.Admin;

    using MahApps.Metro.Controls;

    using MaterialDesignThemes.Wpf;

    /// <summary>
    /// Interaction logic for AdminWindow.XAML
    /// </summary>
    public partial class AdminWindow : MetroWindow
    {
        /// <summary>
        /// The snack-bar.
        /// </summary>
        [CanBeNull]
        private static Snackbar snackbar;

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BusinessLogicWPF.View.Admin.Window.AdminWindow" /> class.
        /// </summary>
        public AdminWindow()
        {
            this.InitializeComponent();

            Task.Factory.StartNew(() => Thread.Sleep(2000)).ContinueWith(
                t => this.MainSnackbar.MessageQueue.Enqueue("Hello Admin"),
                TaskScheduler.FromCurrentSynchronizationContext());

            this.DataContext = new AdminWindowViewModel(this.MainSnackbar.MessageQueue);

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
        private void AdminWindowOnClosing([NotNull] object sender, [NotNull] CancelEventArgs e)
        {
            if (sender == null)
            {
                throw new ArgumentNullException(nameof(sender));
            }

            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            if (DataHelper.ExitCode == -1)
            {
                return;
            }

            if (MessageBox.Show(
                    "Are you sure you want to Log out from your system?",
                    "Question",
                    MessageBoxButton.YesNo) == MessageBoxResult.No)
            {
                e.Cancel = true;
                return;
            }

            // After closing
            StaticDbContext.ConnectFireStore = null;
            DataHelper.StatusForEnable = false;
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
