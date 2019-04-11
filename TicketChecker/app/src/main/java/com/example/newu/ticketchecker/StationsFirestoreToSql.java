package com.example.newu.ticketchecker;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.database.sqlite.SQLiteDatabase;
import android.util.Log;
import android.widget.TextView;
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

import java.sql.Array;
import java.util.Arrays;
import java.util.List;

import javax.annotation.Nonnull;
import javax.annotation.Nullable;


public class StationsFirestoreToSql extends AppCompatActivity implements demoInterface {
    private StationsDocument[] stationsDocuments;
    //static String document;
    SQLiteDatabase db;
    DatabaseHelper mydb;
    public FirebaseFirestore stationsDatabaseObject = FirebaseFirestore.getInstance();
    public FirebaseFirestore getStationsDatabaseObject1 = FirebaseFirestore.getInstance();
    public FirebaseFirestore getStationsDatabaseObject2 = FirebaseFirestore.getInstance();

    public DocumentReference stations = stationsDatabaseObject.document("Root/Stations"), zone;

    private String[] divisionList;
    private StationsDocument[] stationDivision;

    public CollectionReference stationDetails, division;

    TextView textView;
    demoInterface demo;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        setContentView(R.layout.activity_stations_firestore_to_sql);
        mydb = new DatabaseHelper(this);
        db = mydb.getReadableDatabase();
        //mydb.insertStationData(db, "HWH", "HOWRAH", 700009);
        textView = findViewById(R.id.textView11);
        FetchStations();
        demo = this;


    }
    // private long l;
    //private List<String> lst;
    //public StationsFirestoreToSql s;

    //public void setPara(long la)
    //{
    //    l=la;
    //lst=ls;
    //}

    /*public long getL() {
        return l;
    }*/

    public void FetchStations() {
        long noOfZones;

        List<String> zoneList;
        //final StationsDocument[] stationsDocument = new StationsDocument[1];
       /*EventListener<DocumentSnapshot> g=new EventListener<DocumentSnapshot>() {
           public long noofZones;
           List<String> zoneList;

           public long getNoofZones() {
               return noofZones;
           }

           public List<String> getZoneList() {
               return zoneList;
           }

           @Override
           public void onEvent(@Nullable DocumentSnapshot documentSnapshot, @Nullable FirebaseFirestoreException e) {
               if (e != null) {
                   Toast.makeText(StationsFirestoreToSql.this, "EXCEPTION ENCOUNTERED", Toast.LENGTH_LONG).show();
                   return;
               }
               if (documentSnapshot.exists()) {
                   long tempNoOfZone = (long) documentSnapshot.get("noOfZone");

                   List<String> tempZoneLists = (List<String>) documentSnapshot.get("zoneList");
                   //textView.setText(String.valueOf(tempNoOfZone)+ "  "+tempZoneLists);

                   //StationsDocument stationsDocument=new StationsDocument();
                   //stationsDocument[0] = documentSnapshot.toObject(StationsDocument.class);
                   //stationsDocument[0].setNoOfZone(tempNoOfZone);
                   //stationsDocument[0].setZoneList(tempZoneLists);
                   //s = new StationsFirestoreToSql();
                   //s.setPara(tempNoOfZone);
                   //document = String.valueOf(stationsDocument[0].getNoOfZone());
                   //textView.setText(String.valueOf(stationsDocument[0].getNoOfZone()));

               } else {
                   Toast.makeText(StationsFirestoreToSql.this, "ERROR FETCHING ZONE DATA", Toast.LENGTH_LONG).show();
               }
           }
       };*/
        //stations.addSnapshotListener(this,g);
        //stations.get();

        stations.addSnapshotListener(this, new EventListener<DocumentSnapshot>() {
            @Override
            public void onEvent(@Nullable DocumentSnapshot documentSnapshot, @Nullable FirebaseFirestoreException e) {
                if (e != null) {
                    Toast.makeText(StationsFirestoreToSql.this, "EXCEPTION ENCOUNTERED", Toast.LENGTH_LONG).show();
                    return;
                }
                if (documentSnapshot.exists()) {
                    long tempNoOfZone = (long) documentSnapshot.get("noOfZone");

                    List<String> tempZoneLists = (List<String>) documentSnapshot.get("zoneList");
                    demo.onSuccess(tempZoneLists, tempNoOfZone);
                    //textView.setText(String.valueOf(tempNoOfZone)+ "  "+tempZoneLists);

                    //StationsDocument stationsDocument = new StationsDocument();
                    // stationsDocument = documentSnapshot.toObject(StationsDocument.class);
                    //stationsDocument.setNoOfZone(tempNoOfZone);
                    //stationsDocument[0].setZoneList(tempZoneLists);
                    //s = new StationsFirestoreToSql();
                    //s.setPara(tempNoOfZone);
                    //document = String.valueOf(stationsDocument[0].getNoOfZone());
                    //textView.setText(String.valueOf(stationsDocument[0].getNoOfZone()));

                } else {
                    Toast.makeText(StationsFirestoreToSql.this, "ERROR FETCHING ZONE DATA", Toast.LENGTH_LONG).show();
                }
            }
        });
        //stations.get("noOfZones");

        //noOfZones= 16;
        // zoneList = Arrays.asList("CR","ECR","ECoR","ER","NCR","NER","NFR","NR","NWR","SCR","SECR","SER","SR","SWR","WCR","WR");
        //Log.v("TAG2", document);
        //System.out.println(noOfZones);

        //textView.setText(String.valueOf(noOfZones));


//        for (int TempJ = 0; TempJ < noOfZones; TempJ++) {
//
//            zone = stationDetails.document(zoneList.get(TempJ));
//            final String zonePath = zoneList.get(TempJ);
//            zone.addSnapshotListener(this, new EventListener<DocumentSnapshot>() {
//                @Override
//                public void onEvent(@Nullable final DocumentSnapshot documentSnapshot1, @Nullable FirebaseFirestoreException e) {
//                    if (e != null) {
//                        Toast.makeText(StationsFirestoreToSql.this, "EXCEPTION ENCOUNTERED FETCHING STATIONS ", Toast.LENGTH_LONG).show();
//                    }
//                    if (documentSnapshot1.exists()) {
//                        long noOfDivision = (long) documentSnapshot1.get("noOfDivision");
//                        final List<String> divisions = (List<String>) documentSnapshot1.get("divisions");
//
//
//
//                        for (int TempK = 0; TempK < noOfDivision; TempK++) {
//                            division = zone.collection("Root/Stations/StationDetails"+zonePath + divisions.get(TempK));
//                            final String divisionPath=divisions.get(TempK);
//                            division
//                                    .get()
//                                    .addOnCompleteListener(new OnCompleteListener<QuerySnapshot>() {
//                                        @Override
//                                        public void onComplete(@Nonnull Task<QuerySnapshot> task) {
//                                            if (task.isSuccessful()) {
//                                                //mydb.insertStationData(db,"HWH","howrah",700009);
//                                               for (QueryDocumentSnapshot document : task.getResult()) {
//                                                    StationInfo newStation = document.toObject(StationInfo.class);
//                                                    textView.setText(newStation.getStationCode());
//
//                                                   // mydb.insertStationData(db, newStation.getStationCode(), newStation.getStationName(), newStation.getStationPincode());
//                                                    //mydb.insertDivisionData(db,divisionPath,newStation.getStationCode());
//                                                    //mydb.insertZoneData(db,zonePath,divisionPath);
//                                                   Log.v("TAG1",newStation.getStationCode());
//                                                }
//                                            } else {
//                                                //Log.i(TAG, "Error getting documents: ", task.getException());
//                                                Toast.makeText(StationsFirestoreToSql.this, "ERROR FETCHING STATIONS", Toast.LENGTH_LONG).show();
//                                            }
//                                        }
//                                    });
//                        }
//
//                    }
//                    else {
//                        Toast.makeText(StationsFirestoreToSql.this, "ERROR FETCHING STATIONS", Toast.LENGTH_LONG).show();
//                    }
//
//
//                }
//            });
//        }
    }

    @Override
    public void onSuccess(final List<String> zoneList, long noOfZones) {
        //Log.d("TAG", zoneList.get(0).toString());
        //textView.setText(zoneList.get(0));
        for (int TempJ = 0; TempJ < noOfZones; TempJ++) {
            //textView.setText("Root/Stations/StationDetails/" + zoneList.get(0));
            zone= getStationsDatabaseObject1.document("Root/Stations/StationDetails/"+zoneList.get(TempJ));
            //zone = stationDetails.document("Root/Stations/StationDetails/"+zoneList.get(TempJ));
          final String zonePath = zoneList.get(TempJ);
          zone.addSnapshotListener(this, new EventListener<DocumentSnapshot>() {
               @Override
              public void onEvent(@Nullable final DocumentSnapshot documentSnapshot1, @Nullable FirebaseFirestoreException e) {
                 if (e != null) {
                      Toast.makeText(StationsFirestoreToSql.this, "EXCEPTION ENCOUNTERED FETCHING STATIONS ", Toast.LENGTH_LONG).show();
                  }
                  if (documentSnapshot1.exists()) {
                      final long noOfDivision = (long)documentSnapshot1.get("noOfDivision");
                      final List<String> divisions = (List<String>) documentSnapshot1.get("divisions");
                     //textView.setText(Long.toString(noOfDivision)+" "+divisions);
                     //System.out.print(Long.toString(noOfDivision)+" "+divisions);
                      Log.d("div",Long.toString(noOfDivision)+" "+divisions );
                      final String zoneName= (String) documentSnapshot1.get("railwayZone");



                     for (int TempK = 0; TempK < noOfDivision; TempK++) {
                         //textView.setText(String.valueOf(TempK));
                         //textView.setText("Root/Stations/StationDetails/"+zonePath +"/"+ divisions.get(TempK));
                         Log.d("divin","Root/Stations/StationDetails/"+zonePath +"/"+ divisions.get(TempK));

                          division = getStationsDatabaseObject2.collection("Root/Stations/StationDetails/"+zonePath +"/"+ divisions.get(TempK));
                         final String divisionPath=divisions.get(TempK);
                          division
                                 .get().addOnCompleteListener(new OnCompleteListener<QuerySnapshot>() {
                                      @Override
                                      public void onComplete(@Nonnull Task<QuerySnapshot> task) {
                                            if (task.isSuccessful()) {
                                                //mydb.insertStationData(db,"HWH","howrah",700009);
                                               for (QueryDocumentSnapshot document : task.getResult()) {
                                                   StationInfo newStation = document.toObject(StationInfo.class);
                                                    //textView.setText(newStation.getStationCode());

                                                   mydb.insertStationData(db, newStation.getStationCode(), newStation.getStationName(), newStation.getStationPincode());
                                                   mydb.insertDivisionData(db,divisionPath,newStation.getStationCode());
                                                   mydb.insertZoneData(db,zonePath,zoneName,divisionPath,noOfDivision);
                                                   Log.d("code",newStation.getStationCode());
                                                }
                                            } else {
                                                //Log.i(TAG, "Error getting documents: ", task.getException());
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
