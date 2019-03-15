// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Level2NodeViewModel.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the Level2NodeViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessLogicWPF.Domain.TreeView
{
    using System.Collections.Generic;

    using BusinessLogicWPF.Annotations;

    /// <inheritdoc />
    /// <summary>
    /// The level 2 node view model.
    /// </summary>
    public class Level2NodeViewModel : NodeViewModel
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BusinessLogicWPF.Domain.TreeView.Level2NodeViewModel" /> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="childNodes">
        /// The child nodes.
        /// </param>
        public Level2NodeViewModel([CanBeNull] string name, [CanBeNull] List<NodeViewModel> childNodes = null)
            : base(name, childNodes)
        {
        }
    }
}