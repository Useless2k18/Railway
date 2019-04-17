// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OtpField.xaml.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Interaction logic for OtpField.XAML
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessLogicWPF.View.LoginAndRegister.UserControls
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    using BusinessLogicWPF.Helper;
    using BusinessLogicWPF.Model.Json;
    using BusinessLogicWPF.Model.Json.Behavioral;
    using BusinessLogicWPF.Properties;

    using MaterialDesignThemes.Wpf;

    using Newtonsoft.Json;

    /// <summary>
    /// Interaction logic for OTP Field.XAML
    /// </summary>
    public partial class OtpField : UserControl
    {
        /// <summary>
        /// The regex.
        /// </summary>
        [CanBeNull]
        private static readonly Regex Regex = new Regex("[^0-9]+"); // regex that matches disallowed text
        
        /// <summary>
        /// The index.
        /// </summary>
        private static int index = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="OtpField"/> class.
        /// </summary>
        public OtpField()
        {
            this.InitializeComponent();
            this.ComboBoxCountryCode.IsEnabled = false;

            #region Hard Coding For Next Button

            if (this.DockPanelWithTextBoxOtp.Visibility == Visibility.Collapsed)
            {
                this.ButtonNextContent.Text = "Send OTP";
                this.ButtonNextIcon = new PackIcon()
                                          {
                                              Kind = PackIconKind.MessageProcessing,
                                              Width = 30,
                                              Height = 30
                                          };
            }

            #endregion
            
            var backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += this.BackgroundWorkerDoWork;
            backgroundWorker.RunWorkerCompleted += this.BackgroundWorkerRunWorkerCompleted;
            backgroundWorker.RunWorkerAsync();
        }

        /// <summary>
        /// Gets or sets the list of codes.
        /// </summary>
        [CanBeNull]
        public List<IsdCodes> ListOfCodes { get; set; }

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
        /// The background worker do work.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void BackgroundWorkerDoWork([CanBeNull] object sender, [CanBeNull] DoWorkEventArgs e)
        {
            try
            {
                var jsonFile = File.ReadAllText(@"isd_country_code.json");
                this.ListOfCodes = JsonConvert.DeserializeObject<List<IsdCodes>>(jsonFile);
                var countryName = RegionInfo.CurrentRegion.DisplayName;
                var i = 0;

                this.Dispatcher.Invoke(
                    () =>
                        {
                            this.ComboBoxCountryCode.ItemsSource = this.ListOfCodes;
                        });

                var listOfCodes = this.ListOfCodes;

                if (listOfCodes == null)
                {
                    return;
                }

                foreach (var listOfCode in listOfCodes)
                {
                    var i1 = i;
                    this.Dispatcher.Invoke(
                        () =>
                            {
                                if (listOfCode.name != null && listOfCode.name.Contains(
                                        countryName ?? throw new InvalidOperationException()))
                                {
                                    this.ComboBoxCountryCode.SelectedIndex = i1;
                                    index = i1;
                                }
                            });
                    i++;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                throw;
            }
        }

        /// <summary>
        /// The background worker run worker completed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void BackgroundWorkerRunWorkerCompleted([CanBeNull] object sender, [CanBeNull] RunWorkerCompletedEventArgs e)
        {
            this.ComboBoxCountryCode.IsEnabled = true;
        }

        /// <summary>
        /// The combo box country code on selection changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ComboBoxCountryCodeOnSelectionChanged([CanBeNull] object sender, [CanBeNull] SelectionChangedEventArgs e)
        {
            /*if (this.ComboBoxCountryCode.SelectedValue != null)
            {
                var listOfCodes = this.ListOfCodes;

                if (listOfCodes != null)
                {
                    index = listOfCodes.FindIndex(
                        a => this.ComboBoxCountryCode.SelectedValue.ToString()
                            .Contains(a.dial_code ?? throw new InvalidOperationException()));
                }
            }*/
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

            this.LabelTextPhoneNumber.Visibility = Visibility.Collapsed;
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
            if (string.IsNullOrWhiteSpace(this.TextBoxPhoneNumber.Text))
            {
                this.LabelTextPhoneNumber.Visibility = Visibility.Visible;
            }
            else
            {
                var mobileCode = (IsdCodes)this.ComboBoxCountryCode.SelectedValue;

                PhoneAuthenticationHelper.MobileNumber = $"{mobileCode.dial_code}{this.TextBoxPhoneNumber.Text}";
                PhoneAuthenticationHelper.Flag = 1;
                
                this.ButtonNextContent.Text = "Next";
                this.ButtonNextIcon = new PackIcon
                                          {
                                              Kind = PackIconKind.PageNextOutline,
                                              Width = 30,
                                              Height = 30
                                          };

                this.DockPanelWithTextBoxOtp.Visibility = Visibility.Visible;
            }

            if (!string.IsNullOrWhiteSpace(this.TextBoxOtp.Text))
            {
                PhoneAuthenticationHelper.Otp = this.TextBoxOtp.Text;
                PhoneAuthenticationHelper.Flag = 2;
            }
        }

        /// <summary>
        /// The framework element on request bring into view.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void FrameworkElementOnRequestBringIntoView(
            [CanBeNull] object sender,
            [NotNull] RequestBringIntoViewEventArgs e)
        {
            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            // Allows the keyboard to bring the items into view as expected:
            if (Keyboard.IsKeyDown(Key.Down) || Keyboard.IsKeyDown(Key.Up))
            {
                return;
            }            

            e.Handled = true;  
        }
    }
}
