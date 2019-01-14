package com.example.newu.ticketchecker;

import android.support.annotation.NonNull;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Toast;

import com.google.android.gms.tasks.OnFailureListener;
import com.google.android.gms.tasks.OnSuccessListener;
import com.google.firebase.firestore.CollectionReference;
import com.google.firebase.firestore.DocumentSnapshot;
import com.google.firebase.firestore.FirebaseFirestore;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;

public class train_Dy_List extends AppCompatActivity {
    private static final String KEY="ROUTE";
    Map<String,trainRouteStations>Rt=new HashMap<String ,trainRouteStations>();
    trainRouteStations RtStn= new trainRouteStations();

    //Map<String,String>RtStn=new HashMap<String, String>();
    int noofstops;
    private FirebaseFirestore dbb = FirebaseFirestore.getInstance();
    private FirebaseFirestore dbb1=FirebaseFirestore.getInstance();
    private CollectionReference train_details = dbb.collection("ROOT/TRAIN_DETAILS/12073");
    private CollectionReference station_details = dbb1.collection("ROOT/STATIONS/STN_DETAILS");
    //HashMap<String, HashMap<String, String>> RO_TE = new HashMap<String, HashMap<String,String>>();
    //HashMap<String, HashMap<String, String>> ROUTE = new HashMap<String, HashMap<String,String>>();
    //Map<String,Map>ROUTE=new HashMap<String, Map>();
    //HashMap<String,Map>RO_TE=new HashMap<String, Map>();


    ArrayList<Info> info_list;
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
                    trainNode note = documentSnapshot.toObject(trainNode.class);
                    Rt = note.getROUTE();
                    noofstops = note.getNO_OF_STATIONS();
                    for (int i = 0; i <= noofstops; i++) {
                        String code, stnpincode, stn;
                        RtStn = Rt.get(i);
                        code = RtStn.getSTN_CODE();
                        station_details.document(code).get().addOnSuccessListener(new OnSuccessListener<DocumentSnapshot>() {
                            @Override
                            public void onSuccess(DocumentSnapshot documentSnapshot) {
                                if (documentSnapshot.exists()) {
                                    stationDetails stationobject = documentSnapshot.toObject(stationDetails.class);
                                    Info ob = new Info(stationobject.getSTN_NAME(), stationobject.getSTN_CODE(), stationobject.getSTN_PIN());
                                    info_list.add(ob);

                                } else {
                                    Toast.makeText(train_Dy_List.this, "STATION LIST DOESNOT EXISTS", Toast.LENGTH_LONG).show();
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
                    Toast.makeText(train_Dy_List.this,"Not exists",Toast.LENGTH_LONG).show();
                }
            }
        }).addOnFailureListener(new OnFailureListener() {
            @Override
            public void onFailure(@NonNull Exception e) {
                Toast.makeText(train_Dy_List.this,"ERROR",Toast.LENGTH_LONG).show();

            }
        });
    }
}