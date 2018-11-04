using BusinessLogicWPF.ViewModel;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace BusinessLogicWPF.View
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : UserControl
    {
        private int _emptyFlag;
        private readonly Window _window;

        public Register()
        {
            InitializeComponent();
            _window = Application.Current.MainWindow;
        }

        private void Hyperlink_OnRequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void ButtonNext_OnClick(object sender, RoutedEventArgs e)
        {
            _emptyFlag = 0;

            #region Handling Empty and Wrong Values

            if (string.IsNullOrWhiteSpace(TextEmailId.Text))
            {
                LabelEmailId.Visibility = Visibility.Visible;
                _emptyFlag++;
            }

            else if (!IsValidEmail(TextEmailId.Text))
            {
                LabelEmailId.Content = "* Please enter valid Email ID";
                LabelEmailId.Visibility = Visibility.Visible;
                _emptyFlag++;
            }

            if (string.IsNullOrWhiteSpace(TextFullName.Text))
            {
                LabelName.Visibility = Visibility.Visible;
                _emptyFlag++;
            }

            else if (!TextFullName.Text.Contains(" "))
            {
                LabelName.Content = "* Please enter your full name";
                LabelName.Visibility = Visibility.Visible;
                _emptyFlag++;
            }

            if (string.IsNullOrWhiteSpace(TextPassword.Password))
            {
                TextBlockPassword.Visibility = Visibility.Visible;
                LabelPassword.Visibility = Visibility.Visible;

                _emptyFlag++;
            }

            else if (!IsValidPassword(TextPassword.Password))
            {
                TextBlockPassword.Visibility = Visibility.Visible;
                LabelPassword.Visibility = Visibility.Collapsed;
                _emptyFlag++;
            }

            if (DateOfBirth.SelectedDate == null)
            {
                LabelDateOfBirth.Visibility = Visibility.Visible;
                _emptyFlag++;
            }

            if (!CheckBoxAcceptTerm.IsChecked.GetValueOrDefault())
            {
                LabelAcceptTerm.Visibility = Visibility.Visible;
                _emptyFlag++;
            }

            #endregion

            if (_emptyFlag != 0) return;

            if (DateOfBirth.SelectedDate == null) return;
            var age = GetAge(DateOfBirth.SelectedDate.Value);
            if (age < 18)
            {
                LabelDateOfBirth.Content = "Age should not be less than 18";
                LabelDateOfBirth.Visibility = Visibility.Visible;
                return;
            }

            _window.DataContext = new Register2ViewModel();
        }

        #region Input Fields

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!(sender is TextBox textBox))
                return;

            if (textBox.Name.Contains("Email"))
                LabelEmailId.Visibility = Visibility.Collapsed;

            if (textBox.Name.Contains("Name"))
                LabelName.Visibility = Visibility.Collapsed;
        }

        private void TextPassword_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            LabelPassword.Visibility = Visibility.Collapsed;
        }

        private void DateOfBirth_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void DateOfBirth_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            LabelDateOfBirth.Visibility = Visibility.Collapsed;
        }

        private void CheckBoxAcceptTerm_Checked(object sender, RoutedEventArgs e)
        {
            LabelAcceptTerm.Visibility = Visibility.Collapsed;
        }

        #endregion

        #region Utility Functions

        private static int GetAge(DateTime bornDate)
        {
            var today = DateTime.Today;
            var age = today.Year - bornDate.Year;
            if (bornDate > today.AddYears(-age))
                age--;

            return age;
        }

        private static bool IsValidEmail(string email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }

        private static bool IsLetter(char c)
        {
            return c >= 'a' && c <= 'z' || c >= 'A' && c <= 'Z';
        }

        private static bool IsDigit(char c)
        {
            return c >= '0' && c <= '9';
        }

        private static bool IsSymbol(char c)
        {
            return c > 32 && c < 127 && !IsDigit(c) && !IsLetter(c);
        }

        private static bool IsValidPassword(string password)
        {
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
