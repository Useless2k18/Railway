using BusinessLogicWPF.Annotations;
using Google.Cloud.Firestore;

namespace BusinessLogicWPF.Model
{
    [FirestoreData]
    public class Route
    {
        [CanBeNull] [FirestoreProperty] public string ARR_TIME { get; set; }

        [CanBeNull] [FirestoreProperty] public string DEPT_TIME { get; set; }

        [CanBeNull] [FirestoreProperty] public string STN_CODE { get; set; }

        [FirestoreProperty] public bool TteAssignFlag { get; set; }
    }
}