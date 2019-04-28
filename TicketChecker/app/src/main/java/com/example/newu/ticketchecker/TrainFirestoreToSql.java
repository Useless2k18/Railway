package com.example.newu.ticketchecker;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.widget.TextView;
import android.widget.Toast;

import com.google.firebase.database.core.Tag;
import com.google.firebase.firestore.DocumentReference;
import com.google.firebase.firestore.DocumentSnapshot;
import com.google.firebase.firestore.EventListener;
import com.google.firebase.firestore.FirebaseFirestore;
import com.google.firebase.firestore.FirebaseFirestoreException;

import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.Map;

import javax.annotation.Nullable;

public class TrainFirestoreToSql extends AppCompatActivity {
    public FirebaseFirestore trainDatabaseObject=FirebaseFirestore.getInstance();
    int trainNo=12073;
    TextView textView;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_train_firestore_to_sql);
        textView = findViewById(R.id.textView11);
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
                    List<Map<String, String>> route; // this is what you have already
                    route=(List<Map<String, String>>)documentSnapshot.get("route");

                    for (Map<String, String> map :route) {
                        textView.setText(map.get("arrivalTime"));
                        }

                    /*Map<String,String> trainRoute;
                    List<Map<String,String>> route ;
                    route=(List<Map<String, String>>)documentSnapshot.get("route");
                    Iterator iterator =route.iterator();
                    while(iterator.hasNext())
                    {
                        trainRoute=iterator.

                    }*/
                    //for (Map<String,String> train: route) {

                        //textView.setText(train.getValue());
                   // }

                }
            }
        });
    }
}
