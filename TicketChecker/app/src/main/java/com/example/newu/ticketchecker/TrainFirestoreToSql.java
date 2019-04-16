package com.example.newu.ticketchecker;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;

import com.google.firebase.database.core.Tag;
import com.google.firebase.firestore.DocumentReference;
import com.google.firebase.firestore.FirebaseFirestore;

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
        DocumentReference trainDetails=trainDatabaseObject.document("TrainDetails/"+documentAddress+"/"+Integer.toString(trainNo));
        //trainDetails.addSnapshotListener()
    }
}
