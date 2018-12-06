using System;
using System.Globalization;
using System.Threading;
using System.Windows.Data;

namespace BusinessLogicWPF.TypeConverters
{
    public class MultiValueConverter :IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length <= 8 || values[0] == null || values[1] == null || values[2] == null || values[3] == null ||
                values[4] == null || values[5] == null || values[6] == null || values[7] == null)
                return null;

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

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
