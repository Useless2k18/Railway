// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VisualTreeHelpers.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the VisualTreeHelpers type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessLogicWPF.Helper
{
    using System;
    using System.Windows;
    using System.Windows.Media;

    using BusinessLogicWPF.Annotations;

    /// <summary>
    /// The visual tree helpers.
    /// </summary>
    public static class VisualTreeHelpers
    {
        /// <summary>
        /// The get visual parent.
        /// </summary>
        /// <param name="childObject">
        /// The child object.
        /// </param>
        /// <typeparam name="T">
        /// T is entity
        /// </typeparam>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        [CanBeNull]
        public static T GetVisualParent<T>([NotNull] object childObject) where T : Visual
        {
            if (childObject == null)
            {
                throw new ArgumentNullException(nameof(childObject));
            }

            var child = childObject as DependencyObject;

            while (child != null && !(child is T))
            {
                child = VisualTreeHelper.GetParent(child);
            }

            return child as T;
        }
    }
}
