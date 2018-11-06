using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace BusinessLogicWPF.View
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        public Login()
        {
            InitializeComponent();
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Logged in!");
        }

        #region Input Fields

        private async void TextUserName_LostKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
        {
            if (TextUserName.Text.Length == 0) return;

            await Task.Factory.StartNew((() =>
            {
                string text = null;

                Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal,
                    (ThreadStart)delegate { text = TextUserName.Text; });


                if (text == "sdc224")
                    MessageBox.Show($"Hi {text}");
            }));
        }

        private void TextPassword_LostKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
        {
            if (TextPassword.Password.Length != 0)
                MessageBox.Show($"You just entered {TextPassword.Password}");
        }

        private static readonly Regex Regex = new Regex("[^0-9]+"); //regex that matches disallowed text
        private static bool IsTextAllowed(string text)
        {
            return !Regex.IsMatch(text);
        }

        private void TextOtp_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
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

        #endregion
    }
}
