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
    using BusinessLogicWPF.Annotations;

    using Google.Cloud.Firestore;

    /// <summary>
    /// The station.
    /// </summary>
    [FirestoreData]
    public class Station
    {
        /// <summary>
        /// Gets or sets the st n_ code.
        /// </summary>
        [CanBeNull][FirestoreProperty] public string STN_CODE { get; set; }

        /// <summary>
        /// Gets or sets the st n_ name.
        /// </summary>
        [CanBeNull][FirestoreProperty] public string STN_NAME { get; set; }

        /// <summary>
        /// Gets or sets the st n_ pin.
        /// </summary>
        [CanBeNull][FirestoreProperty] public string STN_PIN { get; set; }
    }
}
