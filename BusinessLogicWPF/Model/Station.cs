// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Station.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the Station type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessLogicWPF.Model
{
    using BusinessLogicWPF.Properties;

    using Google.Cloud.Firestore;

    /// <summary>
    /// The station.
    /// </summary>
    [FirestoreData]
    public class Station
    {
        /// <summary>
        /// Gets or sets the zone.
        /// </summary>
        [CanBeNull]
        [FirestoreProperty("zone")]
        public string Zone { get; set; }
        
        /// <summary>
        /// Gets or sets the railway division.
        /// </summary>
        [CanBeNull]
        [FirestoreProperty("railwayDivision")]
        public string RailwayDivision { get; set; }

        /// <summary>
        /// Gets or sets the station code.
        /// </summary>
        [CanBeNull]
        [FirestoreProperty("stationCode")]
        public string StationCode { get; set; }

        /// <summary>
        /// Gets or sets the station name.
        /// </summary>
        [CanBeNull]
        [FirestoreProperty("stationName")]
        public string StationName { get; set; }

        /// <summary>
        /// Gets or sets the station pin code.
        /// </summary>
        [FirestoreProperty("stationPincode")]
        public int StationPinCode { get; set; }
    }
}
