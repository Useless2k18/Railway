using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BusinessLogicWPF.ViewModel.LoginAndRegister;

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

        }

        private void ButtonLoginAsStationMaster_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonLoginAsTte_Click(object sender, RoutedEventArgs e)
        {
            _window.DataContext = new LoginAsTteViewModel();
        }
    }
}
