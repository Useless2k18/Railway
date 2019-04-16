// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Route.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   The route.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessLogicWPF.Model
{
    using BusinessLogicWPF.Properties;

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
        [FirestoreProperty("arrivalTime")]
        public string ArrivalTime { get; set; }

        /// <summary>
        /// Gets or sets the departure time.
        /// </summary>
        [CanBeNull]
        [FirestoreProperty("departureTime")]
        public string DepartureTime { get; set; }

        /// <summary>
        /// Gets or sets the station code.
        /// </summary>
        [CanBeNull]
        [FirestoreProperty("stationCode")]
        public string StationCode { get; set; }
    }
}