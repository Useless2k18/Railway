// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddStation.xaml.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Interaction logic for AddStations.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessLogicWPF.View.Admin.UserControls
{
    using System;
    using System.Text.RegularExpressions;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    using BusinessLogicWPF.Annotations;
    using BusinessLogicWPF.Helper;
    using BusinessLogicWPF.Model;

    /// <summary>
    /// Interaction logic for AddStations.XAML
    /// </summary>
    public partial class AddStation : UserControl
    {
        /// <summary>
        /// The regex.
        /// </summary>
        [NotNull]
        private static readonly Regex Regex = new Regex("[^0-9]+"); // regex that matches disallowed text

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BusinessLogicWPF.View.Admin.UserControls.AddStation" /> class.
        /// </summary>
        public AddStation()
        {
            this.InitializeComponent();
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

            return !Regex.IsMatch(text);
        }

        /// <summary>
        /// The text OTP preview text input.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void TextBoxPinCodePreviewTextInput([NotNull] object sender, [NotNull] TextCompositionEventArgs e)
        {
            if (sender == null)
            {
                throw new ArgumentNullException(nameof(sender));
            }

            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            e.Handled = !IsTextAllowed(e.Text);
        }

        /// <summary>
        /// The text OTP on pasting.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void TextBoxPinCodeOnPasting([NotNull] object sender, [NotNull] DataObjectPastingEventArgs e)
        {
            if (sender == null)
            {
                throw new ArgumentNullException(nameof(sender));
            }

            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                var text = (string)e.DataObject.GetData(typeof(string));
                if (!IsTextAllowed(text ?? throw new InvalidOperationException()))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }

        /// <summary>
        /// The button accept on click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ButtonAcceptOnClick([CanBeNull] object sender, [CanBeNull] RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.TextBoxZoneName.Text)
                || string.IsNullOrWhiteSpace(this.TextBoxDivisionName.Text)
                || string.IsNullOrWhiteSpace(this.TextBoxStationCode.Text)
                || string.IsNullOrWhiteSpace(this.TextBoxStationName.Text)
                || string.IsNullOrWhiteSpace(this.TextBoxPinCode.Text))
            {
                MessageBox.Show("Please fill up all the fields!");
                return;
            }

            if (this.TextBoxPinCode.Text.Length < 6)
            {
                MessageBox.Show("Pin Code must have SIX digits!");
                return;
            }
            
            var s = MessageBox.Show(
                "Are you sure you want to continue? You cannot undo this operation",
                "Question",
                MessageBoxButton.YesNo);
            
            if (s == MessageBoxResult.No)
            {
                return;
            }

            var station = new Station
                              {
                                  railwayDivision = new Division
                                                        {
                                                            Divisions = this.TextBoxDivisionName.Text
                                                        },

                                  stationCode = this.TextBoxStationCode.Text,
                                  stationName = this.TextBoxStationName.Text,
                                  stationPinCode = Convert.ToInt32(this.TextBoxPinCode.Text)
                              };

            /*if (DataHelper.Station != null)
            {
                if (DataHelper.Station.railwayDivision != null)
                {
                    DataHelper.Station.railwayDivision.Divisions = this.TextBoxDivisionName.Text;
                }

                if (DataHelper.Station.stationCode != null)
                {
                    DataHelper.Station.stationCode = this.TextBoxStationCode.Text;
                }

                if (DataHelper.Station.stationName != null)
                {
                    DataHelper.Station.stationName = this.TextBoxStationName.Text;
                }

                if (DataHelper.Station.stationCode != null)
                {
                    DataHelper.Station.stationPinCode = Convert.ToInt32(this.TextBoxPinCode.Text);
                }
            }*/
        }
    }
}
