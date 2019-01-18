package com.example.newu.ticketchecker;

import android.support.annotation.NonNull;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.widget.Toast;

import com.google.android.gms.tasks.OnFailureListener;
import com.google.android.gms.tasks.OnSuccessListener;
import com.google.firebase.firestore.CollectionReference;
import com.google.firebase.firestore.DocumentSnapshot;
import com.google.firebase.firestore.FirebaseFirestore;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;

public class DynamicStationsList extends AppCompatActivity {
    private static final String KEY="ROUTE";
    Map<String,TrainRouteStations>Rt=new HashMap<String ,TrainRouteStations>();
    TrainRouteStations RtStn= new TrainRouteStations();

    //Map<String,String>RtStn=new HashMap<String, String>();
    int noOfStops;
    private FirebaseFirestore dbb = FirebaseFirestore.getInstance();
    private FirebaseFirestore dbb1=FirebaseFirestore.getInstance();
    private CollectionReference train_details = dbb.collection("ROOT/TRAIN_DETAILS/12073");
    private CollectionReference station_details = dbb1.collection("ROOT/STATIONS/STN_DETAILS");
    //HashMap<String, HashMap<String, String>> RO_TE = new HashMap<String, HashMap<String,String>>();
    //HashMap<String, HashMap<String, String>> ROUTE = new HashMap<String, HashMap<String,String>>();
    //Map<String,Map>ROUTE=new HashMap<String, Map>();
    //HashMap<String,Map>RO_TE=new HashMap<String, Map>();


    ArrayList<StationInfo> info_list;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_train__dy__list);

    }

    @Override
    protected void onStart() {
        super.onStart();

    }



    //FETCH DATA FROM DATABASE
    public void download()
    {
        train_details.document("12073").get().addOnSuccessListener(new OnSuccessListener<DocumentSnapshot>() {
            @Override
            public void onSuccess(DocumentSnapshot documentSnapshot) {
                if(documentSnapshot.exists()) {
                    TrainDetails note = documentSnapshot.toObject(TrainDetails.class);
                    Rt = note.getROUTE();
                    noOfStops = note.getNoOfStations();
                    for (int i = 0; i <= noOfStops; i++) {
                        String code, stnpincode, stn;
                        RtStn = Rt.get(i);
                        code = RtStn.getStationCode();
                        station_details.document(code).get().addOnSuccessListener(new OnSuccessListener<DocumentSnapshot>() {
                            @Override
                            public void onSuccess(DocumentSnapshot documentSnapshot) {
                                if (documentSnapshot.exists()) {
                                    StationDetails stationobject = documentSnapshot.toObject(StationDetails.class);
                                    StationInfo ob = new StationInfo(stationobject.getStationName(), stationobject.getStationCode(), stationobject.getStationPin());
                                    info_list.add(ob);

                                } else {
                                    Toast.makeText(DynamicStationsList.this, "STATION LIST DOESNOT EXISTS", Toast.LENGTH_LONG).show();
                                }
                                //String description=note.getDescription();
                                // String title=documentSnapshot.getString(KEY_TITLE);
                                //String description=documentSnapshot.getString(KEY_DESCRIPTION);

                                //Map<String,Object> note =documentSnapshot.getData()
                            }
                        }).addOnFailureListener(new OnFailureListener() {
                            @Override
                            public void onFailure(@NonNull Exception e) {

                            }
                        });
                    }
                }

                else
                {
                    Toast.makeText(DynamicStationsList.this,"Not exists",Toast.LENGTH_LONG).show();
                }
            }
        }).addOnFailureListener(new OnFailureListener() {
            @Override
            public void onFailure(@NonNull Exception e) {
                Toast.makeText(DynamicStationsList.this,"ERROR",Toast.LENGTH_LONG).show();

            }
        });
    }
}