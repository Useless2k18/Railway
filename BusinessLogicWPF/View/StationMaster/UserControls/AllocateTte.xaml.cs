using BusinessLogicWPF.ViewModel.StationMaster;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using BusinessLogicWPF.Model;
using BusinessLogicWPF.View.StationMaster.UserControls.HelperForAllocation;
using BusinessLogicWPF.ViewModel.StationMaster.ForHelper;
using MaterialDesignThemes.Wpf;

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

                var dialog = new SelectionDialog(index) {DataContext = new SelectionDialogViewModel()};

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
