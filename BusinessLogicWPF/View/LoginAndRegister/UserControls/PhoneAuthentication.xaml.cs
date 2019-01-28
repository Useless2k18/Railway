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
    using BusinessLogicWPF.ViewModel.LoginAndRegister;

    using CefSharp;
    using CefSharp.Wpf;

    /// <summary>
    /// Interaction logic for Phone Authentication XAML
    /// </summary>
    public partial class PhoneAuthentication : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PhoneAuthentication"/> class.
        /// </summary>
        public PhoneAuthentication()
        {
            this.InitializeComponent();
            this.Browser = new ChromiumWebBrowser { Address = "file:///index.html" };

            this.Browser.FrameLoadEnd += BrowserOnFrameLoadEnd;

            this.MainGrid.Children.Add(this.Browser);

            this.DataContext = new OtpFieldViewModel();
        }

        /// <summary>
        /// Gets or sets the Chromium Web Browser.
        /// </summary>
        [NotNull]
        public ChromiumWebBrowser Browser { get; set; }
        
        /// <summary>
        /// The browser on frame load end.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private static void BrowserOnFrameLoadEnd([CanBeNull] object sender, [CanBeNull] FrameLoadEndEventArgs e)
        {
        }
    }
}
