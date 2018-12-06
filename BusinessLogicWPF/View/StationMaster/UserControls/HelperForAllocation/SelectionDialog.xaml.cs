using BusinessLogicWPF.Helper;
using System.ComponentModel;
using System.Windows.Controls;

namespace BusinessLogicWPF.View.StationMaster.UserControls.HelperForAllocation
{
    /// <summary>
    /// Interaction logic for SelectionDialog.xaml
    /// </summary>
    public partial class SelectionDialog : UserControl
    {
        private BackgroundWorker _backgroundWorker = new BackgroundWorker();

        public SelectionDialog()
        : base()
        {
            InitializeComponent();

            _backgroundWorker.DoWork += _backgroundWorker_DoWork;
            _backgroundWorker.RunWorkerCompleted += _backgroundWorker_RunWorkerCompleted;
            _backgroundWorker.RunWorkerAsync();
        }

        private void _backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!DataHelper.StatusForEnable)
            {
            }
        }

        private void _backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ButtonAccept.IsEnabled = true;
        }
    }
}
