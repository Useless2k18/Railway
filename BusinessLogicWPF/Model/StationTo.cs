using BusinessLogicWPF.Annotations;
using Google.Cloud.Firestore;

namespace BusinessLogicWPF.Model
{
    [FirestoreData]
    public class StationTo
    {
        [CanBeNull] [FirestoreProperty] public string STATION_TO_ID { get; set; }

        [CanBeNull] [FirestoreProperty] public string TT_DEBOARD_TIME { get; set; }
    }
}