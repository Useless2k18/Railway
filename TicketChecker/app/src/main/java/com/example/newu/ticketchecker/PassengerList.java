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
    //TextView textVieww;
    SQLiteDatabase passengerDatabase;
    DatabaseHelper passengerDb;

    @Override
    protected void onCreate(Bundle savedInstanceState) {


        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_passenger_list);
        //textVieww = (TextView)findViewById(R.id.textView11);
        passengerDb = new DatabaseHelper(this);
        passengerDatabase= passengerDb.getReadableDatabase();
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
                                //String name=new String();

                                List<Map<String, String>> passenger;
                                passenger=(List<Map<String, String>>)document.get("passengerDetails");
                                //int i=0;
                                for (Map<String, String> passengerList :passenger) {
                                    //textVieww.setText(passengerList.get(pnr));
                                    //name=passengerList.get("firstName");
                                   passengerDb.insertPassengerData(passengerDatabase,pnr,passengerList.get("firstName"),passengerList.get("lastName"),boardingStation,destinationStation,passengerList.get("coach"),passengerList.get("status"),passengerList.get("seatNo"),classOfTravel,passengerList.get("age"),passengerList.get("waitingListNo"));
                                }
                               //passengerDb.insertPassengerData(passengerDatabase,pnr,"bhaskar","goswami",boardingStation,destinationStation,"CNF", "s30","conf","234","fjhf","123");

                            }
                        }
                        else
                            {
                            //Log.d(TAG, "Error getting documents: ", task.getException());
                        }
                    }
                });
    }
}
