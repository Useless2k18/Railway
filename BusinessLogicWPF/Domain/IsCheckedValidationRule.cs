// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IsCheckedValidationRule.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the IsCheckedValidationRule type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessLogicWPF.Domain
{
    using System.Globalization;
    using System.Windows.Controls;

    /// <summary>
    /// The is checked validation rule.
    /// </summary>
    public class IsCheckedValidationRule : ValidationRule
    {
        /// <summary>
        /// The validate.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="cultureInfo">
        /// The culture info.
        /// </param>
        /// <returns>
        /// The <see cref="ValidationResult"/>.
        /// </returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is bool && (bool)value)
            {
                return ValidationResult.ValidResult;
            }

            return new ValidationResult(false, "Option must be checked");
        }
    }
}