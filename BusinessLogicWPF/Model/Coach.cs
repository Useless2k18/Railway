// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Coach.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the Coach type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

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
        [CanBeNull] [FirestoreProperty] public string ChairCar { get; set; }

        /// <summary>
        /// Gets or sets the first tier ac.
        /// </summary>
        [CanBeNull] [FirestoreProperty] public string FirstTierAc { get; set; }

        /// <summary>
        /// Gets or sets the second sitting.
        /// </summary>
        [CanBeNull] [FirestoreProperty] public string SecondSitting { get; set; }

        /// <summary>
        /// Gets or sets the second tier ac.
        /// </summary>
        [CanBeNull] [FirestoreProperty] public string SecondTierAc { get; set; }

        /// <summary>
        /// Gets or sets the sleeper.
        /// </summary>
        [CanBeNull] [FirestoreProperty] public string Sleeper { get; set; }

        /// <summary>
        /// Gets or sets the third tier ac.
        /// </summary>
        [CanBeNull] [FirestoreProperty] public string ThirdTierAc { get; set; }
    }
}