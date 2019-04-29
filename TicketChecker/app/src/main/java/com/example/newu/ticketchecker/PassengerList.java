package com.example.newu.ticketchecker;

import android.database.sqlite.SQLiteDatabase;
import android.support.annotation.NonNull;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.widget.TextView;

import com.google.android.gms.tasks.OnCompleteListener;
import com.google.android.gms.tasks.Task;
import com.google.firebase.firestore.CollectionReference;
import com.google.firebase.firestore.DocumentReference;
import com.google.firebase.firestore.FirebaseFirestore;
import com.google.firebase.firestore.QueryDocumentSnapshot;
import com.google.firebase.firestore.QuerySnapshot;

import java.util.List;
import java.util.Map;

import io.opencensus.tags.Tag;

public class PassengerList extends AppCompatActivity {
    public FirebaseFirestore passengerDatabaseObject=FirebaseFirestore.getInstance();
    TextView textVieww;
    SQLiteDatabase passengerDatabase;
    DatabaseHelper passengerDb;

    @Override
    protected void onCreate(Bundle savedInstanceState) {


        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_train_firestore_to_sql);
        textVieww = (TextView)findViewById(R.id.textView11);
        FetchPassengerDetails();
    }

    void FetchPassengerDetails()
    {   int trainNo=12073;
        String date="29.04.19";
        CollectionReference passengerDetails=passengerDatabaseObject.collection("Root/Passengers/"+Integer.toString(trainNo)+"/"+date+"/PassengerDetails");
                passengerDetails.get().addOnCompleteListener(new OnCompleteListener<QuerySnapshot>() {
                    @Override
                    public void onComplete(@NonNull Task<QuerySnapshot> task) {
                        if (task.isSuccessful()) {

                            for (QueryDocumentSnapshot document : task.getResult()) {
                                String pnr=(String)document.get("pnrNo");
                                String boardingStation=(String)document.get("boardingStation");
                                String destinationStation=(String)document.get("destinationStation");
                                String classOfTravel=(String)document.get("class");

                                List<Map<String, String>> route;
                                route=(List<Map<String, String>>)document.get("passengerDetails");
                                //int i=0;
                                for (Map<String, String> map :route) {
                                    //textView.setText(map.get("arrivalTime"));
                                    passengerDb.insertPassengerData(passengerDatabase,pnr,map.get("firstName"),map.get("lastName"),boardingStation,destinationStation,map.get("coach"),map.get("status"),map.get("seat"),classOfTravel,map.get("age"),map.get("waitingListNo"));
                                }


                            }
                        } else
                            {
                            //Log.d(TAG, "Error getting documents: ", task.getException());
                        }
                    }
                });
    }
}
