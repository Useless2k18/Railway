package com.example.newu.ticketchecker;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.widget.Toast;

import com.google.firebase.database.core.Tag;
import com.google.firebase.firestore.DocumentReference;
import com.google.firebase.firestore.DocumentSnapshot;
import com.google.firebase.firestore.EventListener;
import com.google.firebase.firestore.FirebaseFirestore;
import com.google.firebase.firestore.FirebaseFirestoreException;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

import javax.annotation.Nullable;

public class TrainFirestoreToSql extends AppCompatActivity {
    public FirebaseFirestore trainDatabaseObject=FirebaseFirestore.getInstance();
    int trainNo=12073;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_train_firestore_to_sql);
        FetchTrainDetails();
    }
    void FetchTrainDetails()
    {
        int firstDigit=trainNo/10000;
        int j=trainNo/1000;
        int secondDigit=j%10;
        String documentAddress=Integer.toString(firstDigit)+"XXXX"+"/"+"Y"+Integer.toString(secondDigit)+"XXX"+"/"+"Trains";
        Log.d("det","SED :-"+documentAddress);
        DocumentReference trainDetails=trainDatabaseObject.document("Root/TrainDetails/"+documentAddress+"/"+Integer.toString(trainNo));
        trainDetails.addSnapshotListener(this, new EventListener<DocumentSnapshot>() {
            @Override
            public void onEvent(@Nullable DocumentSnapshot documentSnapshot, @Nullable FirebaseFirestoreException e) {
                if (e != null) {
                    Toast.makeText(TrainFirestoreToSql.this, "EXCEPTION ENCOUNTERED", Toast.LENGTH_LONG).show();
                    return;
                }
                if (documentSnapshot.exists()) {

                    List<TrainRouteStations> route ;
                    route=(List<TrainRouteStations>)documentSnapshot.get("route");
                    for (TrainRouteStations tr: route) {
                        Log.d("de",tr.getStationCode());;
                    }

                }
            }
        });
    }
}
