// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StationsList.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the StationsList type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessLogicWPF.Model.Json.Creation
{
    using System.Collections.Generic;

    /// <summary>
    /// The stations list.
    /// </summary>
    public class StationsList
    {
        /// <summary>
        /// Gets or sets the stations.
        /// </summary>
        public IDictionary<string, Station> Stations { get; set; }
    }
}
