using System;
using System.Windows;
using System.Windows.Data;

namespace BusinessLogicWPF.Style.Class
{
    public class TextInputToVisibilityConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Always test MultiValueConverter inputs for non-null 
            // (to avoid crash bugs for views in the designer) 
            if (!(values[0] is bool b) || !(values[1] is bool hasFocus)) return Visibility.Visible;

            var hasText = !b;
            if (hasFocus || hasText)
                return Visibility.Collapsed;

            return Visibility.Visible;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
