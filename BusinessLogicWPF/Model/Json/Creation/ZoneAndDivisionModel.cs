// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ZoneAndDivisionModel.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the ZoneAndDivisionModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessLogicWPF.Model.Json.Creation
{
    using System.Collections.Generic;

    using Google.Cloud.Firestore;

    /// <summary>
    /// The employee.
    /// </summary>
    [FirestoreData]
    public class ZoneAndDivisionModel
    {
        /// <summary>
        /// Gets or sets the zone list.
        /// </summary>
        [FirestoreProperty("zoneList")]
        public List<string> ZoneList { get; set; }

        /// <summary>
        /// Gets or sets the division list.
        /// </summary>
        [FirestoreProperty("divisionList")]
        public IDictionary<string, List<string>> DivisionList { get; set; }
    }
}
