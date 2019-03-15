// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Level3NodeViewModel.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the Level3NodeViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessLogicWPF.Domain.TreeView
{
    using System.Collections.Generic;

    using BusinessLogicWPF.Annotations;

    /// <inheritdoc />
    /// <summary>
    /// The level 3 node view model.
    /// </summary>
    public class Level3NodeViewModel : NodeViewModel
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BusinessLogicWPF.Domain.TreeView.Level3NodeViewModel" /> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="author">
        /// The author.
        /// </param>
        /// <param name="childNodes">
        /// The child nodes.
        /// </param>
        public Level3NodeViewModel(
            [CanBeNull] string name,
            [CanBeNull] string author,
            [CanBeNull] List<NodeViewModel> childNodes = null)
            : base(name, childNodes)
        {
            this.Author = author;
        }

        /// <summary>
        /// Gets the author.
        /// </summary>
        [CanBeNull]
        public string Author { get; }
    }
}