using BusinessLogicWPF.Annotations;
using Google.Cloud.Firestore;

namespace BusinessLogicWPF.Model
{
    [FirestoreData]
    public class StationFrom
    {
        [CanBeNull] [FirestoreProperty] public string STATION_FROM_ID { get; set; }

        [CanBeNull] [FirestoreProperty] public string TT_BOARD_TIME { get; set; }
    }
}