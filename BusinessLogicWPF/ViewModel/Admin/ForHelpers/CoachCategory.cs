// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CoachCategory.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   The coach category.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessLogicWPF.ViewModel.Admin.ForHelpers
{
    using System.Collections.ObjectModel;

    using BusinessLogicWPF.Model;
    using BusinessLogicWPF.Properties;

    /// <summary>
    /// The coach category.
    /// </summary>
    public sealed class CoachCategory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CoachCategory"/> class.
        /// </summary>
        public CoachCategory()
        {
            this.CoachCollection = new ObservableCollection<CoachCollection>(
                new[]
                    {
                        new CoachCollection
                            {
                                Name = "Chair Car"
                            },

                        new CoachCollection
                            {
                                Name = "First Tier AC"
                            },

                        new CoachCollection
                            {
                                Name = "Second Tier AC"
                            },

                        new CoachCollection
                            {
                                Name = "Third Tier AC"
                            },
                            
                        new CoachCollection
                            {
                                Name = "Sleeper"
                            },

                        new CoachCollection
                            {
                                Name = "Second Sitting"
                            }
                    });
        }

        /// <summary>
        /// Gets or sets the coach.
        /// </summary>
        [CanBeNull]
        public Coach Coach { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [CanBeNull]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the coach collection.
        /// </summary>
        [CanBeNull]
        public ObservableCollection<CoachCollection> CoachCollection { get; set; }

        /*
        /// <summary>
        /// Initializes a new instance of the <see cref="CoachCategory"/> class.
        /// </summary>
        /// <param name="coachType">
        /// The coach Type.
        /// </param>
        /// <param name="chairCar">
        /// The chair Car.
        /// </param>
        /// <param name="firstTierAc">
        /// The first Tier Ac.
        /// </param>
        /// <param name="secondTierAc">
        /// The second Tier Ac.
        /// </param>
        /// <param name="thirdTierAc">
        /// The third Tier Ac.
        /// </param>
        /// <param name="sleeper">
        /// The sleeper.
        /// </param>
        /// <param name="secondSitting">
        /// The second Sitting.
        /// </param>
        public CoachCategory(
            [CanBeNull] string[] coachType,
            [CanBeNull] IEnumerable<string> chairCar = null,
            [CanBeNull] IEnumerable<string> firstTierAc = null,
            [CanBeNull] IEnumerable<string> secondTierAc = null,
            [CanBeNull] IEnumerable<string> thirdTierAc = null,
            [CanBeNull] IEnumerable<string> sleeper = null,
            [CanBeNull] IEnumerable<string> secondSitting = null)
        {
            this.CoachType = new ObservableCollection<string>(coachType ?? throw new ArgumentNullException(nameof(coachType)));
            
            this.ChairCars = chairCar != null
                                 ? new ObservableCollection<string>(chairCar)
                                 : new ObservableCollection<string>(new[] { "NA" });
            
            this.FirstTierAcs = firstTierAc != null
                                    ? new ObservableCollection<string>(firstTierAc)
                                    : new ObservableCollection<string>(new[] { "NA" });
            
            this.SecondTierAcs = secondTierAc != null
                                     ? new ObservableCollection<string>(secondTierAc)
                                     : new ObservableCollection<string>(new[] { "NA" });
            
            this.ThirdTierAcs = thirdTierAc != null
                                    ? new ObservableCollection<string>(thirdTierAc)
                                    : new ObservableCollection<string>(new[] { "NA" });
            
            this.Sleepers = sleeper != null
                                ? new ObservableCollection<string>(sleeper)
                                : new ObservableCollection<string>(new[] { "NA" });
            
            this.SecondSittings = secondSitting != null
                                      ? new ObservableCollection<string>(secondSitting)
                                      : new ObservableCollection<string>(new[] { "NA" });
        }
                
        /// <summary>
        /// Gets the coach type.
        /// </summary>
        [CanBeNull]
        public ObservableCollection<string> CoachType { get; }

        /// <summary>
        /// Gets the chair cars.
        /// </summary>
        [CanBeNull]
        public ObservableCollection<string> ChairCars { get; }

        /// <summary>
        /// Gets the first tier ACs.
        /// </summary>
        [CanBeNull]
        public ObservableCollection<string> FirstTierAcs { get; }

        /// <summary>
        /// Gets the second tier ACs.
        /// </summary>
        [CanBeNull]
        public ObservableCollection<string> SecondTierAcs { get; }

        /// <summary>
        /// Gets the third tier ACs.
        /// </summary>
        [CanBeNull]
        public ObservableCollection<string> ThirdTierAcs { get; }

        /// <summary>
        /// Gets the sleepers.
        /// </summary>
        [CanBeNull]
        public ObservableCollection<string> Sleepers { get; }

        /// <summary>
        /// Gets the second sittings.
        /// </summary>
        [CanBeNull]
        public ObservableCollection<string> SecondSittings { get; }*/
    }

    public class CoachCollection
    {
        public CoachCollection()
        {
            this.Coaches = new ObservableCollection<Coaches>(
                new[]
                    {
                        new Coaches
                            {
                                Name = "C1"
                            },

                        new Coaches
                            {
                                Name = "C2"
                            }
                    });
        }
        
        public string Name { get; set; }

        public ObservableCollection<Coaches> Coaches { get; set; }
    }

    public class Coaches
    {
        public string Name { get; set; }
    }
}
