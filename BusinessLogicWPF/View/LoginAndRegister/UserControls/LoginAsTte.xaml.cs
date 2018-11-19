using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace BusinessLogicWPF.View.LoginAndRegister.UserControls
{
    /// <summary>
    /// Interaction logic for LoginAsTte.xaml
    /// </summary>
    public partial class LoginAsTte : UserControl
    {
        private readonly System.Windows.Window _window;

        public LoginAsTte()
        {
            InitializeComponent();
            _window = Application.Current.MainWindow;

            var buttonBack = (Button)_window?.FindName("ButtonBack");
            if (buttonBack != null) buttonBack.Visibility = Visibility.Visible;
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            if (TextUserName.Text.Length != 0 && TextPassword.Password.Length != 0 && TextOtp.Text.Length != 0)
            {
                MessageBox.Show("Logged in!");
            }
        }

        #region Input Fields

        private async void TextUserName_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (TextUserName.Text.Length == 0) return;

            await Task.Factory.StartNew(() =>
            {
                string text = null;

                Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal,
                    (ThreadStart)delegate { text = TextUserName.Text; });


                if (text == "sdc224")
                    MessageBox.Show($"Hi {text}");
            });
        }

        private static readonly Regex Regex = new Regex("[^0-9]+"); //regex that matches disallowed text
        private static bool IsTextAllowed(string text)
        {
            return !Regex.IsMatch(text);
        }

        private void TextOtp_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private void TextOtp_OnPasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                var text = (string)e.DataObject.GetData(typeof(string));
                if (!IsTextAllowed(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }

        private void TextPassword_OnLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (TextPassword.Password.Length == 0)
            {
                LabelPasswordEmptyError.Foreground = new SolidColorBrush(Colors.OrangeRed);
                LabelPasswordEmptyError.Visibility = Visibility.Visible;
                TextPassword.BorderBrush = new SolidColorBrush(Colors.OrangeRed);
            }
            else
            {
                LabelPasswordEmptyError.Visibility = Visibility.Hidden;
                TextPassword.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#89000000");
            }
        }

        private void TextPassword_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (TextPassword.Password.Length != 0)
            {
                LabelPasswordEmptyError.Visibility = Visibility.Hidden;
            }
        }

        private void TextPassword_OnPreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (LabelPasswordEmptyError.Visibility == Visibility.Hidden)
                TextPassword.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF673AB7");
        }

        private void TextPassword_OnMouseLeave(object sender, MouseEventArgs e)
        {
            if (LabelPasswordEmptyError.Visibility == Visibility.Hidden)
                TextPassword.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#89000000");
        }

        #endregion
    }
}
