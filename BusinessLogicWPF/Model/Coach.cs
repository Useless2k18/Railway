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
    using BusinessLogicWPF.Annotations;

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
        [FirestoreProperty]
        public string[] chairCar { get; set; }

        /// <summary>
        /// Gets or sets the coach type.
        /// </summary>
        [CanBeNull]
        [FirestoreProperty]
        public string[] coachType { get; set; }

        /// <summary>
        /// Gets or sets the first tier ac.
        /// </summary>
        [CanBeNull]
        [FirestoreProperty]
        public string[] firstTierAc { get; set; }

        /// <summary>
        /// Gets or sets the second tier ac.
        /// </summary>
        [CanBeNull]
        [FirestoreProperty]
        public string[] secondTierAc { get; set; }

        /// <summary>
        /// Gets or sets the third tier ac.
        /// </summary>
        [CanBeNull]
        [FirestoreProperty]
        public string[] thirdTierAc { get; set; }

        /// <summary>
        /// Gets or sets the sleeper.
        /// </summary>
        [CanBeNull]
        [FirestoreProperty]
        public string[] sleeper { get; set; }

        /// <summary>
        /// Gets or sets the second sitting.
        /// </summary>
        [CanBeNull]
        [FirestoreProperty]
        public string[] secondSitting { get; set; }
    }
}