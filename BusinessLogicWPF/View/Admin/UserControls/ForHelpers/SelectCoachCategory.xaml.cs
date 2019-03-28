// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SelectCoachCategory.xaml.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Interaction logic for SelectCoachCategory.XAML
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessLogicWPF.View.Admin.UserControls.ForHelpers
{
    using System.Windows.Controls;

    using BusinessLogicWPF.Helper;
    using BusinessLogicWPF.Properties;

    /// <summary>
    /// Interaction logic for SelectCoachCategory.XAML
    /// </summary>
    public partial class SelectCoachCategory : UserControl
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BusinessLogicWPF.View.Admin.UserControls.ForHelpers.SelectCoachCategory" /> class.
        /// </summary>
        public SelectCoachCategory()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// The select coach category combo box on selection changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void SelectCoachCategoryComboBoxOnSelectionChanged([CanBeNull] object sender, [CanBeNull] SelectionChangedEventArgs e)
        {
            DataHelper.StatusForEnable = true;
        }
    }
}
