// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Register2.xaml.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Interaction logic for Register2.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessLogicWPF.View.LoginAndRegister.UserControls
{
    using System;
    using System.Text.RegularExpressions;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    using BusinessLogicWPF.Annotations;

    /// <summary>
    /// Interaction logic for Register 2 XAML
    /// </summary>
    public partial class Register2 : UserControl
    {
        /// <summary>
        /// The regex.
        /// </summary>
        [CanBeNull]
        private static readonly Regex Regex = new Regex("[^0-9]+"); // regex that matches disallowed text
                                                                    
        /// <summary>
        /// Initializes a new instance of the <see cref="Register2"/> class.
        /// </summary>
        public Register2()
        {
            this.InitializeComponent();
            this.ComboBoxCountryCode.Items.Add("+91");
            this.ComboBoxCountryCode.Items.Add("+90");
            this.ComboBoxCountryCode.Items.Add("+456");
        }

        /// <summary>
        /// The is text allowed.
        /// </summary>
        /// <param name="text">
        /// The text.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private static bool IsTextAllowed([NotNull] string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            return Regex != null && !Regex.IsMatch(text);
        }

        /// <summary>
        /// The text box on preview text input.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void TextBoxOnPreviewTextInput([CanBeNull] object sender, [CanBeNull] TextCompositionEventArgs e)
        {
            if (e != null)
            {
                e.Handled = !IsTextAllowed(e.Text);
            }
        }

        // Use the DataObject.Pasting Handler 

        /// <summary>
        /// The text box on pasting.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void TextBoxOnPasting([CanBeNull] object sender, [CanBeNull] DataObjectPastingEventArgs e)
        {
            if (e != null && e.DataObject.GetDataPresent(typeof(string)))
            {
                var text = (string)e.DataObject.GetData(typeof(string));
                if (!IsTextAllowed(text ?? throw new InvalidOperationException()))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e?.CancelCommand();
            }
        }

        /// <summary>
        /// The button next on click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ButtonNextOnClick([CanBeNull] object sender, [CanBeNull] RoutedEventArgs e)
        {
            MessageBox.Show("Registered");
        }
    }
}
