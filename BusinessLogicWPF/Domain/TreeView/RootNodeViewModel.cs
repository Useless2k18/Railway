// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RootNodeViewModel.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   The root node view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessLogicWPF.Domain.TreeView
{
    using System.Collections.Generic;

    /// <summary>
    /// The root node view model.
    /// </summary>
    public class RootNodeViewModel : NodeViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RootNodeViewModel"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="childNodes">
        /// The child nodes.
        /// </param>
        public RootNodeViewModel(string name, List<NodeViewModel> childNodes = null)
            : base(name, childNodes)
        {
        }
    }
}