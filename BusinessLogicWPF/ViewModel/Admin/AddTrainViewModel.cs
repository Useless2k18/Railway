// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddTrainViewModel.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   The add train view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessLogicWPF.ViewModel.Admin
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;

    using BusinessLogicWPF.Annotations;
    using BusinessLogicWPF.Domain;
    using BusinessLogicWPF.Domain.TreeView;
    using BusinessLogicWPF.Helper;
    using BusinessLogicWPF.Model;
    using BusinessLogicWPF.ViewModel.Admin.ForHelpers;

    /// <inheritdoc />
    /// <summary>
    /// The add train view model.
    /// </summary>
    public class AddTrainViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The selected item.
        /// </summary>
        [CanBeNull]
        private object selectedItem;

        /// <summary>
        /// The coach categories.
        /// </summary>
        [CanBeNull]
        private readonly string[] coachCategories =
            {
                "First Tier AC", "Second Tier AC", "Third Tier AC", "Sleeper", "Chair Car", "Second Sitting"
            };

        /// <summary>
        /// Initializes a new instance of the <see cref="AddTrainViewModel"/> class.
        /// </summary>
        public AddTrainViewModel()
        {
            this.RootNodeViewModel = this.CreateData(this.coachCategories ?? throw new InvalidOperationException());
            this.RootNodeViewModelList = new List<NodeViewModel> { this.RootNodeViewModel };
        }

        /// <inheritdoc />
        /// <summary>
        /// The property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        public RootNodeViewModel RootNodeViewModel { get; }

        public List<NodeViewModel> RootNodeViewModelList { get; }

        [CanBeNull]
        public AnotherCommandImplementation AddCommand { get; }

        /// <summary>
        /// Gets the remove selected item command.
        /// </summary>
        [CanBeNull]
        public AnotherCommandImplementation RemoveSelectedItemCommand { get; }

        /// <summary>
        /// Gets or sets the selected item.
        /// </summary>
        [CanBeNull]
        public object SelectedItem
        {
            get => this.selectedItem;
            set => this.MutateVerbose(ref this.selectedItem, value, args => this.PropertyChanged?.Invoke(this, args));
        }

        public string RootNodeText => "Coach";
        
        #region Hard-coded app data that would be loaded from a data layer in a real app

        private const string _Level1Node1Name = "Chair Car";

        private const string _Level1Node2Name = "Second Sitting";

        private const string _Level1Node3Name = "First Tier AC";

        private const string _Level1Node4Name = "Second Tier AC";

        private const string _Level1Node5Name = "Third Tier AC";

        private const string _Level1Node6Name = "Sleeper";

        private const string _Level2Node5Name = "References";

        /// <summary>
        /// The create data.
        /// </summary>
        /// <param name="level1NodeNames">
        /// The level 1 node names.
        /// </param>
        /// <returns>
        /// The <see cref="RootNodeViewModel"/>.
        /// </returns>
        [NotNull]
        private RootNodeViewModel CreateData([NotNull] IEnumerable<string> level1NodeNames)
        {
            var level1NodeViewModelList = level1NodeNames
                .Select(level1NodeName => new Level1NodeViewModel(level1NodeName)).Cast<NodeViewModel>().ToList();

            foreach (var level1NodeViewModel in level1NodeViewModelList)
            {
                level1NodeViewModel.ChildNodes = this.CreateLevel2NodeViewModelList(level1NodeViewModel.Name);
            }

            return new RootNodeViewModel(this.RootNodeText, level1NodeViewModelList);
        }

        /// <summary>
        /// The add items to list.
        /// </summary>
        /// <param name="list">
        /// The list.
        /// </param>
        private void AddItemsToList([CanBeNull] ICollection<NodeViewModel> list)
        {
            if (DataHelper.CoachesList != null)
            {
                foreach (var coach in DataHelper.CoachesList)
                {
                    list?.Add(new Level2NodeViewModel(coach));
                }
            }
        }

        /// <summary>
        /// The create level 2 node view model list.
        /// </summary>
        /// <param name="level1NodeName">
        /// The level 1 node name.
        /// </param>
        /// <returns>
        /// The <see cref="List{T}"/>.
        /// </returns>
        [NotNull]
        private List<NodeViewModel> CreateLevel2NodeViewModelList([CanBeNull] string level1NodeName)
        {
            List<NodeViewModel> level2NodeViewModelList = new List<NodeViewModel>();
            if (DataHelper.CoachesList != null)
            {
                if (level1NodeName == _Level1Node1Name)
                {
                    this.AddItemsToList(level2NodeViewModelList);
                }
                else if (level1NodeName == _Level1Node2Name)
                {
                    this.AddItemsToList(level2NodeViewModelList);
                }
                else if (level1NodeName == _Level1Node3Name)
                {
                    this.AddItemsToList(level2NodeViewModelList);
                }
                else if (level1NodeName == _Level1Node4Name)
                {
                    this.AddItemsToList(level2NodeViewModelList);
                }
                else if (level1NodeName == _Level1Node5Name)
                {
                    this.AddItemsToList(level2NodeViewModelList);
                }
                else if (level1NodeName == _Level1Node6Name)
                {
                    this.AddItemsToList(level2NodeViewModelList);
                }
                else
                {
                    level2NodeViewModelList = new List<NodeViewModel>();
                }

                // level2NodeViewModelList = new List<NodeViewModel>();
                /*foreach (var level2NodeViewModel in level2NodeViewModelList)
                {
                    level2NodeViewModel.ChildNodes = this.CreateLevel3NodeViewModelList(level2NodeViewModel.Name);
                }*/
            }

            return level2NodeViewModelList;
        }

        /*private List<NodeViewModel> CreateLevel3NodeViewModelList(string level2NodeName)
        {
            List<NodeViewModel> level3NodeViewModelList;
            switch (level2NodeName)
            {
                case _Level2Node1Name:
                    level3NodeViewModelList =
                        new List<NodeViewModel>
                            {
                                new Level3NodeViewModel(
                                    "Applications = Code + Markup",
                                    "Charles Petzold"),
                                new Level3NodeViewModel(
                                    "Concurrency in C# Cookbook",
                                    "Stephen Cleary"),
                                new Level3NodeViewModel(
                                    "The C# Player's Guide",
                                    "RB Whitaker"),
                            };
                    break;
                case _Level2Node2Name:
                    level3NodeViewModelList =
                        new List<NodeViewModel>
                            {
                                new Level3NodeViewModel(
                                    "LINQ in Action",
                                    "Fabrice Marguerie"),
                                new Level3NodeViewModel(
                                    "Programming Entity Framework",
                                    "Julia Lerman"),
                            };
                    break;
                case _Level2Node3Name:
                    level3NodeViewModelList =
                        new List<NodeViewModel>
                            {
                                new Level3NodeViewModel(
                                    "Creating Mobile Apps with Xamarin.Forms",
                                    "Charles Petzold"),
                                new Level3NodeViewModel(
                                    "Mastering Xamarin.Forms",
                                    "Ed Snider"),
                            };
                    break;
                case _Level2Node4Name:
                    level3NodeViewModelList =
                        new List<NodeViewModel>
                            {
                                new Level3NodeViewModel(
                                    "The Clean Coder",
                                    "Robert C. Martin"),
                                new Level3NodeViewModel(
                                    "Refactoring: Improving the Design of Existing Code",
                                    "Martin Fowler"),
                            };
                    break;
                case _Level2Node5Name:
                    level3NodeViewModelList =
                        new List<NodeViewModel>
                            {
                                new Level3NodeViewModel(
                                    "Framework Design Guidelines",
                                    "Krzysztof Cwalina and Brad Abrams"),
                            };
                    break;
                default:
                    level3NodeViewModelList = new List<NodeViewModel>();
                    break;
            }

            return level3NodeViewModelList;
        }*/

        #endregion     
    }
}
