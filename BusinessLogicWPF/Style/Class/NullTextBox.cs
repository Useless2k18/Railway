// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NullTextBox.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the NullTextBox type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessLogicWPF.Style.Class
{
    using System.Windows;
    using System.Windows.Controls;

    using BusinessLogicWPF.Properties;

    /// <summary>
    /// The null text box.
    /// </summary>
    public class NullTextBox : TextBox
    {
        /// <summary>
        /// The null text property.
        /// </summary>
        [NotNull]
        public static readonly DependencyProperty NullTextProperty = DependencyProperty.Register(
            "NullText",
            typeof(string),
            typeof(NullTextBox),
            new FrameworkPropertyMetadata("Write text"));

        /// <summary>
        /// Initializes static members of the <see cref="NullTextBox"/> class.
        /// </summary>
        static NullTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(NullTextBox),
                new FrameworkPropertyMetadata(typeof(NullTextBox)));
        }

        /// <summary>
        /// Gets or sets the null text.
        /// </summary>
        [NotNull]
        public string NullText
        {
            get => (string)this.GetValue(NullTextProperty);
            set => this.SetValue(NullTextProperty, value);
        }
    }
}