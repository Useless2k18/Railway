// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StaticDbContext.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the StaticDbContext type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessLogicWPF.Helper
{
    using BusinessLogicWPF.GoogleCloudFireStoreLibrary;
    using BusinessLogicWPF.Properties;

    /// <summary>
    /// The static database context.
    /// </summary>
    public static class StaticDbContext
    {
        /// <summary>
        /// Gets or sets the connect fire store.
        /// </summary>
        [CanBeNull]
        public static ConnectFireStore ConnectFireStore { get; set; }
    }
}
