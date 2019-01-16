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
    using BusinessLogicWPF.Annotations;

    using Google.Cloud.Firestore;

    /// <summary>
    /// The route.
    /// </summary>
    [FirestoreData]
    public class Route
    {
        /// <summary>
        /// Gets or sets the ar r_ time.
        /// </summary>
        [CanBeNull] [FirestoreProperty] public string ARR_TIME { get; set; }

        /// <summary>
        /// Gets or sets the dep t_ time.
        /// </summary>
        [CanBeNull] [FirestoreProperty] public string DEPT_TIME { get; set; }

        /// <summary>
        /// Gets or sets the st n_ code.
        /// </summary>
        [CanBeNull] [FirestoreProperty] public string STN_CODE { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether TTE assign flag.
        /// </summary>
        [FirestoreProperty] public bool TteAssignFlag { get; set; }
    }
}