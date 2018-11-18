using BusinessLogicWPF.ViewModel.LoginAndRegister;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace BusinessLogicWPF.View.LoginAndRegister.UserControls
{
    /// <summary>
    /// Interaction logic for LoginAsAdmin.xaml
    /// </summary>
    public partial class LoginAsAdmin : UserControl
    {
        private readonly System.Windows.Window _window;

        public LoginAsAdmin()
        {
            InitializeComponent();
            _window = Application.Current.MainWindow;
        }

        private void ButtonBack_OnClick(object sender, RoutedEventArgs e)
        {
            _window.DataContext = new LoginViewModel();
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Logged in!");
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

        private void TextPassword_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (TextPassword.Password.Length != 0)
                MessageBox.Show($"You just entered {TextPassword.Password}");
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

        /*private void TextOtp_KeyUp(object sender, KeyEventArgs e)
        {
            MoveToNextUiElement(e);
        }

        private void TextOtp1_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (!e.Handled)
                e.Handled = true;
        }
        */

        private static void MoveToNextUiElement(RoutedEventArgs e)
        {
            // Creating a FocusNavigationDirection object and setting it to a
            // local field that contains the direction selected.
            const FocusNavigationDirection focusDirection = FocusNavigationDirection.Next;

            // MoveFocus takes a TraversalRequest as its argument.
            var request = new TraversalRequest(focusDirection);

            // Gets the element with keyboard focus.

            // Change keyboard focus.
            if (!(Keyboard.FocusedElement is UIElement elementWithFocus)) return;

            if (elementWithFocus.MoveFocus(request)) e.Handled = true;
        }

        #endregion
    }
}
