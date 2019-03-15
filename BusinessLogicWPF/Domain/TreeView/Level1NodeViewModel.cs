// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Level1NodeViewModel.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the Level1NodeViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessLogicWPF.Domain.TreeView
{
    using System.Collections.Generic;

    using BusinessLogicWPF.Annotations;

    /// <summary>
    /// The level 1 node view model.
    /// </summary>
    public class Level1NodeViewModel : NodeViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Level1NodeViewModel"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="childNodes">
        /// The child nodes.
        /// </param>
        public Level1NodeViewModel([CanBeNull] string name, [CanBeNull] List<NodeViewModel> childNodes = null)
            : base(name, childNodes)
        {
        }
    }
}