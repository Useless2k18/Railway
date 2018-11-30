using BusinessLogicWPF.ViewModel.LoginAndRegister;
using MahApps.Metro.Controls;
using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BusinessLogicWPF.View.LoginAndRegister.Window
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class WindowLoginAndRegister : MetroWindow
    {
        private int _counter;

        public WindowLoginAndRegister()
        {
            InitializeComponent();
            Left = 100;
            Top = 10;
            SystemEvents.DisplaySettingsChanged += SystemEvents_DisplaySettingsChanged;
            DataContext = new LoginViewModel();
        }

        private void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
        {
            Left = SystemParameters.PrimaryScreenWidth - Width;
            Top = SystemParameters.PrimaryScreenHeight - Height;
        }

        private void ButtonNewUser_Click(object sender, RoutedEventArgs e)
        {
            if (_counter % 2 == 0)
            {
                ButtonNewUser.Content = "Already Registered?";
                DataContext = new RegisterViewModel();
                ButtonBack.Visibility = Visibility.Collapsed;
            }
            else
            {
                ButtonNewUser.Content = "New User?";
                DataContext = new LoginViewModel();
                ButtonBack.Visibility = Visibility.Collapsed;
            }
            _counter++;
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

        private void ButtonBack_OnClick(object sender, RoutedEventArgs e)
        {
            DataContext = new LoginViewModel();
            ButtonBack.Visibility = Visibility.Collapsed;
        }
    }
}
