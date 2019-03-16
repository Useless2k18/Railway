// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Station.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the Station type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable InconsistentNaming
namespace BusinessLogicWPF.Model
{
    using System.Diagnostics.CodeAnalysis;

    using BusinessLogicWPF.Annotations;

    using Google.Cloud.Firestore;

    /// <summary>
    /// The station.
    /// </summary>
    [FirestoreData]
    public class Station
    {
        /// <summary>
        /// Gets or sets the railway division.
        /// </summary>
        [CanBeNull]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Reviewed. Suppression is OK here.")]
        [FirestoreProperty]
        public Division railwayDivision { get; set; }

        /// <summary>
        /// Gets or sets the station code.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Reviewed. Suppression is OK here.")]
        [CanBeNull]
        [FirestoreProperty]
        public string stationCode { get; set; }

        /// <summary>
        /// Gets or sets the station name.
        /// </summary>
        [CanBeNull]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Reviewed. Suppression is OK here.")]
        public string stationName { get; set; }

        /// <summary>
        /// Gets or sets the station pin code.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Reviewed. Suppression is OK here.")]
        [CanBeNull]
        [FirestoreProperty]
        public int stationPinCode { get; set; }
    }
}
