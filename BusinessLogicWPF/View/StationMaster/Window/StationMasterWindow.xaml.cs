using BusinessLogicWPF.ViewModel.StationMaster;
using MaterialDesignThemes.Wpf;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace BusinessLogicWPF.View.StationMaster.Window
{
    /// <summary>
    /// Interaction logic for StationMasterWindow.xaml
    /// </summary>
    public partial class StationMasterWindow : System.Windows.Window
    {
        public static Snackbar Snackbar;

        public StationMasterWindow()
        {
            InitializeComponent();

            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(2000);
            }).ContinueWith(t =>
            {
                //note you can use the message queue from any thread, but just for the demo here we 
                //need to get the message queue from the snack bar, so need to be on the dispatcher
                MainSnackbar.MessageQueue.Enqueue("Hello Station Master");
            }, TaskScheduler.FromCurrentSynchronizationContext());

            DataContext = new StationMasterWindowViewModel(MainSnackbar.MessageQueue);

            Snackbar = MainSnackbar;
        }

        private void UIElement_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //until we had a StaysOpen glag to Drawer, this will help with scroll bars
            var dependencyObject = Mouse.Captured as DependencyObject;
            while (dependencyObject != null)
            {
                if (dependencyObject is ScrollBar) return;
                dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
            }

            MenuToggleButton.IsChecked = false;
        }
    }
}
