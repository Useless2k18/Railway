using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BusinessLogicWPF.View.LoginAndRegister.UserControls
{
    /// <summary>
    /// Interaction logic for Register2.xaml
    /// </summary>
    public partial class Register2 : UserControl
    {
        public Register2()
        {
            InitializeComponent();
            ComboBoxCountryCode.Items.Add("+91");
            ComboBoxCountryCode.Items.Add("+90");
            ComboBoxCountryCode.Items.Add("+456");
        }

        private void TextBox_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private static readonly Regex Regex = new Regex("[^0-9]+"); //regex that matches disallowed text
        private static bool IsTextAllowed(string text)
        {
            return !Regex.IsMatch(text);
        }

        // Use the DataObject.Pasting Handler 
        private void TextBoxOnPasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                var text = (string)e.DataObject.GetData(typeof(string));
                if (!IsTextAllowed(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }

        private void ButtonNext_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Registered");
        }
    }
}
