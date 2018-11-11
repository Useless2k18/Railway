using BusinessLogicWPF.ViewModel.LoginAndRegister;
using System.Windows;
using System.Windows.Controls;

namespace BusinessLogicWPF.View.LoginAndRegister.UserControls
{
    /// <summary>
    /// Interaction logic for LoginSelection.xaml
    /// </summary>
    public partial class LoginSelection : UserControl
    {
        private readonly System.Windows.Window _window;

        public LoginSelection()
        {
            InitializeComponent();
            _window = Application.Current.MainWindow;
        }

        private void ButtonLoginAsAdmin_Click(object sender, RoutedEventArgs e)
        {
            _window.DataContext = new LoginAsAdminViewModel();
        }

        private void ButtonLoginAsStationMaster_Click(object sender, RoutedEventArgs e)
        {
            _window.DataContext = new LoginAsStationMasterViewModel();
        }

        private void ButtonLoginAsTte_Click(object sender, RoutedEventArgs e)
        {
            _window.DataContext = new LoginAsTteViewModel();
        }
    }
}
