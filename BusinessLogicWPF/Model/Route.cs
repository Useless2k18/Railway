// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Route.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   The route.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable StyleCop.SA1300
// ReSharper disable InconsistentNaming
namespace BusinessLogicWPF.Model
{
    using BusinessLogicWPF.Annotations;

    using Google.Cloud.Firestore;

    /// <summary>
    /// The route.
    /// </summary>
    [FirestoreData]
    public class Route
    {
        /// <summary>
        /// Gets or sets the arrival time.
        /// </summary>
        [CanBeNull]
        [FirestoreProperty]
        public string arrivalTime { get; set; }

        /// <summary>
        /// Gets or sets the departure time.
        /// </summary>
        [CanBeNull]
        [FirestoreProperty]
        public string departureTime { get; set; }

        /// <summary>
        /// Gets or sets the station code.
        /// </summary>
        [CanBeNull]
        [FirestoreProperty]
        public string stationCode { get; set; }

        /// <summary>
        /// Gets or sets the TTE assign flag.
        /// </summary>
        [CanBeNull]
        [FirestoreProperty]
        public int tteAssignFlag { get; set; }
    }
}