using BusinessLogicWPF.Annotations;
using Google.Cloud.Firestore;

namespace BusinessLogicWPF.Model
{
    [FirestoreData]
    public class Station
    {
        [CanBeNull] [FirestoreProperty] public string STN_CODE { get; set; }

        [CanBeNull] [FirestoreProperty] public string STN_NAME { get; set; }

        [CanBeNull] [FirestoreProperty] public string STN_PIN { get; set; }
    }
}
