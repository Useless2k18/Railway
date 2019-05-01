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

public class TteFirstLogin extends AppCompatActivity {
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
                String employeeCode,zoneCode,divsionCode,groupCode,tteZone,tteDivision;
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
                groupCode=Character.toString(tteId.charAt(0))+Character.toString((tteId.charAt(1)));
                employeeCode=Character.toString(tteId.charAt(2))+Character.toString(tteId.charAt(3));
                zoneCode=Character.toString(tteId.charAt(4))+Character.toString(tteId.charAt(5));
                divsionCode=Character.toString(tteId.charAt(6))+Character.toString(tteId.charAt(7));
                tteZone=new String();
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
                    switch (divsionCode){}
                }



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
}


