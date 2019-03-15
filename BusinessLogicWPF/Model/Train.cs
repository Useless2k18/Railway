// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Train.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the Train type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable StyleCop.SA1300
// ReSharper disable InconsistentNaming
namespace BusinessLogicWPF.Model
{
    using BusinessLogicWPF.Annotations;

    using Google.Cloud.Firestore;

    /// <summary>
    /// The train.
    /// </summary>
    [FirestoreData]
    public class Train
    {
        /// <summary>
        /// Gets or sets the train no.
        /// </summary>
        [CanBeNull]
        [FirestoreProperty]
        public int trainNo { get; set; }

        /// <summary>
        /// Gets or sets the train name.
        /// </summary>
        [CanBeNull]
        [FirestoreProperty]
        public string trainName { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        [CanBeNull]
        [FirestoreProperty]
        public string type { get; set; }

        /// <summary>
        /// Gets or sets the coach.
        /// </summary>
        [CanBeNull]
        [FirestoreProperty]
        public Coach coach { get; set; }

        /// <summary>
        /// Gets or sets the source station.
        /// </summary>
        [CanBeNull]
        [FirestoreProperty]
        public string sourceStation { get; set; }

        /// <summary>
        /// Gets or sets the destination station.
        /// </summary>
        [CanBeNull]
        [FirestoreProperty]
        public string destinationStation { get; set; }

        /// <summary>
        /// Gets or sets the rake zone.
        /// </summary>
        [CanBeNull]
        [FirestoreProperty]
        public string rakeZone { get; set; }

        /// <summary>
        /// Gets or sets the route.
        /// </summary>
        [CanBeNull]
        [FirestoreProperty]
        public Route[] route { get; set; }
    }
}
