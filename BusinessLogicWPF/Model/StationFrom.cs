// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StationFrom.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the StationFrom type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessLogicWPF.Model
{
    using BusinessLogicWPF.Properties;

    using Google.Cloud.Firestore;

    /// <summary>
    /// The station from.
    /// </summary>
    [FirestoreData]
    public class StationFrom
    {
        /// <summary>
        /// Gets or sets the statio n_ fro m_ id.
        /// </summary>
        [CanBeNull] [FirestoreProperty] public string STATION_FROM_ID { get; set; }

        /// <summary>
        /// Gets or sets the t t_ boar d_ time.
        /// </summary>
        [CanBeNull] [FirestoreProperty] public string TT_BOARD_TIME { get; set; }
    }
}