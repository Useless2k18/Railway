// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ErrorLabelHelper.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the ErrorLabelHelper type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessLogicWPF.Helper
{
    /// <summary>
    /// The error label helper.
    /// </summary>
    public class ErrorLabelHelper
    {
        /// <summary>
        /// The counter.
        /// </summary>
        private static int counter;

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorLabelHelper"/> class.
        /// </summary>
        public ErrorLabelHelper()
        {
            MaxCount = 0;
        }

        /// <summary>
        /// Gets or sets the max count.
        /// </summary>
        public static int MaxCount { get; set; }

        /// <summary>
        /// The check.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool Check()
        {
            counter++;
            return counter > MaxCount;
        }

        /// <summary>
        /// The reset.
        /// </summary>
        public static void Reset() => counter = 0;
    }
}
