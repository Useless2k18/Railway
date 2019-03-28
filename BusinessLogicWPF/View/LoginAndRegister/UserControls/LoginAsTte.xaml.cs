// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoginAsTte.xaml.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Interaction logic for LoginAsTte.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable StyleCop.SA1204
// ReSharper disable PrivateFieldCanBeConvertedToLocalVariable
namespace BusinessLogicWPF.View.LoginAndRegister.UserControls
{
    using System;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Threading;

    using BusinessLogicWPF.Properties;

    using Window = System.Windows.Window;

    /// <summary>
    /// Interaction logic for Login As TTE XAML
    /// </summary>
    public partial class LoginAsTte : UserControl
    {
        /// <summary>
        /// The regex.
        /// </summary>
        [NotNull]
        private static readonly Regex Regex = new Regex("[^0-9]+"); // regex that matches disallowed text

        /// <summary>
        /// The window.
        /// </summary>
        [NotNull]
        private readonly Window window;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginAsTte"/> class.
        /// </summary>
        public LoginAsTte()
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
        private void ButtonLoginClick([CanBeNull] object sender, [CanBeNull] RoutedEventArgs e)
        {
            if (this.TextUserName.Text.Length != 0 && this.TextPassword.Password.Length != 0 && this.TextOtp.Text.Length != 0)
            {
                MessageBox.Show("Logged in!");
            }
        }

        #region Input Fields

        /// <summary>
        /// The text user name lost keyboard focus.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private async void TextUserNameLostKeyboardFocus([NotNull] object sender, [NotNull] KeyboardFocusChangedEventArgs e)
        {
            if (sender == null)
            {
                throw new ArgumentNullException(nameof(sender));
            }

            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            if (this.TextUserName.Text.Length == 0)
            {
                return;
            }

            await Task.Factory.StartNew(() =>
                {
                    string text = null;

                    Application.Current.Dispatcher.Invoke(
                        DispatcherPriority.Normal,
                        (ThreadStart)delegate { text = this.TextUserName.Text; });

                    if (text == "sdc224")
                    {
                        MessageBox.Show($"Hi {text}");
                    }
                }).ConfigureAwait(false);
        }

        /// <summary>
        /// The is text allowed.
        /// </summary>
        /// <param name="text">
        /// The text.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private static bool IsTextAllowed([NotNull] string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            return !Regex.IsMatch(text);
        }

        /// <summary>
        /// The text OTP preview text input.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void TextOtpPreviewTextInput([NotNull] object sender, [NotNull] TextCompositionEventArgs e)
        {
            if (sender == null)
            {
                throw new ArgumentNullException(nameof(sender));
            }

            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            e.Handled = !IsTextAllowed(e.Text);
        }

        /// <summary>
        /// The text OTP on pasting.
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
        private void TextOtpOnPasting([NotNull] object sender, [NotNull] DataObjectPastingEventArgs e)
        {
            if (sender == null)
            {
                throw new ArgumentNullException(nameof(sender));
            }

            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                var text = (string)e.DataObject.GetData(typeof(string));
                if (!IsTextAllowed(text ?? throw new InvalidOperationException()))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }

        /// <summary>
        /// The text password on lost keyboard focus.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void TextPasswordOnLostKeyboardFocus([NotNull] object sender, [NotNull] KeyboardFocusChangedEventArgs e)
        {
            if (sender == null)
            {
                throw new ArgumentNullException(nameof(sender));
            }

            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }

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
