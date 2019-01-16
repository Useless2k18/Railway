// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StationTo.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the StationTo type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessLogicWPF.Model
{
    using BusinessLogicWPF.Annotations;

    using Google.Cloud.Firestore;

    /// <summary>
    /// The station to.
    /// </summary>
    [FirestoreData]
    public class StationTo
    {
        /// <summary>
        /// Gets or sets the statio n_ t o_ id.
        /// </summary>
        [CanBeNull] [FirestoreProperty] public string STATION_TO_ID { get; set; }

        /// <summary>
        /// Gets or sets the t t_ deboar d_ time.
        /// </summary>
        [CanBeNull] [FirestoreProperty] public string TT_DEBOARD_TIME { get; set; }
    }
}