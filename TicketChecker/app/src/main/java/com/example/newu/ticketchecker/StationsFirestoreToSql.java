package com.example.newu.ticketchecker;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.database.sqlite.SQLiteDatabase;
import android.widget.Toast;

import com.google.android.gms.tasks.OnCompleteListener;
import com.google.android.gms.tasks.Task;
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


public class StationsFirestoreToSql extends AppCompatActivity {
    private StationsDocument[] stationsDocuments;
    SQLiteDatabase db;
    DatabaseHelper mydb;
    private FirebaseFirestore stationsDatabaseObject = FirebaseFirestore.getInstance();
    private DocumentReference stations = stationsDatabaseObject.document("Root/Stations"),zone;

    private String[] divisionList;
    private StationsDocument[] stationDivision;

    private CollectionReference stationDetails = stationsDatabaseObject.collection("Root/Stations/StationDetails"),division;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_stations_firestore_to_sql);
        mydb=new DatabaseHelper(this);
        db=mydb.getReadableDatabase();
        FetchStations();


    }
    public void FetchStations()
    {
        long noOfZones;
        String[] zoneList;
        final StationsDocument stationsDocument=new StationsDocument();



        stations.addSnapshotListener(this,new EventListener<DocumentSnapshot>() {
            @Override
            public void onEvent(@Nullable DocumentSnapshot documentSnapshot, @Nullable FirebaseFirestoreException e) {
                if(e!=null)
                {
                    Toast.makeText(StationsFirestoreToSql.this,"EXCEPTION ENCOUNTERED",Toast.LENGTH_LONG).show();
                    return;
                }
                if(documentSnapshot.exists()) {
                    long tempNoOfZone = (long) documentSnapshot.get("noOfZone");
                    String [] tempZoneLists = (String[]) documentSnapshot.get("zoneList");
                    stationsDocument.setNoOfZone(tempNoOfZone);
                    stationsDocument.setZoneList(tempZoneLists);

                }
                else
                {
                    Toast.makeText(StationsFirestoreToSql.this,"ERROR FETCHING ZONE DATA",Toast.LENGTH_LONG).show();
                }
            }
        });
        noOfZones=stationsDocument.getNoOfZone();
        zoneList=stationsDocument.getZoneList();

        for (int TempJ = 0; TempJ < noOfZones; TempJ++) {

            zone = stationDetails.document("Root/Stations/StationDetails/" + zoneList[TempJ]);
            final String zonePath = zoneList[TempJ];
            zone.addSnapshotListener(this, new EventListener<DocumentSnapshot>() {
                @Override
                public void onEvent(@Nullable final DocumentSnapshot documentSnapshot1, @Nullable FirebaseFirestoreException e) {
                    if (e != null) {
                        Toast.makeText(StationsFirestoreToSql.this, "EXCEPTION ENCOUNTERED FETCHING STATIONS ", Toast.LENGTH_LONG).show();
                    }
                    if (documentSnapshot1.exists()) {
                        long noOfDivision = (long) documentSnapshot1.get("noOfDivision");
                        final String[] divisions = (String[]) documentSnapshot1.get("divisions");



                        for (int TempK = 0; TempK < noOfDivision; TempK++) {
                            division = zone.collection("Root/Stations/StationDetails"+zonePath + divisions[TempK]);
                            final String divisionPath=divisions[TempK];
                            division
                                    .get()
                                    .addOnCompleteListener(new OnCompleteListener<QuerySnapshot>() {
                                        @Override
                                        public void onComplete(@Nonnull Task<QuerySnapshot> task) {
                                            if (task.isSuccessful()) {
                                                for (QueryDocumentSnapshot document : task.getResult()) {
                                                    StationInfo newStation = document.toObject(StationInfo.class);

                                                    mydb.insertStationData(db, newStation.getStationCode(), newStation.getStationName(), newStation.getStationPincode());
                                                    mydb.insertDivisionData(db,divisionPath,newStation.getStationCode());
                                                    mydb.insertZoneData(db,zonePath,divisionPath);
                                                }
                                            } else {
                                                //Log.d(TAG, "Error getting documents: ", task.getException());
                                                Toast.makeText(StationsFirestoreToSql.this, "ERROR FETCHING STATIONS", Toast.LENGTH_LONG).show();
                                            }
                                        }
                                    });
                        }

                    }
                    else {
                        Toast.makeText(StationsFirestoreToSql.this, "ERROR FETCHING STATIONS", Toast.LENGTH_LONG).show();
                    }


                }
            });
        }
    }
}
