using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace BusinessLogicWPF.View.LoginAndRegister.UserControls
{
    /// <summary>
    /// Interaction logic for LoginAsStationMaster.xaml
    /// </summary>
    public partial class LoginAsStationMaster : UserControl
    {
        private readonly System.Windows.Window _window;

        public LoginAsStationMaster()
        {
            InitializeComponent();
            _window = Application.Current.MainWindow;

            var buttonBack = (Button)_window?.FindName("ButtonBack");
            if (buttonBack != null) buttonBack.Visibility = Visibility.Visible;
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Logged in!");
        }

        #region Input Fields

        private async void TextUserName_LostKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
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

        private void TextPassword_LostKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
        {
            if (TextPassword.Password.Length != 0)
                MessageBox.Show($"You just entered {TextPassword.Password}");
        }

        #endregion

    }
}
