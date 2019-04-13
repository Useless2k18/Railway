// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LinqExtensions.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the LinqExtensions type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessLogicWPF.ExtensionMethods
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The LINQ extensions.
    /// </summary>
    public static class LinqExtensions
    {
        /// <summary>
        /// The distinct by.
        /// </summary>
        /// <param name="items">
        /// The items.
        /// </param>
        /// <param name="property">
        /// The property.
        /// </param>
        /// <typeparam name="T">
        /// The T
        /// </typeparam>
        /// <typeparam name="TKey">
        /// The YKey
        /// </typeparam>
        /// <returns>
        /// The <see cref="IEnumerable{T}"/>.
        /// </returns>
        public static IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> items, Func<T, TKey> property)
        {
            var comparer = new GeneralPropertyComparer<T, TKey>(property);
            return items.Distinct(comparer);
        }   
    }
}
