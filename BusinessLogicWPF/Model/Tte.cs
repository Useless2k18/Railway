using BusinessLogicWPF.Annotations;
using Google.Cloud.Firestore;

namespace BusinessLogicWPF.Model
{
    [FirestoreData]
    public class Tte
    {
        [CanBeNull] [FirestoreProperty] public string TT_ID { get; set; }

        [CanBeNull] [FirestoreProperty] public string F_NAME { get; set; }

        [CanBeNull] [FirestoreProperty] public string L_NAME { get; set; }

        [CanBeNull]
        public string FullName => string.Format(F_NAME + " " + L_NAME);

        [CanBeNull] [FirestoreProperty] public string ZONE { get; set; }

        [CanBeNull] [FirestoreProperty] public string DATE { get; set; }

        [CanBeNull] [FirestoreProperty] public StationFrom STATION_FROM { get; set; }

        [CanBeNull] [FirestoreProperty] public StationTo STATION_TO { get; set; }
    }
}
