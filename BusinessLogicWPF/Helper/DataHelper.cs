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

    using BusinessLogicWPF.Model;
    using BusinessLogicWPF.Properties;

    /// <summary>
    /// The data helper.
    /// </summary>
    public static class DataHelper
    {
        /// <summary>
        /// The exit code.
        /// </summary>
        private static short exitCode = -1;
        
        /// <summary>
        /// The train.
        /// </summary>
        [CanBeNull]
        private static Train train;

        /// <summary>
        /// The station.
        /// </summary>
        [CanBeNull]
        private static Station station;

        /// <summary>
        /// The route.
        /// </summary>
        [CanBeNull]
        private static Route route;

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
        /// The selected coach.
        /// </summary>
        [CanBeNull]
        private static string selectedCoach;

        /// <summary>
        /// Gets or sets the exit code.
        /// </summary>
        public static short ExitCode
        {
            get => exitCode;
            set
            {
                if (exitCode.Equals(value))
                {
                    return;
                }

                exitCode = value;
            }
        }

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
        /// Gets or sets the station.
        /// </summary>
        [CanBeNull]
        public static Station Station
        {
            get => station;
            set
            {
                if (value == null || station == value)
                {
                    return;
                }

                station = value;
            }
        }

        /// <summary>
        /// Gets or sets the route.
        /// </summary>
        [CanBeNull]
        public static Route Route
        {
            get => route;
            set
            {
                if (value == null || route == value)
                {
                    return;
                }

                route = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether accept.
        /// </summary>
        public static bool Accept { get; set; }

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

        /// <summary>
        /// Gets or sets the selected coach.
        /// </summary>
        [CanBeNull]
        public static string SelectedCoach
        {
            get => selectedCoach;
            set
            {
                if (value != null && selectedCoach == value)
                {
                    return;
                }

                selectedCoach = value;
            }
        }

        /// <summary>
        /// Gets or sets the secret folder path.
        /// </summary>
        public static string SecretFolderPath { get; set; }

        /// <summary>
        /// Gets or sets the JSON folder path.
        /// </summary>
        public static string JsonFolderPath { get; set; }
    }
}
