using BusinessLogicWPF.Annotations;
using Google.Cloud.Firestore;

namespace BusinessLogicWPF.Model
{
    [FirestoreData]
    public class Coach
    {
        [CanBeNull] [FirestoreProperty] public string ChairCar { get; set; }

        [CanBeNull] [FirestoreProperty] public string FirstTierAc { get; set; }

        [CanBeNull] [FirestoreProperty] public string SecondSitting { get; set; }

        [CanBeNull] [FirestoreProperty] public string SecondTierAc { get; set; }

        [CanBeNull] [FirestoreProperty] public string Sleeper { get; set; }

        [CanBeNull] [FirestoreProperty] public string ThirdTierAc { get; set; }
    }
}