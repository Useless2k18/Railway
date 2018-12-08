using Google.Cloud.Firestore;

namespace BusinessLogicWPF.Model
{
    [FirestoreData]
    public class Station
    {
        [FirestoreProperty]
        public string STN_CODE { get; set; }

        [FirestoreProperty]
        public string STN_NAME { get; set; }

        [FirestoreProperty]
        public string STN_PIN { get; set; }
    }
}
