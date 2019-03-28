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
    using System.ComponentModel;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Threading;

    using BusinessLogicWPF.Helper;
    using BusinessLogicWPF.JsClasses;
    using BusinessLogicWPF.Properties;
    using BusinessLogicWPF.ViewModel.LoginAndRegister;

    using CefSharp;
    using CefSharp.Internals;
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
            
            PhoneAuthenticationHelper.Flag = 0;

            this.DataContext = new OtpFieldViewModel();

            var backgroundWorker = new BackgroundWorker();
            backgroundWorker.RunWorkerCompleted += this.BackgroundWorkerRunWorkerCompleted;
            backgroundWorker.DoWork += this.BackgroundWorkerDoWork;
            backgroundWorker.RunWorkerAsync();

            var settings = new CefSettings { RemoteDebuggingPort = 8088 };
            Cef.Initialize(settings);
        }

        /// <summary>
        /// Gets or sets the Chromium Web Browser.
        /// </summary>
        [CanBeNull]
        public ChromiumWebBrowser Browser { get; set; }

        /// <summary>
        /// The load page async.
        /// </summary>
        /// <param name="browser">
        /// The browser.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [CanBeNull]
        public static Task LoadPageAsync([NotNull] IWebBrowser browser)
        {
            var tcs = new TaskCompletionSource<bool>();

            EventHandler<LoadingStateChangedEventArgs> handler = null;
            handler = (sender, args) =>
                {
                    if (!args.IsLoading)
                    {
                        browser.LoadingStateChanged -= handler;
                        tcs.TrySetResultAsync(true);
                    }
                };

            browser.LoadingStateChanged += handler;
            return tcs.Task;
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
            while (PhoneAuthenticationHelper.Flag == 0)
            {
            }

            this.Dispatcher.Invoke(
                DispatcherPriority.Send,
                new Action(
                    () =>
                        {
                        this.Browser = new ChromiumWebBrowser();

                        CefSharpSettings.LegacyJavascriptBindingEnabled = true;

                        this.Browser.RegisterJsObject(
                            "dotNetPhoneNumberAuthentication",
                            new DotNetPhoneNumberAuthentication(
                                PhoneAuthenticationHelper.MobileNumber ?? throw new InvalidOperationException()));
                        this.Browser.IsBrowserInitializedChanged += (s, args) =>
                            {
                                if (this.Browser.IsBrowserInitialized)
                                {
                                    this.Browser.LoadHtml(File.ReadAllText(@"index.html"));

                                    // this.Browser.ShowDevTools();
                                }
                            };
                        
                        this.Browser.FrameLoadEnd += this.BrowserOnFrameLoadEnd;

                        this.MainGrid.Children.Add(this.Browser ?? throw new InvalidOperationException());
                    }));

            Task.Delay(5000).Wait();
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
            MessageBox.Show(PhoneAuthenticationHelper.MobileNumber);

            this.Browser.EvaluateScriptAsync("document.getElementById('sign-in-form').submit();").ConfigureAwait(false);

            var backgroundWorker2 = new BackgroundWorker();
            backgroundWorker2.RunWorkerCompleted += this.BackgroundWorker2RunWorkerCompleted;
            backgroundWorker2.DoWork += this.BackgroundWorker2DoWork;
        }

        /// <summary>
        /// The background worker 2 do work.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void BackgroundWorker2DoWork([CanBeNull] object sender, [CanBeNull] DoWorkEventArgs e)
        {
        }

        /// <summary>
        /// The background worker 2 run worker completed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void BackgroundWorker2RunWorkerCompleted([CanBeNull] object sender, [CanBeNull] RunWorkerCompletedEventArgs e)
        {
        }

        /// <summary>
        /// The browser on frame load end.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void BrowserOnFrameLoadEnd([CanBeNull] object sender, [CanBeNull] FrameLoadEndEventArgs e)
        {
        }
    }
}
