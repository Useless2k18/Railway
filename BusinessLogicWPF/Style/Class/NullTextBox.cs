using System.Windows;
using System.Windows.Controls;

namespace BusinessLogicWPF.Style.Class
{
    public class NullTextBox : TextBox
    {
        static NullTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NullTextBox),
                new FrameworkPropertyMetadata(typeof(NullTextBox)));
        }


        public static readonly DependencyProperty NullTextProperty =
            DependencyProperty.Register("NullText", typeof(string),
                typeof(NullTextBox), new FrameworkPropertyMetadata("Write text"));

        public string NullText
        {
            get => (string)GetValue(NullTextProperty);
            set => SetValue(NullTextProperty, value);
        }
    }
}