// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddTrain.xaml.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Interaction logic for AddTrains.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessLogicWPF.View.Admin.UserControls
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;

    using BusinessLogicWPF.Helper;
    using BusinessLogicWPF.Properties;
    using BusinessLogicWPF.View.Helpers.UserControls;
    using BusinessLogicWPF.ViewModel.Admin;
    using BusinessLogicWPF.ViewModel.Admin.ForHelpers;

    using MaterialDesignThemes.Wpf;

    using MenuItem = BusinessLogicWPF.Domain.TreeView.MenuItem;

    /// <summary>
    /// Interaction logic for AddTrains.XAML
    /// </summary>
    public partial class AddTrain : UserControl
    {
        /// <summary>
        /// The root.
        /// </summary>
        [NotNull]
        private readonly MenuItem root;

        /// <summary>
        /// The list.
        /// </summary>
        [CanBeNull]
        private readonly List<string> list = new List<string>
                                                 {
                                                     "First Tier AC",
                                                     "Second Tier AC",
                                                     "Third Tier AC",
                                                     "Sleeper",
                                                     "Chair Car",
                                                     "Second Sitting"
                                                 };

        /// <summary>
        /// The current selected item.
        /// </summary>
        [CanBeNull]
        private string currentSelectedItem = string.Empty;

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BusinessLogicWPF.View.Admin.UserControls.AddTrain" /> class.
        /// </summary>
        public AddTrain()
        {
            this.InitializeComponent();

            this.root = new MenuItem { Name = "Coach" };
            var enumerable = this.list;
            if (enumerable != null)
            {
                foreach (var item in enumerable)
                {
                    var observableCollection = this.root.Items;
                    observableCollection?.Add(new MenuItem { Name = item });
                }
            }

            this.TreeView.Items.Add(this.root);
        }

        /// <summary>
        /// The view model.
        /// </summary>
        [CanBeNull]
        public AddTrainViewModel ViewModel => this.DataContext as AddTrainViewModel;

        /// <summary>
        /// Trees View's Selected Item is read-only. Hence we can't bind it. There is a way to obtain a selected item.
        /// </summary>
        /// <param name="sender">
        /// The sender
        /// </param>
        /// <param name="e">
        /// The Routed Property Changed Event Args
        /// </param>
        private void TreeViewSelectedItemChanged([CanBeNull] object sender, [CanBeNull] RoutedPropertyChangedEventArgs<object> e)
        {
            if (this.ViewModel == null)
            {
                return;
            }

            if (e != null)
            {
                // this.ViewModel.SelectedItem = e.NewValue;
                this.currentSelectedItem = ((MenuItem)e.NewValue).Name;
            }
        }

        /// <summary>
        /// The button add on click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private async void ButtonAddOnClick([CanBeNull] object sender, [CanBeNull] RoutedEventArgs e)
        {
            try
            {
                if (string.Compare(this.currentSelectedItem, "Coach", StringComparison.Ordinal) == 0)
                {
                    var dialog1 = new SelectionDialog { DataContext = new SelectCoachCategoryViewModel() };

                    var result1 = await DialogHost.Show(dialog1, "RootDialog", this.ClosingEventHandler)
                                      .ConfigureAwait(false);
                }
                else
                {
                    var o = this.list;
                    if (o?.Contains(this.currentSelectedItem) == true)
                    {
                        DataHelper.SelectedCoach = (this.list ?? throw new InvalidOperationException()).FirstOrDefault(
                            a => a.Contains(this.currentSelectedItem ?? throw new InvalidOperationException()));
                        var dialog2 = new SelectionDialog { DataContext = new EnterCoachesViewModel() };

                        var result2 = await DialogHost.Show(dialog2, "RootDialog", this.ClosingEventHandler)
                                          .ConfigureAwait(false);

                        if ((bool)result2)
                        {
                            this.Dispatcher.Invoke(
                                () =>
                                    {
                                        var coaches = (this.root.Items ?? throw new InvalidOperationException()).FirstOrDefault(c => c.Name == DataHelper.SelectedCoach);

                                        if (DataHelper.CoachesList != null)
                                        {
                                            foreach (var coach in DataHelper.CoachesList)
                                            {
                                                coaches?.Items?.Add(new MenuItem { Name = coach });
                                            }
                                        }

                                        this.TreeView.Items[0] = this.root;
                                    });
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid request!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// The closing event handler.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="eventArgs">
        /// The event args.
        /// </param>
        private void ClosingEventHandler([CanBeNull] object sender, [CanBeNull] DialogClosingEventArgs eventArgs)
        {
        }

        /// <summary>
        /// The object invariant.
        /// </summary>
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.list.All(item => item != null));
        }
    }
}
