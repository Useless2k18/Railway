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
    using System.ComponentModel;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    using BusinessLogicWPF.Model;
    using BusinessLogicWPF.View.Admin.UserControls.ForHelpers;
    using BusinessLogicWPF.View.Helpers.UserControls;
    using BusinessLogicWPF.ViewModel.Admin;
    using BusinessLogicWPF.ViewModel.Admin.ForHelpers;

    using Helper;

    using MahApps.Metro.Controls;

    using MaterialDesignThemes.Wpf;

    using Properties;

    using MenuItem = Domain.TreeView.MenuItem;

    /// <summary>
    /// Interaction logic for AddTrains.XAML
    /// </summary>
    public partial class AddTrain : UserControl
    {
        /// <summary>
        /// The regex.
        /// </summary>
        [NotNull]
        private static readonly Regex Regex = new Regex("[^0-9]+"); // regex that matches disallowed text

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
        /// The root.
        /// </summary>
        [NotNull]
        private readonly MenuItem root;

        /// <summary>
        /// The source stations.
        /// </summary>
        private readonly List<string> sourceStations;

        /// <summary>
        /// The background worker.
        /// </summary>
        private BackgroundWorker backgroundWorker;

        /// <summary>
        /// The destination stations.
        /// </summary>
        private List<string> destinationStations = new List<string>();

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

            this.DataContext = new AddTrainViewModel();

            this.MainGrid.Visibility = Visibility.Visible;
            this.NavigateToRoute.Visibility = Visibility.Collapsed;

            // ComboBox Section
            if (DataHelper.StationsList != null)
            {
                this.sourceStations = DataHelper.StationsList.Stations.Keys.ToList();
            }

            this.ComboBoxTrainSource.ItemsSource = this.sourceStations;
            this.ComboBoxTrainDestination.ItemsSource = this.sourceStations;

            // TreeView Section
            this.root = new MenuItem { Name = "Coach" };
            
            // We should delete this part as here we are initializing the whole list for coaches
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
        /// The is text allowed.
        /// </summary>
        /// <param name="text">
        /// The text.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private static bool IsTextAllowed([NotNull] string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            return !Regex.IsMatch(text);
        }

        /// <summary>
        /// The text box train no on preview text input.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void TextBoxTrainNoOnPreviewTextInput(object sender, [NotNull] TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        /// <summary>
        /// The combo box train source on selection changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ComboBoxTrainSourceOnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.ComboBoxTrainDestination.SelectedIndex = -1;
            var combo1 = this.ComboBoxTrainSource.SelectedValue as string;
            this.destinationStations.Clear();
            this.destinationStations.AddRange(this.sourceStations);
            this.destinationStations.Remove(combo1);
            this.ComboBoxTrainDestination.ItemsSource = null;
            this.ComboBoxTrainDestination.ItemsSource = this.destinationStations;
            this.ComboBoxTrainDestination.IsEnabled = true;
        }

        /// <summary>
        /// The framework element on request bring into view.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void FrameworkElementOnRequestBringIntoView(
            [CanBeNull] object sender,
            [NotNull] RequestBringIntoViewEventArgs e)
        {
            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            // Allows the keyboard to bring the items into view as expected:
            if (Keyboard.IsKeyDown(Key.Down) || Keyboard.IsKeyDown(Key.Up))
            {
                return;
            }            

            e.Handled = true;  
        }

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

                    var result1 = await DialogHost.Show(dialog1, "RootDialog")
                                      .ConfigureAwait(false);

                    if ((bool)result1)
                    {
                        this.Dispatcher.Invoke(
                            () =>
                                {
                                    var coaches = this.root.Items ?? throw new InvalidOperationException();

                                    var item = new MenuItem { Name = DataHelper.SelectedCoach };

                                    if (!coaches.Contains(item))
                                    {
                                        coaches.Add(item);
                                    }

                                    this.TreeView.Items[0] = this.root;
                                });
                    }
                }
                else
                {
                    var o = this.list;
                    if (o?.Contains(this.currentSelectedItem) == true)
                    {
                        DataHelper.SelectedCoach = (this.list ?? throw new InvalidOperationException()).FirstOrDefault(
                            a => a.Contains(this.currentSelectedItem ?? throw new InvalidOperationException()));
                        var dialog2 = new SelectionDialog { DataContext = new EnterCoachesViewModel() };

                        var result2 = await DialogHost.Show(dialog2, "RootDialog")
                                          .ConfigureAwait(false);

                        if ((bool)result2)
                        {
                            this.Dispatcher.Invoke(
                                () =>
                                    {
                                        var coaches =
                                            (this.root.Items ?? throw new InvalidOperationException()).FirstOrDefault(
                                                c => c.Name == DataHelper.SelectedCoach);

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
        /// The button delete on click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ButtonDeleteOnClick(object sender, RoutedEventArgs e)
        {
            if (this.currentSelectedItem != "Coach")
            {
                if (!this.list.Contains(this.currentSelectedItem))
                {
                    foreach (var rootItem in this.root.Items)
                    {
                        var match = rootItem.Items.FirstOrDefault(r => r.Name == this.currentSelectedItem);

                        if (match != null)
                        {
                            rootItem.Items.Remove(match);
                            MessageBox.Show("Item Deleted!");
                            break;
                        }
                    }

                    this.TreeView.Items[0] = this.root;
                }
                else
                {
                    MessageBox.Show("You cannot delete a Coach Type!");
                }
            }
            else
            {
                MessageBox.Show("You cannot delete Coach");
            }
        }

        /// <summary>
        /// The button reset on click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ButtonResetOnClick(object sender, RoutedEventArgs e)
        {
            this.Refresh();
        }

        /// <summary>
        /// The button next on click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ButtonNextOnClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.TextBoxTrainNo.Text)
                || string.IsNullOrWhiteSpace(this.TextBoxTrainName.Text)
                || string.IsNullOrWhiteSpace(this.TextBoxTrainType.Text)
                || string.IsNullOrWhiteSpace(this.ComboBoxTrainSource.Text)
                || string.IsNullOrWhiteSpace(this.ComboBoxTrainDestination.Text)
                || string.IsNullOrWhiteSpace(this.TextBoxTrainRakeZone.Text))
            {
                MessageBox.Show("Please fill up all the fields!");
                return;
            }

            if (this.TextBoxTrainNo.Text.Length < 5)
            {
                MessageBox.Show("Train Number cannot be less than 5");
                return;
            }

            var c = (MenuItem)this.TreeView.Items[0];
            var count = 0;

            var coachType = new List<string>();
            var firstTierAc = new List<string>();
            var secondTierAc = new List<string>();
            var thirdTierAc = new List<string>();
            var sleeper = new List<string>();
            var chairCar = new List<string>();
            var secondSitting = new List<string>();

            foreach (var item in c.Items)
            {
                if (item.Items.Count != 0)
                {
                    switch (item.Name)
                    {
                        case "First Tier AC":
                            coachType.Add("firstTierAc");
                            foreach (var itemItem in item.Items)
                            {
                                firstTierAc.Add(itemItem.Name);
                            }

                            break;
                        case "Second Tier AC":
                            coachType.Add("secondTierAc");
                            foreach (var itemItem in item.Items)
                            {
                                secondTierAc.Add(itemItem.Name);
                            }

                            break;
                        case "Third Tier AC":
                            coachType.Add("thirdTierAc");
                            foreach (var itemItem in item.Items)
                            {
                                thirdTierAc.Add(itemItem.Name);
                            }

                            break;
                        case "Sleeper":
                            coachType.Add("sleeper");
                            foreach (var itemItem in item.Items)
                            {
                                sleeper.Add(itemItem.Name);
                            }

                            break;
                        case "Chair Car":
                            coachType.Add("chairCar");
                            foreach (var itemItem in item.Items)
                            {
                                chairCar.Add(itemItem.Name);
                            }

                            break;
                        case "Second Sitting":
                            coachType.Add("secondSitting");
                            foreach (var itemItem in item.Items)
                            {
                                secondSitting.Add(itemItem.Name);
                            }

                            break;
                        default:
                            break;
                    }

                    count++;
                }
                else
                {
                    switch (item.Name)
                    {
                        case "First Tier AC":
                            firstTierAc.Add("NA");
                            break;
                        case "Second Tier AC":
                            secondTierAc.Add("NA");
                            break;
                        case "Third Tier AC":
                            thirdTierAc.Add("NA");
                            break;
                        case "Sleeper":
                            sleeper.Add("NA");
                            break;
                        case "Chair Car":
                            chairCar.Add("NA");
                            break;
                        case "Second Sitting":
                            secondSitting.Add("NA");
                            break;
                        default:
                            break;
                    }
                }
            }

            if (count == 0)
            {
                MessageBox.Show("Please add at least one coach to this train!");
                return;
            }

            DataHelper.Train = new Train
                                   {
                                       TrainNumber = Convert.ToInt32(this.TextBoxTrainNo.Text),
                                       TrainName = this.TextBoxTrainName.Text,
                                       Type = this.TextBoxTrainType.Text,
                                       SourceStation = this.ComboBoxTrainSource.Text,
                                       DestinationStation = this.ComboBoxTrainDestination.Text,
                                       RakeZone = this.TextBoxTrainRakeZone.Text,
                                       Coach = new Coach
                                                   {
                                                       CoachType = coachType,
                                                       FirstTierAc = firstTierAc,
                                                       SecondTierAc = secondTierAc,
                                                       ThirdTierAc = thirdTierAc,
                                                       Sleeper = sleeper,
                                                       ChairCar = chairCar,
                                                       SecondSitting = secondSitting
                                                   }
                                   };

            this.MainGrid.Visibility = Visibility.Collapsed;
            this.NavigateToRoute.Content = new AddRouteOfTrain { DataContext = new AddRouteOfTrainViewModel() };
            this.NavigateToRoute.Visibility = Visibility.Visible;

            // Start background worker
            this.backgroundWorker = new BackgroundWorker();
            this.backgroundWorker.DoWork += this.BackgroundWorkerDoWork;
            this.backgroundWorker.RunWorkerCompleted += this.BackgroundWorkerRunWorkerCompleted;
            this.backgroundWorker.RunWorkerAsync();
        }

        /// <summary>
        /// The background worker do work.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void BackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            while (!DataHelper.Accept)
            {
            }
        }

        /// <summary>
        /// The background worker run worker completed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void BackgroundWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.MainGrid.Visibility = Visibility.Visible;
            this.NavigateToRoute.Visibility = Visibility.Collapsed;
            this.NavigateToRoute.Content = null;

            this.Refresh();
        }

        /// <summary>
        /// The refresh.
        /// </summary>
        private void Refresh()
        {
            foreach (var textBox in this.FindChildren<TextBox>())
            {
                textBox.Clear();
            }

            foreach (var comboBox in this.FindChildren<ComboBox>())
            {
                comboBox.SelectedIndex = -1;
            }

            this.ComboBoxTrainDestination.IsEnabled = false;

            var c = (MenuItem)this.TreeView.Items[0];

            foreach (var item in c.Items)
            {
                item.Items.Clear();
            }

            this.TreeView.Items[0] = c;

            ErrorLabelHelper.Reset();

            DataHelper.Train = null;
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
