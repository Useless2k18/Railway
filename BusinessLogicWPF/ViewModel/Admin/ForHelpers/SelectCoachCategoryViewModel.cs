// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SelectCoachCategoryViewModel.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the SelectCoachCategoryViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessLogicWPF.ViewModel.Admin.ForHelpers
{
    using System.Collections.ObjectModel;

    using BusinessLogicWPF.Annotations;

    /// <summary>
    /// The select coach category view model.
    /// </summary>
    public class SelectCoachCategoryViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SelectCoachCategoryViewModel"/> class.
        /// </summary>
        public SelectCoachCategoryViewModel()
        {
            this.CoachCategories = new ObservableCollection<string>
                                       {
                                           "Chair Car",
                                           "Second Sitting",
                                           "First Tier AC",
                                           "Second Tier AC",
                                           "Third Tier AC",
                                           "Sleeper"
                                       };
        }

        /// <summary>
        /// Gets or sets the coach categories.
        /// </summary>
        [CanBeNull]
        public ObservableCollection<string> CoachCategories { get; set; }
    }
}
