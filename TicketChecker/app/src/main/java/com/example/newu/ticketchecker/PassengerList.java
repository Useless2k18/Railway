package com.example.newu.ticketchecker;

import android.support.annotation.NonNull;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;

import com.google.android.gms.tasks.OnCompleteListener;
import com.google.android.gms.tasks.Task;
import com.google.firebase.firestore.CollectionReference;
import com.google.firebase.firestore.DocumentReference;
import com.google.firebase.firestore.FirebaseFirestore;
import com.google.firebase.firestore.QueryDocumentSnapshot;
import com.google.firebase.firestore.QuerySnapshot;

public class PassengerList extends AppCompatActivity {
    public FirebaseFirestore passengerDatabaseObject=FirebaseFirestore.getInstance();

    @Override
    protected void onCreate(Bundle savedInstanceState) {

        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_passenger_list);
        FetchPassengerDetails();
    }

    void FetchPassengerDetails()
    {   int trainNo=12073;
        String date="29.04.19";
        CollectionReference passengerDetails=passengerDatabaseObject.collection("Root/Passengers/"+Integer.toString(trainNo)+"/"+date+"PassengerDetails");
                passengerDetails.get()
                .addOnCompleteListener(new OnCompleteListener<QuerySnapshot>() {
                    @Override
                    public void onComplete(@NonNull Task<QuerySnapshot> task) {
                        if (task.isSuccessful()) {
                            for (QueryDocumentSnapshot document : task.getResult()) {
                                 document.get("pnrNo");
                            }
                        } else {
                            //Log.d(TAG, "Error getting documents: ", task.getException());
                        }
                    }
                });
    }
}
