// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IsdCodes.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the IsdCodes type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable InconsistentNaming
// ReSharper disable StyleCop.SA1300 for JSON file
namespace BusinessLogicWPF.Model.Json
{
    using BusinessLogicWPF.Annotations;

    /// <summary>
    /// The ISD codes for Filling up the combo box based on Country.
    /// It is created from a JSON file
    /// </summary>
    public class IsdCodes
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [CanBeNull]
        public string name { get; set; }

        /// <summary>
        /// Gets or sets the dial_code.
        /// </summary>
        [CanBeNull]
        public string dial_code { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        [CanBeNull]
        public string code { get; set; }
    }
}
