using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace BusinessLogicWPF.Helper
{
    /// <summary>
    /// Interaction logic for IndeterminateProgressDialog.xaml
    /// </summary>
    public partial class IndeterminateProgressDialog : UserControl
    {
        private static BackgroundWorker _backgroundWorker = new BackgroundWorker();

        public IndeterminateProgressDialog()
        {
            InitializeComponent();
            ButtonOk.IsEnabled = false;
        }

        private void _backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal,
                new Action(() => { ProgressBar.Visibility = Visibility.Visible; }));
        }

        private void _backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ProgressBar.Visibility = Visibility.Collapsed;
            ButtonOk.IsEnabled = true;
        }
    }
}
