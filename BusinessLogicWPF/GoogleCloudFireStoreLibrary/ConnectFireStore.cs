using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1Beta1;
using Grpc.Auth;
using Grpc.Core;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogicWPF.GoogleCloudFireStoreLibrary
{
    public class ConnectFireStore
    {
        private static FirestoreDb _fireStoreDb;

        public ConnectFireStore(string projectId, string jsonPath, string dataBaseId = "(default)")
        {
            var googleCredential = GoogleCredential.FromFile(jsonPath);
            var channel = new Channel(
                FirestoreClient.DefaultEndpoint.Host, FirestoreClient.DefaultEndpoint.Port,
                googleCredential.ToChannelCredentials());
            var fireStoreClient = FirestoreClient.Create(channel);

            _fireStoreDb = FirestoreDb.Create(projectId, dataBaseId, fireStoreClient);
        }

        private static string StringArrayToString(string[] stringArray, string separator) =>
            string.Join(separator, stringArray);

        private static string GetCollectionPath(string[] pathArray)
        {
            if (pathArray.Length > 1)
                return pathArray.Length % 2 != 0 ? StringArrayToString(pathArray, "/") : null;
            return pathArray.ToString().Contains("/") ? pathArray.ToString() : null;
        }

        private static string GetDocumentPath(string[] pathArray)
        {
            if (pathArray.Length > 1)
                return pathArray.Length % 2 == 0 ? StringArrayToString(pathArray, "/") : null;
            return pathArray.ToString().Contains("/") ? pathArray.ToString() : null;
        }

        #region Add Data

        public async Task AddCollectionData(Dictionary<string, object> dictionary, params string[] name)
        {
            var documentReference = _fireStoreDb.Document(GetDocumentPath(name));

            if (documentReference == null) return;
            await documentReference.SetAsync(dictionary);
        }

        public async Task AddCollectionData<TEntity>(TEntity entity, params string[] name) where TEntity : class
        {
            var documentReference = _fireStoreDb.Document(GetDocumentPath(name));

            if (documentReference == null) return;
            await documentReference.SetAsync(entity);
        }

        #endregion

        #region Add Or Update Data

        public async Task AddOrUpdateCollectionData(Dictionary<string, object> dictionary, params string[] name)
        {
            var documentReference = _fireStoreDb.Document(GetDocumentPath(name));

            if (documentReference != null)
                await documentReference.SetAsync(dictionary, SetOptions.MergeAll);
        }

        public async Task AddOrUpdateCollectionData<TEntity>(TEntity entity, params string[] name) where TEntity : class
        {
            var documentReference = _fireStoreDb.Document(GetDocumentPath(name));

            if (documentReference != null)
                await documentReference.SetAsync(entity, SetOptions.MergeAll);
        }

        #endregion

        #region Update Data

        public async Task UpdateDoc(IDictionary<string, object> dictionary, params string[] name)
        {
            var documentReference = _fireStoreDb.Document(GetDocumentPath(name));

            if (documentReference != null)
                await documentReference.UpdateAsync(dictionary);
        }

        #endregion

        #region Get Data

        #region Get Collection Fields

        public TEntity GetCollectionFields<TEntity>(params string[] name) where TEntity : class
        {
            var documentReference = _fireStoreDb.Document(GetDocumentPath(name));

            if (documentReference == null) return null;

            var snapshot = documentReference.GetSnapshotAsync().Result;

            return snapshot.Exists ? snapshot.ConvertTo<TEntity>() : null;
        }

        public Dictionary<string, object> GetCollectionFields(params string[] name)
        {
            var documentReference = _fireStoreDb.Document(GetDocumentPath(name));

            if (documentReference == null) return null;

            var snapshot = documentReference.GetSnapshotAsync().Result;

            return snapshot.Exists ? snapshot.ToDictionary() : null;
        }

        #endregion

        #region Get All Document or Collection

        public List<Dictionary<string, object>> GetAllDocumentData(params string[] name)
        {
            var allCollectionsQuery = _fireStoreDb.Collection(GetCollectionPath(name));

            var allCollectionQuerySnapshot = allCollectionsQuery?.GetSnapshotAsync().Result;

            return allCollectionQuerySnapshot?.Documents.Where(documentSnapshot => documentSnapshot.Exists)
                .Where(documentSnapshot => documentSnapshot.ToDictionary() != null)
                .Select(documentSnapshot => documentSnapshot.ToDictionary()).ToList();
        }

        public List<TEntity> GetAllDocumentData<TEntity>(params string[] name) where TEntity : class
        {
            var allCollectionsQuery = _fireStoreDb.Collection(GetCollectionPath(name));

            var allCollectionQuerySnapshot = allCollectionsQuery?.GetSnapshotAsync().Result;

            return allCollectionQuerySnapshot?.Documents.Where(documentSnapshot => documentSnapshot.Exists)
                .Select(documentSnapshot => documentSnapshot.ConvertTo<TEntity>()).ToList();
        }

        public List<string> GetAllDocumentId(params string[] name)
        {
            var allCollectionsQuery = _fireStoreDb.Collection(GetCollectionPath(name));

            var allCollectionQuerySnapshot = allCollectionsQuery?.GetSnapshotAsync().Result;

            return allCollectionQuerySnapshot?.Documents.Where(documentSnapshot => documentSnapshot.Exists)
                .Select(documentSnapshot => documentSnapshot.Id).ToList();
        }

        public List<CollectionReference> GetCollections(params string[] name)
        {
            var documentReference = _fireStoreDb.Document(GetDocumentPath(name));
            var collectionReference = new List<CollectionReference>();

            if (documentReference == null) return null;

            IList<CollectionReference> subCollections = documentReference.ListCollectionsAsync().ToList().Result;

            collectionReference.AddRange(subCollections);

            return collectionReference;
        }

        #endregion

        #endregion

        #region Query

        public bool FindDocument(string documentId, params string[] name)
        {
            var collectionReference = _fireStoreDb.Collection(GetCollectionPath(name));

            if (collectionReference == null) return false;

            var documentSnapshot = collectionReference.Document(documentId).GetSnapshotAsync().Result;

            return documentSnapshot.Exists;
        }

        #endregion
    }
}
