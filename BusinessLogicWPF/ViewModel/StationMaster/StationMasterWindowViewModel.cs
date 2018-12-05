using BusinessLogicWPF.Domain;
using BusinessLogicWPF.View.StationMaster.UserControls;
using MaterialDesignThemes.Wpf;
using System;

namespace BusinessLogicWPF.ViewModel.StationMaster
{
    class StationMasterWindowViewModel
    {
        public DemoItem[] DemoItems { get; set; }

        public StationMasterWindowViewModel(ISnackbarMessageQueue snackBarMessageQueue)
        {
            if (snackBarMessageQueue == null) throw new ArgumentNullException(nameof(snackBarMessageQueue));

            DemoItems = new[]
            {
                new DemoItem("Home", new StationMasterHome()),
                new DemoItem("Allocate TTE", new AllocateTte {DataContext = new AllocateTteViewModel()}),
                new DemoItem("History", new History()),
            };
        }
    }
}
