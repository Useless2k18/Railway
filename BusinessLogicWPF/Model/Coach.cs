// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Coach.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the Coach type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable InconsistentNaming
// ReSharper disable StyleCop.SA1300
namespace BusinessLogicWPF.Model
{
    using System.Collections.Generic;

    using BusinessLogicWPF.Properties;

    using Google.Cloud.Firestore;

    /// <summary>
    /// The coach.
    /// </summary>
    [FirestoreData]
    public class Coach
    {
        /// <summary>
        /// Gets or sets the chair car.
        /// </summary>
        [CanBeNull]
        [FirestoreProperty("chairCar")]
        public List<string> ChairCar { get; set; }

        /// <summary>
        /// Gets or sets the coach type.
        /// </summary>
        [CanBeNull]
        [FirestoreProperty("coachType")]
        public List<string> CoachType { get; set; }

        /// <summary>
        /// Gets or sets the first tier ac.
        /// </summary>
        [CanBeNull]
        [FirestoreProperty("firstTierAc")]
        public List<string> FirstTierAc { get; set; }

        /// <summary>
        /// Gets or sets the second tier ac.
        /// </summary>
        [CanBeNull]
        [FirestoreProperty("secondTierAc")]
        public List<string> SecondTierAc { get; set; }

        /// <summary>
        /// Gets or sets the third tier ac.
        /// </summary>
        [CanBeNull]
        [FirestoreProperty("thirdTierAc")]
        public List<string> ThirdTierAc { get; set; }

        /// <summary>
        /// Gets or sets the sleeper.
        /// </summary>
        [CanBeNull]
        [FirestoreProperty("sleeper")]
        public List<string> Sleeper { get; set; }

        /// <summary>
        /// Gets or sets the second sitting.
        /// </summary>
        [CanBeNull]
        [FirestoreProperty("secondSitting")]
        public List<string> SecondSitting { get; set; }
    }
}