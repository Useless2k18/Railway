// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WindowLoginAndRegister.xaml.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Interaction logic for MainWindow.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessLogicWPF.View.LoginAndRegister.Window
{
    using System;
    using System.IO;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    using BusinessLogicWPF.Annotations;
    using BusinessLogicWPF.ViewModel.LoginAndRegister;

    using MahApps.Metro.Controls;

    using Microsoft.Win32;

    /// <summary>
    /// Interaction logic for Main Window XAML
    /// </summary>
    public partial class WindowLoginAndRegister : MetroWindow
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
        /// The counter.
        /// </summary>
        private int counter;

        /// <summary>
        /// Initializes a new instance of the <see cref="WindowLoginAndRegister"/> class.
        /// </summary>
        public WindowLoginAndRegister()
        {
            if (!CheckNet())
            {
                MessageBox.Show("Please connect system to Internet first!");
                Application.Current.Shutdown(-1);
            }

            this.InitializeComponent();
            this.Left = 100;
            this.Top = 10;
            SystemEvents.DisplaySettingsChanged += this.SystemEventsDisplaySettingsChanged;
            this.DataContext = new LoginViewModel();

            if (!Directory.Exists(SecretFolder))
            {
                Directory.CreateDirectory(SecretFolder);
            }
        }

        [System.Runtime.InteropServices.DllImport("wininet.dll")]
        private static extern bool InternetGetConnectedState(out int description, int reservedValue);

        /// <summary>
        /// The check net.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool CheckNet()
        {
            return InternetGetConnectedState(out var desc, 0);
        }

        /// <summary>
        /// The system events display settings changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void SystemEventsDisplaySettingsChanged([CanBeNull] object sender, [CanBeNull] EventArgs e)
        {
            this.Left = SystemParameters.PrimaryScreenWidth - this.Width;
            this.Top = SystemParameters.PrimaryScreenHeight - this.Height;
        }

        /// <summary>
        /// The button new user click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ButtonNewUserClick([CanBeNull] object sender, [CanBeNull] RoutedEventArgs e)
        {
            if (this.counter % 2 == 0)
            {
                this.ButtonNewUser.Content = "Already Registered?";
                this.DataContext = new RegisterViewModel();
                this.ButtonBack.Visibility = Visibility.Collapsed;
            }
            else
            {
                this.ButtonNewUser.Content = "New User?";
                this.DataContext = new LoginViewModel();
                this.ButtonBack.Visibility = Visibility.Collapsed;
            }

            this.counter++;
        }

        /// <summary>
        /// The button like label mouse enter.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ButtonLikeLabelMouseEnter([CanBeNull] object sender, [CanBeNull] MouseEventArgs e)
        {
            if (sender is Button button)
            {
                button.FontWeight = FontWeights.Bold;
            }
        }

        /// <summary>
        /// The button like label mouse leave.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ButtonLikeLabelMouseLeave([CanBeNull] object sender, [CanBeNull] MouseEventArgs e)
        {
            if (sender is Button button)
            {
                button.FontWeight = FontWeights.Normal;
            }
        }

        /// <summary>
        /// The button back on click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ButtonBackOnClick([CanBeNull] object sender, [CanBeNull] RoutedEventArgs e)
        {
            this.DataContext = new LoginViewModel();
            this.ButtonBack.Visibility = Visibility.Collapsed;
        }
    }
}
