// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnterCoaches.xaml.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Interaction logic for EnterCoaches.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessLogicWPF.View.Admin.UserControls.ForHelpers
{
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    using BusinessLogicWPF.Helper;
    using BusinessLogicWPF.Properties;

    using MaterialDesignThemes.Wpf;

    /// <summary>
    /// Interaction logic for EnterCoaches.XAML
    /// </summary>
    public partial class EnterCoaches : UserControl
    {
        /// <summary>
        /// The counter.
        /// </summary>
        private int counter = 1;

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BusinessLogicWPF.View.Admin.UserControls.ForHelpers.EnterCoaches" /> class.
        /// </summary>
        public EnterCoaches()
        {
            this.InitializeComponent();

            DataHelper.StatusForEnable = false;
        }

        /// <summary>
        /// The button add on click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ButtonAddOnClick([CanBeNull] object sender, [CanBeNull] RoutedEventArgs e)
        {
            var s = "TextBox" + this.counter;

            var findTextBox = ExtendedVisualTreeHelper.FindChild<TextBox>(this.StackPanel, s);

            if (string.IsNullOrWhiteSpace(findTextBox?.Text))
            {
                MessageBox.Show("Please update previous text field(s)");
                return;
            }
            
            var textBox = new TextBox
                              {
                                  Name = "TextBox" + ++this.counter, Margin = new Thickness(10, 10, 10, 10)
                              };

            // Material Design Properties
            HintAssist.SetHint(textBox, "Enter Coach Number");
            HintAssist.SetIsFloating(textBox, true);

            // Update ScrollViewer
            this.ScrollViewer.ScrollToEnd();

            // Update Static class DataHelper
            DataHelper.StatusForEnable = false;

            this.StackPanel.Children.Add(textBox);
        }

        /// <summary>
        /// The button success on click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ButtonSuccessOnClick([CanBeNull] object sender, [CanBeNull] RoutedEventArgs e)
        {
            for (var i = 1; i <= this.counter; i++)
            {
                var textBox = ExtendedVisualTreeHelper.FindChild<TextBox>(this.StackPanel, "TextBox" + i);
                
                if (string.IsNullOrWhiteSpace(textBox?.Text))
                {
                    MessageBox.Show("Please fill up all the fields!");
                    DataHelper.StatusForEnable = false;
                    return;
                }
            }

            var s = MessageBox.Show(
                "Are you sure you want to continue? You cannot undo this operation",
                "Question",
                MessageBoxButton.YesNo);
            
            if (s == MessageBoxResult.No)
            {
                return;
            }

            var button = (Button)this.FindName("ButtonAdd");
            var button2 = (Button)this.FindName("ButtonSuccess");

            DataHelper.CoachesList = new List<string>();

            for (var i = 1; i <= this.counter; i++)
            {
                var textBox = ExtendedVisualTreeHelper.FindChild<TextBox>(this.StackPanel, "TextBox" + i);

                if (textBox != null)
                {
                    DataHelper.CoachesList?.Add(textBox.Text);
                    textBox.IsEnabled = false;
                }
            }

            if (button != null && button2 != null)
            {
                button.Visibility = Visibility.Collapsed;
                button2.Visibility = Visibility.Collapsed;
            }

            DataHelper.StatusForEnable = true;
        }
    }
}
