// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Register.xaml.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Interaction logic for Register.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable StyleCop.SA1204
namespace BusinessLogicWPF.View.LoginAndRegister.UserControls
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Navigation;

    using BusinessLogicWPF.Properties;
    using BusinessLogicWPF.ViewModel.LoginAndRegister;

    using Window = System.Windows.Window;

    /// <summary>
    /// Interaction logic for Register XAML
    /// </summary>
    public partial class Register : UserControl
    {
        /// <summary>
        /// The window.
        /// </summary>
        [CanBeNull]
        private readonly Window window;

        /// <summary>
        /// The empty flag.
        /// </summary>
        private int emptyFlag;

        /// <summary>
        /// Initializes a new instance of the <see cref="Register"/> class.
        /// </summary>
        public Register()
        {
            this.InitializeComponent();
            this.window = Application.Current.MainWindow;
        }

        /// <summary>
        /// The hyperlink on request navigate.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void HyperlinkOnRequestNavigate([NotNull] object sender, [NotNull] RequestNavigateEventArgs e)
        {
            if (sender == null)
            {
                throw new ArgumentNullException(nameof(sender));
            }

            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        /// <summary>
        /// The button next on click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ButtonNextOnClick([CanBeNull] object sender, [CanBeNull] RoutedEventArgs e)
        {
            this.emptyFlag = 0;

            if (string.IsNullOrWhiteSpace(this.TextEmailId.Text))
            {
                this.LabelEmailId.Visibility = Visibility.Visible;
                this.emptyFlag++;
            }
            else if (!IsValidEmail(this.TextEmailId.Text))
            {
                this.LabelEmailId.Content = "* Please enter valid Email ID";
                this.LabelEmailId.Visibility = Visibility.Visible;
                this.emptyFlag++;
            }

            if (string.IsNullOrWhiteSpace(this.TextFullName.Text))
            {
                this.LabelName.Visibility = Visibility.Visible;
                this.emptyFlag++;
            }
            else if (!this.TextFullName.Text.Contains(" "))
            {
                this.LabelName.Content = "* Please enter your full name";
                this.LabelName.Visibility = Visibility.Visible;
                this.emptyFlag++;
            }

            if (string.IsNullOrWhiteSpace(this.TextPassword.Password))
            {
                this.TextBlockPassword.Visibility = Visibility.Visible;
                this.LabelPassword.Visibility = Visibility.Visible;

                this.emptyFlag++;
            }
            else if (!IsValidPassword(this.TextPassword.Password))
            {
                this.TextBlockPassword.Visibility = Visibility.Visible;
                this.LabelPassword.Visibility = Visibility.Collapsed;
                this.PasswordInstructions.Opacity = 1.5;
                this.TextFullName.Opacity = 0.5;
                this.TextEmailId.Opacity = 0.5;
                this.emptyFlag++;
            }

            if (this.DateOfBirth.SelectedDate == null)
            {
                this.LabelDateOfBirth.Visibility = Visibility.Visible;
                this.emptyFlag++;
            }

            if (this.emptyFlag != 0)
            {
                return;
            }

            if (this.DateOfBirth.SelectedDate == null)
            {
                return;
            }

            this.PasswordInstructions.Opacity = 0.5;

            var age = GetAge(this.DateOfBirth.SelectedDate.Value);
            if (age < 18)
            {
                this.LabelDateOfBirth.Content = "Age should not be less than 18";
                this.LabelDateOfBirth.Visibility = Visibility.Visible;
                return;
            }

            // win is window
            var win = this.window;
            if (win != null)
            {
                win.DataContext = new PhoneAuthenticationViewModel();
            }
        }

        #region Input Fields

        /// <summary>
        /// The text box text changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void TextBoxTextChanged([CanBeNull] object sender, [CanBeNull] TextChangedEventArgs e)
        {
            if (!(sender is TextBox textBox))
            {
                return;
            }

            if (textBox.Name.Contains("Email"))
            {
                this.LabelEmailId.Visibility = Visibility.Collapsed;
            }

            if (textBox.Name.Contains("Name"))
            {
                this.LabelName.Visibility = Visibility.Collapsed;
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
        private void TextPasswordOnPasswordChanged([CanBeNull] object sender, [CanBeNull] RoutedEventArgs e)
        {
            this.LabelPassword.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// The date of birth on key down.
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
        private void DateOfBirthOnKeyDown([NotNull] object sender, [NotNull] KeyEventArgs e)
        {
            if (sender == null)
            {
                throw new ArgumentNullException(nameof(sender));
            }

            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            e.Handled = true;
        }

        /// <summary>
        /// The date of birth on selected date changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void DateOfBirthOnSelectedDateChanged([CanBeNull] object sender, [CanBeNull] SelectionChangedEventArgs e)
        {
            this.LabelDateOfBirth.Visibility = Visibility.Collapsed;
        }

        #endregion

        #region Utility Functions

        /// <summary>
        /// The get age.
        /// </summary>
        /// <param name="bornDate">
        /// The born date.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        private static int GetAge(DateTime bornDate)
        {
            var today = DateTime.Today;
            var age = today.Year - bornDate.Year;
            if (bornDate > today.AddYears(-age))
            {
                age--;
            }

            return age;
        }

        /// <summary>
        /// The is valid email.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private static bool IsValidEmail([NotNull] string email)
        {
            if (email == null)
            {
                throw new ArgumentNullException(nameof(email));
            }

            return new EmailAddressAttribute().IsValid(email);
        }

        /// <summary>
        /// The is letter.
        /// </summary>
        /// <param name="c">
        /// The c.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private static bool IsLetter(char c) => (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z');

        /// <summary>
        /// The is digit.
        /// </summary>
        /// <param name="c">
        /// The c.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private static bool IsDigit(char c) => c >= '0' && c <= '9';

        /// <summary>
        /// The is symbol.
        /// </summary>
        /// <param name="c">
        /// The c.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private static bool IsSymbol(char c) => c > 32 && c < 127 && !IsDigit(c) && !IsLetter(c);

        /// <summary>
        /// The is valid password.
        /// </summary>
        /// <param name="password">
        /// The password.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private static bool IsValidPassword([NotNull] string password)
        {
            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            return
                IsLetter(password.FirstOrDefault()) &&
                password.Any(IsLetter) &&
                password.Any(IsDigit) &&
                password.Any(IsSymbol) &&
                password.Length > 6;
        }

        #endregion
    }
}
