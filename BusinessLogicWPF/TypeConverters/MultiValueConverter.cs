// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MultiValueConverter.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the MultiValueConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessLogicWPF.TypeConverters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    /// <inheritdoc />
    /// <summary>
    /// The multi value converter.
    /// </summary>
    public class MultiValueConverter : IMultiValueConverter
    {
        /// <inheritdoc />
        /// <summary>
        /// The convert.
        /// </summary>
        /// <param name="values">
        /// The values.
        /// </param>
        /// <param name="targetType">
        /// The target type.
        /// </param>
        /// <param name="parameter">
        /// The parameter.
        /// </param>
        /// <param name="culture">
        /// The culture.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.Object" />.
        /// </returns>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length <= 8 || values[0] == null || values[1] == null || values[2] == null || values[3] == null
                || values[4] == null || values[5] == null || values[6] == null || values[7] == null)
            {
                return null;
            }

            var isEnabled = !(string.IsNullOrEmpty(values[0].ToString()) ||
                              string.IsNullOrEmpty(values[1].ToString()) ||
                              string.IsNullOrEmpty(values[2].ToString()) ||
                              string.IsNullOrEmpty(values[3].ToString()) ||
                              string.IsNullOrEmpty(values[4].ToString()) ||
                              string.IsNullOrEmpty(values[5].ToString()) ||
                              string.IsNullOrEmpty(values[6].ToString()) ||
                              string.IsNullOrEmpty(values[7].ToString()));

            return isEnabled;
        }

        /// <inheritdoc />
        /// <summary>
        /// The convert back.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="targetTypes">
        /// The target types.
        /// </param>
        /// <param name="parameter">
        /// The parameter.
        /// </param>
        /// <param name="culture">
        /// The culture.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.Object" />.
        /// </returns>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
