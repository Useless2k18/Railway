package com.example.newu.ticketchecker;

import android.app.ProgressDialog;
import android.content.Intent;
import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.support.annotation.NonNull;
import android.support.v7.app.AlertDialog;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.view.Window;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import com.google.android.gms.tasks.OnCompleteListener;
import com.google.android.gms.tasks.Task;
import com.google.firebase.auth.AuthResult;
import com.google.firebase.auth.FirebaseAuth;
import com.google.firebase.firestore.DocumentReference;
import com.google.firebase.firestore.DocumentSnapshot;
import com.google.firebase.firestore.EventListener;
import com.google.firebase.firestore.FirebaseFirestore;
import com.google.firebase.firestore.FirebaseFirestoreException;

import javax.annotation.Nullable;

public class TteFirstLogin extends AppCompatActivity {
    public FirebaseFirestore tteDatabaseObject=FirebaseFirestore.getInstance();
    Button login;
    EditText tteid, pass;
    TextView signup;
    ProgressDialog progressDialog;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login_form);
        tteid = (EditText) findViewById(R.id.tteid);
        pass = (EditText) findViewById(R.id.password);
        login = (Button) findViewById(R.id.Login);
        signup = (TextView) findViewById(R.id.SignUp);
        progressDialog = new ProgressDialog(this);


        login.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String tteId, pas;

                tteId = tteid.getText().toString().trim();
                pas = pass.getText().toString().trim();


                if (tteId.isEmpty()) {
                    tteid.setError("UID required");
                    tteid.requestFocus();
                    return;
                }
                if (pas.isEmpty()) {
                    pass.setError("password required");
                    pass.requestFocus();
                    return;
                }
                    CreateTteDocumentUrl(tteId, pas);
            }
        });
        signup.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent i = new Intent(TteFirstLogin.this,TteSignUp.class);
                startActivity(i);
            }
        });
    }

    public void CreateTteDocumentUrl(String tteId,String password)
    {
        String employeeCode, zoneCode, divsionCode, groupCode, tteZone, tteDivision;
        groupCode=Character.toString(tteId.charAt(0))+Character.toString((tteId.charAt(1)));
        employeeCode=Character.toString(tteId.charAt(2))+Character.toString(tteId.charAt(3));
        zoneCode=Character.toString(tteId.charAt(4))+Character.toString(tteId.charAt(5));
        divsionCode=Character.toString(tteId.charAt(6))+Character.toString(tteId.charAt(7));
        tteZone=new String();
        tteDivision=new String();
        switch (zoneCode){
            case "00":
                tteZone="CR";
                break;
            case "01":
                tteZone="ECR";
                break;
            case "02":
                tteZone="ECoR";
                break;
            case "03":
                tteZone="ER";
                break;
            case "04":
                tteZone="NCR";
                break;
            case "05":
                tteZone="NER";
                break;
            case "06":
                tteZone="NFR";
                break;
            case "07":
                tteZone="NR";
                break;
            case "08":
                tteZone="NWR";
                break;
            case "09":
                tteZone="SCR";
                break;
            case "10":
                tteZone="SECR";
                break;
            case "11":
                tteZone="SER";
                break;
            case "12":
                tteZone="SR";
                break;

            case "13":
                tteZone="SWR";
                break;
            case "14":
                tteZone="WCR";
                break;
            case "15":
                tteZone="WR";
                break;
        }
        if(tteZone=="CR"){
            switch (divsionCode){
                case "00":
                    tteDivision="Mumbai";
                    break;
                case "01":
                    tteDivision="Bhusawal";
                    break;
                case "02":
                    tteDivision="Pune";
                    break;
                case "03":
                    tteDivision="Solapur";
                    break;
                case "04":
                    tteDivision="Nagpur";
                    break;



            }
        }
        else if(tteZone=="ECR"){
            switch (divsionCode){
                case "00":
                    tteDivision="Danapur";
                    break;
                case "01":
                    tteDivision="Dhanbad";
                    break;
                case "02":
                    tteDivision="Mughalsarai";
                    break;
                case "03":
                    tteDivision="Samastipur";
                    break;
                case "04":
                    tteDivision="Sonpur";
                    break;


            }
        }
        else if(tteZone=="ECoR"){
            switch (divsionCode){
                case "00":
                    tteDivision="KhurdaRoad";
                    break;
                case "01":
                    tteDivision="Sambalpur";
                    break;
                case "02":
                    tteDivision="Rayagada";
                    break;


            }

        }
        else if (tteZone=="ER")
        {
            switch (divsionCode){
                case "00":
                    tteDivision="Howrah";
                    break;
                case "01":
                    tteDivision="Sealdah";
                    break;
                case "02":
                    tteDivision="Asansol";
                    break;
                case "03":
                    tteDivision="Malda";
                    break;

            }
        }
        else if(tteZone=="NCR"){
            switch(divsionCode)
            {
                case "00":
                    tteDivision="Allahabad";
                    break;
                case "01":
                    tteDivision="Agra";
                    break;
                case "02":
                    tteDivision="Jhansi";
                    break;

            }
        }
        else if(tteZone=="NER")
        {
            switch(divsionCode){
                case "00":
                    tteDivision="Izzatnagar";
                    break;
                case "01":
                    tteDivision="Lucknow NER";
                    break;
                case "02":
                    tteDivision="Varanasi";
                    break;

            }
        }
        else if(tteZone=="NFR")
        {
            switch(divsionCode){
                case "00":
                    tteDivision="Alipurduar";
                    break;
                case "01":
                    tteDivision="Katihar";
                    break;
                case "02":
                    tteDivision="Rangiya";
                    break;
                case "03":
                    tteDivision="Lumding";
                    break;
                case "04":
                    tteDivision="Tinsukia";
                    break;


            }
        }
        else if(tteZone=="NR")
        {
            switch(divsionCode){
                case "00":
                    tteDivision="Delhi";
                    break;
                case "01":
                    tteDivision="Ambala";
                    break;
                case "02":
                    tteDivision="Firozpur";
                    break;
                case "03":
                    tteDivision="Lucknow NR";
                    break;
                case "04":
                    tteDivision="Moradabad";
                    break;


            }
        }
        else if (tteZone=="NWR")
        {switch (divsionCode){
            case "00":
                tteDivision="Jaipur";
                break;
            case "01":
                tteDivision="Ajmer";
                break;
            case "02":
                tteDivision="Bikaner";
                break;
            case "03":
                tteDivision="Jodhpur";
                break;

        }

        }
        else if (tteZone=="SECR")
        {switch (divsionCode){
            case "00":
                tteDivision="Bilaspur";
                break;
            case "01":
                tteDivision="Raipur";
                break;
            case "02":
                tteDivision="Nagpur SEC";
                break;


        }

        }
        else if (tteZone=="SER")
        {switch (divsionCode){
            case "00":
                tteDivision="Secundrabad";
                break;
            case "01":
                tteDivision="Hyderabad";
                break;
            case "02":
                tteDivision="Nanded";
                break;


        }

        }
        else if (tteZone=="SR")
        {switch (divsionCode){
            case "00":
                tteDivision="Chennai";
                break;
            case "01":
                tteDivision="Tiruchirapalli";
                break;
            case "02":
                tteDivision="Madurai";
                break;
            case "03":
                tteDivision="Palakkad";
                break;
            case "04":
                tteDivision="Salem";
            case "05":
                tteDivision="Thiruvananthapuram";

        }

        }
        else if (tteZone=="SWR")
        {switch (divsionCode){
            case "00":
                tteDivision="Hubballi";
                break;
            case "01":
                tteDivision="Bengaluru";
                break;
            case "02":
                tteDivision="Mysuru";
                break;


        }

        }
        else if (tteZone=="WCR")
        {switch (divsionCode){
            case "00":
                tteDivision="Jabalpur";
                break;
            case "01":
                tteDivision="Bhopal";
                break;
            case "02":
                tteDivision="Kota";
                break;


        }

        }
        else if (tteZone=="WR") {
            switch (divsionCode) {
                case "00":
                    tteDivision = "MumbaiWR";
                    break;
                case "01":
                    tteDivision = "Ratlam";
                    break;
                case "02":
                    tteDivision = "Ahmedabad";
                    break;
                case "03":
                    tteDivision = "Rajkot";
                    break;
                case "04":
                    tteDivision = "Bhavnagar";
                case "05":
                    tteDivision = "Vadodara";

            }
        }


        String tteUrl="Root/Employee/"+tteZone+"/"+tteDivision+"/Tte";

        FetchTte(tteUrl,tteId,password);

    }
    void FetchTte(String TteUrl, String ID, final String adminPassword)
    {
        //tteidsh.setText(TteUrl+"/"+ID);
        DocumentReference tteCollection=tteDatabaseObject.document(TteUrl+"/"+ID);
        tteCollection.addSnapshotListener(this, new EventListener<DocumentSnapshot>() {
            @Override
            public void onEvent(@Nullable DocumentSnapshot documentSnapshot, @Nullable FirebaseFirestoreException e) {
                if (e != null) {
                    Toast.makeText(TteFirstLogin.this, "EXCEPTION ENCOUNTERED", Toast.LENGTH_LONG).show();
                    return;
                }
                if (documentSnapshot.exists())
                {
                    String userPassword =(String)documentSnapshot.get("password");
                    if(userPassword.equals(adminPassword))
                    {
                        Intent i = new Intent(TteFirstLogin.this,TteSignUp.class);
                        startActivity(i);
                    }
                    else{
                        Toast.makeText(TteFirstLogin.this, "GIVE THE PASSORD GIVEN BY ADMIN", Toast.LENGTH_LONG).show();
                    }
                    //tteidShow.setText(Name);
                }
                else
                {
                    Toast.makeText(TteFirstLogin.this, "USER DOESN'T EXISTS CONTACT ADMIN", Toast.LENGTH_LONG).show();

                }
            }
        });

    }
    }



