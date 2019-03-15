// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SelectionDialog.xaml.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Interaction logic for SelectionDialog.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessLogicWPF.View.Helpers.UserControls
{
    using System;
    using System.ComponentModel;
    using System.Windows.Controls;

    using BusinessLogicWPF.Annotations;
    using BusinessLogicWPF.Helper;

    /// <summary>
    /// Interaction logic for Selection Dialog XAML
    /// </summary>
    public partial class SelectionDialog : UserControl
    {
        /// <summary>
        /// The background worker.
        /// </summary>
        [NotNull]
        private readonly BackgroundWorker backgroundWorker = new BackgroundWorker();

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BusinessLogicWPF.View.Helpers.UserControls.SelectionDialog" /> class.
        /// </summary>
        public SelectionDialog()
            : base()
        {
            this.InitializeComponent();

            DataHelper.StatusForEnable = false;

            this.backgroundWorker.DoWork += this.BackgroundWorkerDoWork;
            this.backgroundWorker.RunWorkerCompleted += this.BackgroundWorkerRunWorkerCompleted;
            this.backgroundWorker.RunWorkerAsync();
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
        private void BackgroundWorkerDoWork([NotNull] object sender, [NotNull] DoWorkEventArgs e)
        {
            if (sender == null)
            {
                throw new ArgumentNullException(nameof(sender));
            }

            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            while (!DataHelper.StatusForEnable)
            {
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
        private void BackgroundWorkerRunWorkerCompleted([NotNull] object sender, [NotNull] RunWorkerCompletedEventArgs e)
        {
            if (sender == null)
            {
                throw new ArgumentNullException(nameof(sender));
            }

            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            this.ButtonAccept.IsEnabled = true;
        }
    }
}
