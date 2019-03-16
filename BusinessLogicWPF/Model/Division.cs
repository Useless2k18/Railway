// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Division.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the Division type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessLogicWPF.Model
{
    using BusinessLogicWPF.Annotations;

    using Google.Cloud.Firestore;

    /// <summary>
    /// The division.
    /// </summary>
    [FirestoreData]
    public class Division
    {
        /// <summary>
        /// Gets or sets the divisions.
        /// </summary>
        [CanBeNull]
        [FirestoreProperty]
        public string Divisions { get; set; }
    }
}
