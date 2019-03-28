// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WaterMarkTextHelper.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the WaterMarkTextHelper type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable StyleCop.SA1201
namespace BusinessLogicWPF.Style.Class
{
    using System;
    using System.Windows;
    using System.Windows.Controls;

    using BusinessLogicWPF.Properties;

    /// <summary>
    /// The water mark text helper.
    /// </summary>
    public class WaterMarkTextHelper : DependencyObject
    {
        /// <summary>
        /// The is monitoring property.
        /// </summary>
        [NotNull]
        public static readonly DependencyProperty IsMonitoringProperty =
            DependencyProperty.RegisterAttached(
                "IsMonitoring",
                typeof(bool),
                typeof(WaterMarkTextHelper),
                new UIPropertyMetadata(false, OnIsMonitoringChanged));

        /// <summary>
        /// The watermark text property.
        /// </summary>
        [NotNull]
        public static readonly DependencyProperty WatermarkTextProperty =
            DependencyProperty.RegisterAttached(
                "WatermarkText",
                typeof(string),
                typeof(WaterMarkTextHelper),
                new UIPropertyMetadata(string.Empty));

        /// <summary>
        /// The text length property.
        /// </summary>
        [NotNull]
        public static readonly DependencyProperty TextLengthProperty =
            DependencyProperty.RegisterAttached(
                "TextLength",
                typeof(int),
                typeof(WaterMarkTextHelper),
                new UIPropertyMetadata(0));
        
        #region Attached Properties

        /// <summary>
        /// The get is monitoring.
        /// </summary>
        /// <param name="obj">
        /// The object.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool GetIsMonitoring([NotNull] DependencyObject obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            return (bool)obj.GetValue(IsMonitoringProperty);
        }

        /// <summary>
        /// The set is monitoring.
        /// </summary>
        /// <param name="obj">
        /// The object.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// thrown if Argument Null Exception
        /// </exception>
        public static void SetIsMonitoring([NotNull] DependencyObject obj, bool value)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            obj.SetValue(IsMonitoringProperty, value);
        }

        /// <summary>
        /// The get watermark text.
        /// </summary>
        /// <param name="obj">
        /// The object.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// thrown if Argument Null Exception
        /// </exception>
        public static bool GetWatermarkText([NotNull] DependencyObject obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            return (bool)obj.GetValue(WatermarkTextProperty);
        }

        /// <summary>
        /// The set watermark text.
        /// </summary>
        /// <param name="obj">
        /// The object.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// thrown if Argument Null Exception
        /// </exception>
        public static void SetWatermarkText([NotNull] DependencyObject obj, [NotNull] string value)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            obj.SetValue(WatermarkTextProperty, value);
        }

        /// <summary>
        /// The get text length.
        /// </summary>
        /// <param name="obj">
        /// The object.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public static int GetTextLength([NotNull] DependencyObject obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            return (int)obj.GetValue(TextLengthProperty);
        }

        /// <summary>
        /// The set text length.
        /// </summary>
        /// <param name="obj">
        /// The object.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        public static void SetTextLength([NotNull] DependencyObject obj, int value)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            obj.SetValue(TextLengthProperty, value);

            obj.SetValue(HasTextProperty, value >= 1);
        }

        #endregion

        #region Internal DependencyProperty
        
        /// <summary>
        /// The has text property.
        /// </summary>
        [NotNull]
        private static readonly DependencyProperty HasTextProperty =
            DependencyProperty.RegisterAttached(
                "HasText",
                typeof(bool),
                typeof(WaterMarkTextHelper),
                new FrameworkPropertyMetadata(false));
        
        /// <summary>
        /// Gets or sets a value indicating whether has text.
        /// </summary>
        public bool HasText
        {
            get => (bool)this.GetValue(HasTextProperty);
            set => this.SetValue(HasTextProperty, value);
        }

        #endregion

        #region Implementation

        /// <summary>
        /// The on is monitoring changed.
        /// </summary>
        /// <param name="d">
        /// The d.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private static void OnIsMonitoringChanged([CanBeNull] DependencyObject d, DependencyPropertyChangedEventArgs e)
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
