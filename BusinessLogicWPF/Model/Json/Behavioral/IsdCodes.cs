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
namespace BusinessLogicWPF.Model.Json.Behavioral
{
    using System;

    using BusinessLogicWPF.Properties;

    /// <summary>
    /// The ISD codes for Filling up the combo box based on Country.
    /// It is created from a JSON file
    /// </summary>
    public class IsdCodes
    {
        /// <summary>
        /// The short description.
        /// </summary>
        [CanBeNull]
        private string shortDescription;
        
        /// <summary>
        /// The long description.
        /// </summary>
        [CanBeNull]
        private string longDescription;
        
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

        /// <summary>
        /// Gets or sets the short description.
        /// </summary>
        [CanBeNull]
        public string ShortDescription
        {
            get
            {
                return this.shortDescription = $"{this.dial_code} ({this.code})";
            }

            set
            {
                if (value == null)
                {
                    throw new InvalidOperationException();
                }

                if (this.shortDescription == value)
                {
                    return;
                }

                this.shortDescription = $"{this.dial_code} ({this.code})";
            }
        }

        /// <summary>
        /// Gets or sets the long description.
        /// </summary>
        [CanBeNull]
        public string LongDescription
        {
            get
            {
                return this.longDescription = $"{this.name} ({this.dial_code})";
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                if (this.longDescription == value)
                {
                    return;
                }

                this.longDescription = $"{this.name} ({this.code})";
            }
        }
    }
}
