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

        private void DockPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ButtonAlreadyRegistered_Click(object sender, RoutedEventArgs e)
        {
            ButtonAlreadyRegistered.Visibility = Visibility.Collapsed;
            DataContext = new LoginViewModel();
            ButtonNewUser.Visibility = Visibility.Visible;
        }

        private void ButtonNewUser_Click(object sender, RoutedEventArgs e)
        {
            ButtonNewUser.Visibility = Visibility.Collapsed;
            DataContext = new RegisterViewModel();
            ButtonAlreadyRegistered.Visibility = Visibility.Visible;
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
    }
}
