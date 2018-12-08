using BusinessLogicWPF.Annotations;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1Beta1;
using Grpc.Auth;
using Grpc.Core;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentReference = Google.Cloud.Firestore.DocumentReference;

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

        private static CollectionReference GetCollectionReference(string collectionName,
            [CanBeNull] string documentName, [CanBeNull] string collectionName2)
        {
            if (documentName == string.Empty || collectionName2 == string.Empty)
                return _fireStoreDb.Collection(collectionName);

            return _fireStoreDb.Collection(collectionName).Document(documentName).Collection(collectionName2);
        }

        private static DocumentReference GetDocumentReference(string collectionName, string documentName) =>
            _fireStoreDb.Collection(collectionName).Document(documentName);

        #region Add Data

        public async Task AddCollectionData(Dictionary<string, object> dictionary, params string[] name)
        {
            DocumentReference documentReference = null;

            for (var i = 0; i < name.Length / 2; i++)
                documentReference = GetDocumentReference(name[i], name[i + 1]);

            if (documentReference == null) return;
            await documentReference.SetAsync(dictionary);
        }

        public async Task AddCollectionData(object entity, params string[] name)
        {
            DocumentReference documentReference = null;

            for (var i = 0; i < name.Length / 2; i++)
                documentReference = GetDocumentReference(name[i], name[i + 1]);

            if (documentReference == null) return;
            await documentReference.SetAsync(entity);
        }

        #endregion

        #region Add Or Update Data

        public async Task AddOrUpdateCollectionData(Dictionary<string, object> dictionary, params string[] name)
        {
            DocumentReference documentReference = null;

            for (var i = 0; i < name.Length / 2; i++)
                documentReference = GetDocumentReference(name[i], name[i + 1]);

            if (documentReference != null)
                await documentReference.SetAsync(dictionary, SetOptions.MergeAll);
        }

        public async Task AddOrUpdateCollectionData(object entity, params string[] name)
        {
            DocumentReference documentReference = null;

            for (var i = 0; i < name.Length / 2; i++)
                documentReference = GetDocumentReference(name[i], name[i + 1]);

            if (documentReference != null)
                await documentReference.SetAsync(entity, SetOptions.MergeAll);
        }

        #endregion

        #region Update Data

        public async Task UpdateDoc(IDictionary<string, object> dictionary, params string[] name)
        {
            DocumentReference documentReference = null;

            for (var i = 0; i < name.Length / 2; i++)
                documentReference = GetDocumentReference(name[i], name[i + 1]);

            if (documentReference != null)
                await documentReference.UpdateAsync(dictionary);
        }

        #endregion

        #region Get Data

        #region Get Collection Fields

        public async Task GetCollectionFields(object entity, params string[] name)
        {
            DocumentReference documentReference = null;

            for (var i = 0; i < name.Length / 2; i++)
                documentReference = GetDocumentReference(name[i], name[i + 1]);

            if (documentReference == null) return;

            var snapshot = await documentReference.GetSnapshotAsync();

            if (snapshot.Exists)
                entity = snapshot.ConvertTo<object>();
        }

        public async Task GetCollectionFields(Dictionary<string, object> dictionary, params string[] name)
        {
            DocumentReference documentReference = null;

            for (var i = 0; i < name.Length / 2; i++)
                documentReference = GetDocumentReference(name[i], name[i + 1]);

            if (documentReference == null) return;

            var snapshot = await documentReference.GetSnapshotAsync();

            if (snapshot.Exists)
                dictionary = snapshot.ToDictionary();
        }

        #endregion

        #region Get All Document or Collection

        public List<Dictionary<string, object>> GetAllDocumentData(params string[] name)
        {
            Query allCollectionsQuery = GetCollectionReference(name[0], "", "");
            DocumentReference documentReference = null;
            int i;

            for (i = 0; i < name.Length / 2; i++)
                if (name.Length >= 2)
                    documentReference = GetDocumentReference(name[i], name[i + 1]);

            if (name.Length > 2)
                if (documentReference != null)
                    allCollectionsQuery = documentReference.Collection(name[name.Length - 1]);

            if (allCollectionsQuery == null) return null;

            allCollectionsQuery.GetSnapshotAsync().Wait();
            var allCollectionQuerySnapshot = allCollectionsQuery.GetSnapshotAsync().Result;

            return allCollectionQuerySnapshot.Documents.Where(documentSnapshot => documentSnapshot.Exists)
                .Where(documentSnapshot => documentSnapshot.ToDictionary() != null)
                .Select(documentSnapshot => documentSnapshot.ToDictionary()).ToList();
        }

        public List<TEntity> GetAllDocumentData<TEntity>(params string[] name) where TEntity : class
        {
            Query allCollectionsQuery = GetCollectionReference(name[0], "", "");
            DocumentReference documentReference = null;

            for (var i = 0; i < name.Length / 2; i++)
                if (name.Length >= 2)
                    documentReference = GetDocumentReference(name[i], name[i + 1]);

            if (name.Length > 2)
                if (documentReference != null)
                    allCollectionsQuery = documentReference.Collection(name[name.Length - 1]);

            if (allCollectionsQuery == null) return null;

            allCollectionsQuery.GetSnapshotAsync().Wait();
            var allCollectionQuerySnapshot = allCollectionsQuery.GetSnapshotAsync().Result;

            return allCollectionQuerySnapshot.Documents.Where(documentSnapshot => documentSnapshot.Exists)
                .Select(documentSnapshot => documentSnapshot.ConvertTo<TEntity>()).ToList();
        }

        public List<string> GetAllDocumentId(params string[] name)
        {
            Query allCollectionsQuery = GetCollectionReference(name[0], "", "");
            DocumentReference documentReference = null;
            var documentIdList = new List<string>();

            for (var i = 0; i < name.Length / 2; i++)
                if (name.Length >= 2)
                    documentReference = GetDocumentReference(name[i], name[i + 1]);

            if (name.Length > 2)
                if (documentReference != null)
                    allCollectionsQuery = documentReference.Collection(name[name.Length - 1]);

            if (allCollectionsQuery == null) return null;

            allCollectionsQuery.GetSnapshotAsync().Wait();
            var allCollectionQuerySnapshot = allCollectionsQuery.GetSnapshotAsync().Result;

            foreach (var documentSnapshot in allCollectionQuerySnapshot.Documents)
            {
                if (!documentSnapshot.Exists) continue;

                documentIdList.Add(documentSnapshot.Id);
            }

            return documentIdList;
        }

        public async Task GetCollections(List<CollectionReference> collectionReference, params string[] name)
        {
            DocumentReference documentReference = null;

            for (var i = 0; i < name.Length / 2; i++)
                documentReference = GetDocumentReference(name[i], name[i + 1]);

            if (documentReference == null) return;

            IList<CollectionReference> subCollections = await documentReference.ListCollectionsAsync().ToList();

            collectionReference.AddRange(subCollections);
        }

        #endregion

        #endregion

        #region Query

        public async Task FindDocument(string documentId, params string[] name)
        {
            CollectionReference collectionReference = null;

            int i;

            for (i = 0; i < name.Length / 2; i++)
                collectionReference = name.Length <= 2
                    ? GetCollectionReference(name[i], "", "")
                    : GetCollectionReference(name[i], name[i + 1], name[i + 2]);

            if (collectionReference == null) return;

            var documentSnapshot = await collectionReference.Document(name[name.Length - 1]).GetSnapshotAsync();

            if (documentSnapshot.Exists)
                documentId = documentSnapshot.Id;
        }

        #endregion
    }
}
