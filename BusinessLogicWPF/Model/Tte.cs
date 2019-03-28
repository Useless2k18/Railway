// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Tte.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the Tte type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessLogicWPF.Model
{
    using BusinessLogicWPF.Properties;

    using Google.Cloud.Firestore;

    /// <summary>
    /// The TTE.
    /// </summary>
    [FirestoreData]
    public class Tte
    {
        /// <summary>
        /// Gets or sets the t t_ id.
        /// </summary>
        [CanBeNull] [FirestoreProperty] public string TT_ID { get; set; }

        /// <summary>
        /// Gets or sets the f_ name.
        /// </summary>
        [CanBeNull] [FirestoreProperty] public string F_NAME { get; set; }

        /// <summary>
        /// Gets or sets the l_ name.
        /// </summary>
        [CanBeNull] [FirestoreProperty] public string L_NAME { get; set; }

        /// <summary>
        /// The full name.
        /// </summary>
        [CanBeNull]
        public string FullName => string.Format(this.F_NAME + " " + this.L_NAME);

        /// <summary>
        /// Gets or sets the zone.
        /// </summary>
        [CanBeNull] [FirestoreProperty] public string ZONE { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        [CanBeNull] [FirestoreProperty] public string DATE { get; set; }

        /// <summary>
        /// Gets or sets the statio n_ from.
        /// </summary>
        [CanBeNull] [FirestoreProperty] public StationFrom STATION_FROM { get; set; }

        /// <summary>
        /// Gets or sets the statio n_ to.
        /// </summary>
        [CanBeNull] [FirestoreProperty] public StationTo STATION_TO { get; set; }

        /// <summary>
        /// Gets or sets the trai n_ no.
        /// </summary>
        [CanBeNull] [FirestoreProperty] public string TRAIN_NO { get; set; }
    }
}
