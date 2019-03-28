// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoginSelection.xaml.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Interaction logic for LoginSelection.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessLogicWPF.View.LoginAndRegister.UserControls
{
    using System.Windows;
    using System.Windows.Controls;

    using BusinessLogicWPF.Helper;
    using BusinessLogicWPF.Properties;
    using BusinessLogicWPF.ViewModel.LoginAndRegister;

    using Window = System.Windows.Window;

    /// <summary>
    /// Interaction logic for Login Selection XAML
    /// </summary>
    public partial class LoginSelection : UserControl
    {
        /// <summary>
        /// The window.
        /// </summary>
        [CanBeNull]
        private readonly Window window;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginSelection"/> class.
        /// </summary>
        public LoginSelection()
        {
            this.InitializeComponent();
            this.window = Application.Current.MainWindow;
        }

        /// <summary>
        /// The button login as admin click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ButtonLoginAsAdminClick([CanBeNull] object sender, [CanBeNull] RoutedEventArgs e)
        {
            ErrorLabelHelper.Reset();
            
            // win for window
            var win = this.window;

            if (win != null)
            {
                win.DataContext = new LoginAsAdminViewModel();
            }
        }

        /// <summary>
        /// The button login as station master click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ButtonLoginAsStationMasterClick([CanBeNull] object sender, [CanBeNull] RoutedEventArgs e)
        {
            ErrorLabelHelper.Reset();

            // win for window
            var win = this.window;
            if (win != null)
            {
                win.DataContext = new LoginAsStationMasterViewModel();
            }
        }

        /// <summary>
        /// The button login as TTE click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ButtonLoginAsTteClick([CanBeNull] object sender, [CanBeNull] RoutedEventArgs e)
        {
            ErrorLabelHelper.Reset();
            
            // win for window
            var win = this.window;
            if (win != null)
            {
                win.DataContext = new LoginAsTteViewModel();
            }
        }
    }
}
