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
    using System.Collections.Generic;
    using System.ComponentModel;

    using BusinessLogicWPF.Annotations;
    using BusinessLogicWPF.Domain;
    using BusinessLogicWPF.Domain.TreeView;

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
        /// Initializes a new instance of the <see cref="AddTrainViewModel"/> class.
        /// </summary>
        public AddTrainViewModel()
        {
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
    }
}
