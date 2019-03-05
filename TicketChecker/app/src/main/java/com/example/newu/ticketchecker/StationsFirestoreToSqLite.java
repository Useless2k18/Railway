package com.example.newu.ticketchecker;

import android.util.Log;
import android.widget.Toast;

import com.google.android.gms.tasks.OnCompleteListener;
import com.google.android.gms.tasks.Task;
import com.google.firebase.database.core.Tag;
import com.google.firebase.firestore.CollectionReference;
import com.google.firebase.firestore.DocumentReference;
import com.google.firebase.firestore.DocumentSnapshot;
import com.google.firebase.firestore.EventListener;
import com.google.firebase.firestore.FirebaseFirestore;
import com.google.firebase.firestore.FirebaseFirestoreException;
import com.google.firebase.firestore.QueryDocumentSnapshot;
import com.google.firebase.firestore.QuerySnapshot;

import javax.annotation.Nonnull;
import javax.annotation.Nullable;

import static android.content.ContentValues.TAG;

public class StationsFirestoreToSqLite {
    private StationZone[] stationZones;
    private FirebaseFirestore stationsDatabaseObject = FirebaseFirestore.getInstance();
    private DocumentReference stations = stationsDatabaseObject.document("ROOT/Stations"), zone;

    private String[] divisionList;
    private StationZone[] stationDivision;

    private CollectionReference stationDetails = stationsDatabaseObject.collection("ROOT/Stations/StationDetails"),division;

    public void StationsFirestoreToSqLite() {

FetchStations();

}
public void FetchStations()
{
    stations.addSnapshotListener(this,new EventListener<DocumentSnapshot>() {
        @Override
        public void onEvent(@Nullable DocumentSnapshot documentSnapshot, @Nullable FirebaseFirestoreException e) {
            if(e!=null)
            {
                Toast.makeText(StationsFirestoreToSqLite.this,"ERROR OCCURED",Toast.LENGTH_LONG).show();
                return;
            }
            if(documentSnapshot.exists()) {
                int noOfZone = (int) documentSnapshot.get("noOfDivision");
                String[] zoneLists = (String[]) documentSnapshot.get("zoneList");
                for (int j = 0; j < noOfZone; j++) {

                    division = zone.collection("ROOT/Stations/StationDetails/" + zoneLists[j]);
                    division
                            .get()
                            .addOnCompleteListener(new OnCompleteListener<QuerySnapshot>() {
                                @Override
                                public void onComplete(@Nonnull Task<QuerySnapshot> task) {
                                    if (task.isSuccessful()) {
                                        for (QueryDocumentSnapshot document : task.getResult()) {
                                            StationInfo newStation=document.toObject(StationInfo.class);


                                        }
                                    } else {
                                        Log.d(TAG, "Error getting documents: ", task.getException());
                                    }
                                }
                            });

                }
            }
            else
            {
                Toast.makeText(StationsFirestoreToSqLite.this,"NO DATA",Toast.LENGTH_LONG).show();
            }
        }
    });
}
}


