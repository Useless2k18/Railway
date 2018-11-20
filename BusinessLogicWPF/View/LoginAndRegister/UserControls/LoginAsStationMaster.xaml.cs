using BusinessLogicWPF.Model;
using MaterialDesignThemes.Wpf;
using System;
using System.Linq;
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
    /// Interaction logic for LoginAsStationMaster.xaml
    /// </summary>
    public partial class LoginAsStationMaster : UserControl
    {
        private readonly System.Windows.Window _window;
        private Visibility _visibility;

        public LoginAsStationMaster()
        {
            InitializeComponent();
            _window = Application.Current.MainWindow;

            _visibility = UsernameAlert.Visibility;

            var buttonBack = (Button)_window?.FindName("ButtonBack");
            if (buttonBack != null) buttonBack.Visibility = Visibility.Visible;
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Logged in!");
        }

        #region Input Fields

        private void TextUserName_OnPasswordChanged(object sender, TextChangedEventArgs e)
        {
            UsernameAlert.Visibility = Visibility.Hidden;
        }

        private async void TextUserName_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (TextUserName.Text.Length == 0) return;

            await Task.Factory.StartNew(() =>
            {
                string text = null;

                Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal,
                    (ThreadStart)delegate { text = TextUserName.Text; });

                //Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal,
                //(ThreadStart)delegate { visibility = _visibility; });

                var context = new RailwayEntities();

                var name = context.StationMasters
                    .SingleOrDefault(a => a.Id == text);

                if (name != null)
                {
                    Dispatcher.BeginInvoke(
                        DispatcherPriority.Normal,
                        new Action((() =>
                        {
                            UsernameAlert.Kind = PackIconKind.SmileyCool;
                            UsernameAlert.Foreground = new SolidColorBrush(Colors.Green);
                            UsernameAlert.ToolTip = "Hello " + name.FullName;
                            UsernameAlert.Visibility = Visibility.Visible;
                        })));
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
                        }));
                }
            });
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
