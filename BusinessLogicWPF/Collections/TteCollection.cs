// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TteCollection.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the TteCollection type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessLogicWPF.Collections
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BusinessLogicWPF.Model;
    using BusinessLogicWPF.Properties;

    /// <summary>
    /// The TTE collection.
    /// </summary>
    public static class TteCollection
    {
        /// <summary>
        /// The choices.
        /// </summary>
        [CanBeNull]
        private static Dictionary<string, string> choices;

        /// <summary>
        /// The get choices.
        /// </summary>
        /// <param name="ttes">
        /// The TTEs.
        /// </param>
        /// <returns>
        /// The <see cref="Dictionary{TKey,TValue}"/>.
        /// </returns>
        [NotNull]
        public static Dictionary<string, string> GetChoices([NotNull] List<Tte> ttes)
        {
            if (ttes == null)
            {
                throw new ArgumentNullException(nameof(ttes));
            }

            choices = ttes.ToDictionary(t => t.TT_ID, t => string.Format(t.F_NAME + " " + t.L_NAME));

            return choices;
        }
    }
}
