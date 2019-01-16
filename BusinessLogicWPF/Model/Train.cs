using System.Collections.Generic;

using BusinessLogicWPF.Annotations;

using Google.Cloud.Firestore;

namespace BusinessLogicWPF.Model
{
    [FirestoreData]
    public class Train
    {
        [CanBeNull] [FirestoreProperty] public Coach COACH { get; set; }

        [CanBeNull] [FirestoreProperty] public string DEST_STN { get; set; }

        [CanBeNull] [FirestoreProperty] public string NAME { get; set; }

        [FirestoreProperty] public int NO_OF_STATIONS { get; set; }

        [CanBeNull] [FirestoreProperty] public string RAKE_ZONE { get; set; }

        // Map inside map
        [CanBeNull] [FirestoreProperty] public Dictionary<string, Route> ROUTE { get; set; }

        [CanBeNull] [FirestoreProperty] public string[] RUNN_DATE { get; set; }

        [CanBeNull] [FirestoreProperty] public string SRC_STN { get; set; }

        [CanBeNull] [FirestoreProperty] public string TRAIN_NO { get; set; }

        [CanBeNull] [FirestoreProperty] public string TYPE { get; set; }
    }
}
