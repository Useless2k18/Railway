package com.example.newu.ticketchecker;

import com.google.firebase.firestore.CollectionReference;
import com.google.firebase.firestore.DocumentReference;
import com.google.firebase.firestore.DocumentSnapshot;
import com.google.firebase.firestore.EventListener;
import com.google.firebase.firestore.FirebaseFirestore;
import com.google.firebase.firestore.FirebaseFirestoreException;

import javax.annotation.Nullable;

public class StationsFirestoreToSqLite {
    private StationZone [] stationZones ;
    private FirebaseFirestore stationsDatabaseObject = FirebaseFirestore.getInstance();
    private DocumentReference stations=stationsDatabaseObject.document("ROOT/Stations"),division;
    private DocumentSnapshot ds;
    private String [] divisionList ;
    private StationZone [] stationDivision;
    private CollectionReference stationDetails= stationsDatabaseObject.collection("ROOT/Stations/StationDetails");

    public StationsFirestoreToSqLite() {
        ds=stations.addSnapshotListener(this,new EventListener<DocumentSnapshot>() {
            @Override
            public void onEvent(@Nullable DocumentSnapshot documentSnapshot, @Nullable FirebaseFirestoreException e) {
                if (e != null) {
                    e.printStackTrace();
                }
                if (documentSnapshot.exists()) {
                    String[] temp = (String[]) documentSnapshot.get("divisionList");
                    divisionList = new String[temp.length];
                    stationDivision = new StationZone[temp.length];
                    for (int i = 0; i < temp.length; i++) {
                        divisionList[i] = temp[i];

                    }
                }
            }

        })
    }



    public void getZoneDocument()
    {for(int i=0;i < divisionList.length;i++)
    {
        division=stationsDatabaseObject.document("ROOT/Stations/StationDetails"+divisionList[i]);
        ds.toObject(StationZone.class);
    }

    }
}