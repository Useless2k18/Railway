using Google.Cloud.Firestore;
using System.Collections.Generic;

namespace BusinessLogicWPF.Model
{
    [FirestoreData]
    public class Train
    {
        [FirestoreProperty] public Coach COACH { get; set; }

        [FirestoreProperty] public string DEST_STN { get; set; }

        [FirestoreProperty] public string NAME { get; set; }

        [FirestoreProperty] public int NO_OF_STATIONS { get; set; }

        [FirestoreProperty] public string RAKE_ZONE { get; set; }

        [FirestoreProperty] public Dictionary<string, object> ROUTE { get; set; }

        [FirestoreProperty] public string[] RUNN_DATE { get; set; }

        [FirestoreProperty] public string SRC_STN { get; set; }

        [FirestoreProperty] public string TRAIN_NO { get; set; }

        [FirestoreProperty] public string TYPE { get; set; }
    }
}
