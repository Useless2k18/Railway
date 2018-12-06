using BusinessLogicWPF.Domain;
using BusinessLogicWPF.View.StationMaster.UserControls.HelperForAllocation;
using BusinessLogicWPF.ViewModel.StationMaster;
using BusinessLogicWPF.ViewModel.StationMaster.ForHelper;
using MaterialDesignThemes.Wpf;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace BusinessLogicWPF.View.StationMaster.UserControls
{
    /// <summary>
    /// Interaction logic for AllocateTte.xaml
    /// </summary>
    public partial class AllocateTte : UserControl
    {
        private BackgroundWorker _backgroundWorker = new BackgroundWorker();

        public AllocateTte()
        {
            InitializeComponent();
            DataContext = new AllocateTteViewModel();
        }

        private async void ButtonAssign_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var item = (sender as FrameworkElement)?.DataContext;
                var index = ListView1.Items.IndexOf(item ?? throw new InvalidOperationException());
                var data = (SelectableViewModel)ListView1.Items[index];

                var dialog = new SelectionDialog { DataContext = new SelectTteViewModel(data) };

                var result = await DialogHost.Show(dialog, "RootDialog", ClosingEventHandler);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
        }
    }
}
