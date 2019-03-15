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
    using System;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    using System.Windows.Media;
    using System.Windows.Shapes;

    using BusinessLogicWPF.Annotations;
    using BusinessLogicWPF.Helper;

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
        /// Finds a Child of a given item in the visual tree. 
        /// </summary>
        /// <param name="parent">A direct parent of the queried item.</param>
        /// <typeparam name="T">The type of the queried item.</typeparam>
        /// <param name="childName">x:Name or Name of child. </param>
        /// <returns>The first parent item that matches the submitted type parameter. 
        /// If not matching item can be found, 
        /// a null parent is being returned.</returns>
        [CanBeNull]
        public static T FindChild<T>([CanBeNull] DependencyObject parent, [CanBeNull] string childName)
            where T : DependencyObject
        {    
            // Confirm parent and childName are valid. 
            if (parent == null)
            {
                return null;
            }

            T foundChild = null;

            var childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (var i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);

                // If the child is not of the request child type child
                if (!(child is T childType))
                {
                    // recursively drill down the tree
                    foundChild = FindChild<T>(child, childName);

                    // If the child is found, break so we do not overwrite the found child. 
                    if (foundChild != null)
                    {
                        break;
                    }
                }
                else if (!string.IsNullOrEmpty(childName))
                {
                    // If the child's name is set for search
                    if (child is FrameworkElement frameworkElement && frameworkElement.Name == childName)
                    {
                        // if the child's name is of the request name
                        foundChild = (T)child;
                        break;
                    }
                }
                else
                {
                    // child element found.
                    foundChild = (T)child;
                    break;
                }
            }

            return foundChild;
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

            var findTextBox = FindChild<TextBox>(this.StackPanel, s);

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
                var textBox = FindChild<TextBox>(this.StackPanel, "TextBox" + i);
                
                if (string.IsNullOrWhiteSpace(textBox?.Text))
                {
                    MessageBox.Show("Please fill up all the fields!");
                    DataHelper.StatusForEnable = false;
                    return;
                }
            }

            MessageBox.Show("Are you sure you want to continue? You cannot undo this operation");

            var button = (Button)this.FindName("ButtonAdd");
            var button2 = (Button)this.FindName("ButtonSuccess");

            for (var i = 1; i <= this.counter; i++)
            {
                var textBox = FindChild<TextBox>(this.StackPanel, "TextBox" + i);

                if (textBox != null)
                {
                    textBox.Visibility = Visibility.Collapsed;
                }
            }

            if (button != null && button2 != null)
            {
                button.Visibility = Visibility.Collapsed;
                button2.Visibility = Visibility.Collapsed;
            }

            DataHelper.StatusForEnable = true;
        }

        /// <summary>
        /// The button delete on click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ButtonDeleteOnClick([CanBeNull] object sender, [CanBeNull] RoutedEventArgs e)
        {
        }
    }
}
