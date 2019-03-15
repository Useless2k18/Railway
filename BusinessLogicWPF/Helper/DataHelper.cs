// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataHelper.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the DataHelper type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessLogicWPF.Helper
{
    using System.Collections.Generic;

    using BusinessLogicWPF.Annotations;
    using BusinessLogicWPF.Model;

    /// <summary>
    /// The data helper.
    /// </summary>
    public static class DataHelper
    {
        /// <summary>
        /// The train.
        /// </summary>
        [CanBeNull]
        private static Train train;

        /// <summary>
        /// The status for enable.
        /// </summary>
        private static bool statusForEnable;

        /// <summary>
        /// The coaches list.
        /// </summary>
        [CanBeNull]
        private static List<string> coachesList;

        /// <summary>
        /// Gets or sets the train.
        /// </summary>
        [CanBeNull]
        public static Train Train
        {
            get => train;
            set
            {
                if (value == null || train == value)
                {
                    return;
                }

                train = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether status for enable.
        /// </summary>
        public static bool StatusForEnable
        {
            get => statusForEnable;
            set
            {
                if (statusForEnable.Equals(value))
                {
                    return;
                }

                statusForEnable = value;
            }
        }

        /// <summary>
        /// Gets or sets the coaches list.
        /// </summary>
        [CanBeNull]
        public static List<string> CoachesList
        {
            get => coachesList;
            set => coachesList = value;
        }
    }
}
