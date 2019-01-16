// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoginAsStationMaster.xaml.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Interaction logic for LoginAsStationMaster.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable PrivateFieldCanBeConvertedToLocalVariable
namespace BusinessLogicWPF.View.LoginAndRegister.UserControls
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Threading;

    using BusinessLogicWPF.Annotations;

    using Window = System.Windows.Window;

    /// <summary>
    /// Interaction logic for Login As Station Master XAML
    /// </summary>
    public partial class LoginAsStationMaster : UserControl
    {
        /// <summary>
        /// The window.
        /// </summary>
        [NotNull]
        private readonly Window window;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginAsStationMaster"/> class.
        /// </summary>
        public LoginAsStationMaster()
        {
            this.InitializeComponent();
            this.window = Application.Current.MainWindow ?? throw new InvalidOperationException();

            var buttonBack = (Button)this.window?.FindName("ButtonBack");
            if (buttonBack != null)
            {
                buttonBack.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// The button login click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ButtonLoginClick([NotNull] object sender, [NotNull] RoutedEventArgs e)
        {
            if (sender == null)
            {
                throw new ArgumentNullException(nameof(sender));
            }

            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            // Code waiting for DbContext

            /*if (_stationMasterDetails.Password == TextPassword.Password)
            {
                var window = new StationMasterWindow();
                _window.Hide();
                window.ShowDialog();
                _window.Show();
            }
            else
                MessageBox.Show("Invalid Password");*/
        }

        #region Input Fields

        private void TextUserName_OnPasswordChanged(object sender, TextChangedEventArgs e)
        {
            this.UsernameAlert.Visibility = Visibility.Hidden;
        }

        private async void TextUserName_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (this.TextUserName.Text.Length == 0) return;

            await Task.Factory.StartNew(() =>
            {
                string text = null;

                Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal,
                    (ThreadStart)delegate { text = this.TextUserName.Text; });

                /*var context = new RailwayDbContext();

                _stationMasterDetails = context.StationMasters
                    .FirstOrDefault(a => a.Id == text);

                if (_stationMasterDetails != null)
                {
                    Dispatcher.BeginInvoke(
                        DispatcherPriority.Normal,
                        new Action(() =>
                        {
                            UsernameAlert.Kind = PackIconKind.SmileyCool;
                            UsernameAlert.Foreground = new SolidColorBrush(Colors.Green);
                            UsernameAlert.ToolTip = "Hello " + _stationMasterDetails.FullName;
                            UsernameAlert.Visibility = Visibility.Visible;
                            ButtonLogin.IsEnabled = true;
                        }));
                }
                else
                {
                    Dispatcher.BeginInvoke(
                        DispatcherPriority.Normal,
                        new Action(() =>
                        {
                            UsernameAlert.Kind = PackIconKind.SmileySad;
                            UsernameAlert.Foreground = new SolidColorBrush(Colors.OrangeRed);
                            UsernameAlert.ToolTip = "Sorry, Username not available";
                            UsernameAlert.Visibility = Visibility.Visible;
                            ButtonLogin.IsEnabled = false;
                        }));
                }*/
            });
        }

        private void TextPassword_OnLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (this.TextPassword.Password.Length == 0)
            {
                this.LabelPasswordEmptyError.Foreground = new SolidColorBrush(Colors.OrangeRed);
                this.LabelPasswordEmptyError.Visibility = Visibility.Visible;
                this.TextPassword.BorderBrush = new SolidColorBrush(Colors.OrangeRed);
            }
            else
            {
                this.LabelPasswordEmptyError.Visibility = Visibility.Hidden;
                this.TextPassword.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#89000000");
            }
        }

        /// <summary>
        /// The text password on password changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void TextPasswordOnPasswordChanged([NotNull] object sender, [NotNull] RoutedEventArgs e)
        {
            if (sender == null)
            {
                throw new ArgumentNullException(nameof(sender));
            }

            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            if (this.TextPassword.Password.Length != 0)
            {
                this.LabelPasswordEmptyError.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// The text password on preview mouse move.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// thrown if Argument Null Exception
        /// </exception>
        private void TextPasswordOnPreviewMouseMove([NotNull] object sender, [NotNull] MouseEventArgs e)
        {
            if (sender == null)
            {
                throw new ArgumentNullException(nameof(sender));
            }

            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            if (this.LabelPasswordEmptyError.Visibility == Visibility.Hidden)
            {
                this.TextPassword.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF673AB7");
            }
        }

        /// <summary>
        /// The text password on mouse leave.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// thrown if Argument Null Exception
        /// </exception>
        private void TextPasswordOnMouseLeave([NotNull] object sender, [NotNull] MouseEventArgs e)
        {
            if (sender == null)
            {
                throw new ArgumentNullException(nameof(sender));
            }

            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            if (this.LabelPasswordEmptyError.Visibility == Visibility.Hidden)
            {
                this.TextPassword.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#89000000");
            }
        }

        #endregion
    }
}
