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
        public string[] ChairCar { get; set; }

        /// <summary>
        /// Gets or sets the coach type.
        /// </summary>
        [CanBeNull]
        [FirestoreProperty("coachType")]
        public string[] CoachType { get; set; }

        /// <summary>
        /// Gets or sets the first tier ac.
        /// </summary>
        [CanBeNull]
        [FirestoreProperty("firstTierAc")]
        public string[] FirstTierAc { get; set; }

        /// <summary>
        /// Gets or sets the second tier ac.
        /// </summary>
        [CanBeNull]
        [FirestoreProperty("secondTierAc")]
        public string[] SecondTierAc { get; set; }

        /// <summary>
        /// Gets or sets the third tier ac.
        /// </summary>
        [CanBeNull]
        [FirestoreProperty("thirdTierAc")]
        public string[] ThirdTierAc { get; set; }

        /// <summary>
        /// Gets or sets the sleeper.
        /// </summary>
        [CanBeNull]
        [FirestoreProperty("sleeper")]
        public string[] Sleeper { get; set; }

        /// <summary>
        /// Gets or sets the second sitting.
        /// </summary>
        [CanBeNull]
        [FirestoreProperty("secondSitting")]
        public string[] SecondSitting { get; set; }
    }
}