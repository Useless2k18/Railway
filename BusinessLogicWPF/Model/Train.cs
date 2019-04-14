// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Train.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the Train type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessLogicWPF.Model
{
    using System.Collections.Generic;

    using BusinessLogicWPF.Properties;

    using Google.Cloud.Firestore;

    /// <summary>
    /// The train.
    /// </summary>
    [FirestoreData]
    public class Train
    {
        /// <summary>
        /// Gets or sets the train no.
        /// </summary>
        [CanBeNull]
        [FirestoreProperty("trainNo")]
        public int TrainNumber { get; set; }

        /// <summary>
        /// Gets or sets the train name.
        /// </summary>
        [CanBeNull]
        [FirestoreProperty("trainName")]
        public string TrainName { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        [CanBeNull]
        [FirestoreProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the coach.
        /// </summary>
        [CanBeNull]
        [FirestoreProperty("coach")]
        public Coach Coach { get; set; }

        /// <summary>
        /// Gets or sets the source station.
        /// </summary>
        [CanBeNull]
        [FirestoreProperty("sourceStation")]
        public string SourceStation { get; set; }

        /// <summary>
        /// Gets or sets the destination station.
        /// </summary>
        [CanBeNull]
        [FirestoreProperty("destinationStation")]
        public string DestinationStation { get; set; }

        /// <summary>
        /// Gets or sets the rake zone.
        /// </summary>
        [CanBeNull]
        [FirestoreProperty("rakeZone")]
        public string RakeZone { get; set; }

        /// <summary>
        /// Gets or sets the route.
        /// </summary>
        [CanBeNull]
        [FirestoreProperty("route")]
        public List<Route> Route { get; set; }
    }
}
