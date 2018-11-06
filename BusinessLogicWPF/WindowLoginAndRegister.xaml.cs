using BusinessLogicWPF.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BusinessLogicWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();
            //GridLoginFields.Children.Clear();
            //GridLoginFields.Children.Add(_loginControl);
            //GridLoginFields.Height = _loginControl.Height;
            ButtonNewUser.Visibility = Visibility.Visible;
            CenterWindowOnScreen();
        }

        private void CommandBinding_CanExecute_1(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed_1(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.CloseWindow(this);
        }

        private void CommandBinding_Executed_2(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.MinimizeWindow(this);
        }

        private void WindowLogin_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ButtonAlreadyRegistered_Click(object sender, RoutedEventArgs e)
        {
            ButtonAlreadyRegistered.Visibility = Visibility.Collapsed;
            DataContext = new LoginViewModel();
            ButtonNewUser.Visibility = Visibility.Visible;
            CenterWindowOnScreen();
        }

        private void ButtonNewUser_Click(object sender, RoutedEventArgs e)
        {
            ButtonNewUser.Visibility = Visibility.Collapsed;
            DataContext = new RegisterViewModel();
            ButtonAlreadyRegistered.Visibility = Visibility.Visible;
            CenterWindowOnScreen();
        }

        private void ButtonLikeLabel_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Button button)
            {
                button.FontWeight = FontWeights.Bold;
            }
        }

        private void ButtonLikeLabel_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Button button)
            {
                button.FontWeight = FontWeights.Normal;
            }
        }

        public void CenterWindowOnScreen()
        {
            var screenWidth = SystemParameters.PrimaryScreenWidth;
            var screenHeight = SystemParameters.PrimaryScreenHeight;
            var windowWidth = Width;
            var windowHeight = Height;
            Left = screenWidth / 2 - windowWidth / 2;
            Top = screenHeight / 2 - windowHeight / 2;
        }
    }
}
