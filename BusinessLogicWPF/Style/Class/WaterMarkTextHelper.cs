using System.Windows;
using System.Windows.Controls;

namespace BusinessLogicWPF.Style.Class
{
    public class WaterMarkTextHelper : DependencyObject
    {
        #region Attached Properties

        public static bool GetIsMonitoring(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsMonitoringProperty);
        }

        public static void SetIsMonitoring(DependencyObject obj, bool value)
        {
            obj.SetValue(IsMonitoringProperty, value);
        }

        public static readonly DependencyProperty IsMonitoringProperty =
            DependencyProperty.RegisterAttached("IsMonitoring", typeof(bool), typeof(WaterMarkTextHelper), new UIPropertyMetadata(false, OnIsMonitoringChanged));


        public static bool GetWatermarkText(DependencyObject obj)
        {
            return (bool)obj.GetValue(WatermarkTextProperty);
        }

        public static void SetWatermarkText(DependencyObject obj, string value)
        {
            obj.SetValue(WatermarkTextProperty, value);
        }

        public static readonly DependencyProperty WatermarkTextProperty =
            DependencyProperty.RegisterAttached("WatermarkText", typeof(string), typeof(WaterMarkTextHelper), new UIPropertyMetadata(string.Empty));


        public static int GetTextLength(DependencyObject obj)
        {
            return (int)obj.GetValue(TextLengthProperty);
        }

        public static void SetTextLength(DependencyObject obj, int value)
        {
            obj.SetValue(TextLengthProperty, value);

            obj.SetValue(HasTextProperty, value >= 1);
        }

        public static readonly DependencyProperty TextLengthProperty =
            DependencyProperty.RegisterAttached("TextLength", typeof(int), typeof(WaterMarkTextHelper), new UIPropertyMetadata(0));

        #endregion

        #region Internal DependencyProperty

        public bool HasText
        {
            get => (bool)GetValue(HasTextProperty);
            set => SetValue(HasTextProperty, value);
        }

        private static readonly DependencyProperty HasTextProperty =
            DependencyProperty.RegisterAttached("HasText", typeof(bool), typeof(WaterMarkTextHelper), new FrameworkPropertyMetadata(false));

        #endregion

        #region Implementation

        private static void OnIsMonitoringChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            switch (d)
            {
                case TextBox txtBox when (bool)e.NewValue:
                    txtBox.TextChanged += TextChanged;
                    break;
                case TextBox txtBox:
                    txtBox.TextChanged -= TextChanged;
                    break;
                case PasswordBox _:
                    {
                        var passBox = d as PasswordBox;

                        if ((bool)e.NewValue)
                        {
                            if (passBox != null) passBox.PasswordChanged += PasswordChanged;
                        }
                        else if (passBox != null) passBox.PasswordChanged -= PasswordChanged;

                        break;
                    }
            }
        }

        private static void TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!(sender is TextBox txtBox)) return;
            SetTextLength(txtBox, txtBox.Text.Length);
        }

        private static void PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!(sender is PasswordBox passBox)) return;
            SetTextLength(passBox, passBox.Password.Length);
        }

        #endregion
    }
}
