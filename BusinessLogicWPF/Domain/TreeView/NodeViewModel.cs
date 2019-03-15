// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NodeViewModel.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the NodeViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessLogicWPF.Domain.TreeView
{
    using System.Collections.Generic;
    using System.ComponentModel;

    using BusinessLogicWPF.Annotations;

    /// <summary>
    /// The node view model.
    /// </summary>
    public class NodeViewModel
    {
        /// <summary>
        /// The is expanded.
        /// </summary>
        private bool isExpanded;

        /// <summary>
        /// The is selected.
        /// </summary>
        private bool isSelected;

        /// <summary>
        /// Initializes a new instance of the <see cref="NodeViewModel"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        public NodeViewModel([CanBeNull] string name)
            : this(name, (List<NodeViewModel>)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NodeViewModel"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="childNodes">
        /// The child nodes.
        /// </param>
        public NodeViewModel([CanBeNull] string name, [CanBeNull] List<NodeViewModel> childNodes)
        {
            this.Name = name;
            this.ChildNodes = childNodes ?? new List<NodeViewModel>();
            this.isExpanded = true;
        }

        /// <summary>
        /// The property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets the name.
        /// </summary>
        [CanBeNull]
        public string Name { get; }

        /// <summary>
        /// Gets or sets the child nodes.
        /// </summary>
        [CanBeNull]
        public List<NodeViewModel> ChildNodes { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is expanded.
        /// </summary>
        public bool IsExpanded
        {
            get => this.isExpanded;
            set
            {
                if (this.isExpanded != value)
                {
                    this.isExpanded = value;
                    this.OnPropertyChanged("IsExpanded");
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether is selected.
        /// </summary>
        public bool IsSelected
        {
            get => this.isSelected;
            set
            {
                if (this.isSelected != value)
                {
                    this.isSelected = value;
                    this.OnPropertyChanged("IsSelected");
                }
            }
        }

        /// <summary>
        /// The on property changed.
        /// </summary>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        protected void OnPropertyChanged([CanBeNull] string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
