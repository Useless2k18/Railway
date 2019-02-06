package com.example.newu.ticketchecker;

import android.Manifest;
import android.content.Context;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.location.Address;
import android.location.Geocoder;
import android.support.annotation.NonNull;
import android.support.v4.app.ActivityCompat;
import android.support.v4.content.ContextCompat;
import android.support.v7.app.AlertDialog;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.view.Window;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import com.google.android.gms.tasks.OnCompleteListener;
import com.google.android.gms.tasks.Task;
import com.google.firebase.auth.FirebaseAuth;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;
import com.google.firebase.iid.FirebaseInstanceId;
import com.google.firebase.iid.InstanceIdResult;

import java.io.IOException;
import java.util.List;
import java.util.Locale;

public class trainsList extends AppCompatActivity {
    public static final String NODE_USERS="users";
    private FirebaseAuth authenticationObject;
    Button logout;

    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_trains_list);
        authenticationObject =FirebaseAuth.getInstance();
        logout = (Button)findViewById(R.id.logout);

        FirebaseInstanceId.getInstance().getInstanceId().addOnCompleteListener(new OnCompleteListener<InstanceIdResult>() {
            @Override
            public void onComplete(@NonNull Task<InstanceIdResult> task) {
                if (task.isSuccessful()) {

                    String token = task.getResult().getToken();
                    saveToken(token);
                    //txtvw.setText("TOKEN:"+token);
                } else {
                    //txtvw.setText(task.getException().getMessage());

                }
            }


        });

        logout.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                authenticationObject.signOut();
                finish();
                startActivity(new Intent(trainsList.this,loginForm.class));
            }
        });

    }

    @Override
    protected void onStart() {
        super.onStart();
        if(authenticationObject.getCurrentUser()==null) {
            finish();
            Intent intent = new Intent(this,loginForm.class);
            intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK | Intent.FLAG_ACTIVITY_CLEAR_TASK);
            startActivity(intent);
        }
    }

    @Override
    public void onBackPressed() {
        if(authenticationObject.getCurrentUser()!=null)
        {
            AlertDialog.Builder a_builder = new AlertDialog.Builder(trainsList.this);
            View view = getLayoutInflater().inflate(R.layout.dialog_custom,null);
            Button yes = (Button)view.findViewById(R.id.yes);
            Button no = (Button)view.findViewById(R.id.no);
            no.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    authenticationObject.signOut();
                    Toast.makeText(trainsList.this, "NOT POSSIBLE!!! REVERTING...", Toast.LENGTH_SHORT).show();
                    finish();
                }
            });
            yes.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    Intent i = new Intent(trainsList.this, trainsList.class);
                    startActivity(i);
                }
            });
            a_builder.setView(view);
            AlertDialog dialog = a_builder.create();
            dialog.setCancelable(false);
            dialog.requestWindowFeature(Window.FEATURE_NO_TITLE);
            dialog.setContentView(R.layout.dialog_custom);
            dialog.getWindow().setBackgroundDrawable(new ColorDrawable(Color.TRANSPARENT));
            view = getWindow().getDecorView();
            view.setBackgroundResource(android.R.color.transparent);
            dialog.show();
        }
    }

    private void saveToken(String token)
    {
        String email= authenticationObject.getCurrentUser().getEmail();
        user usr = new user(email,token);
        DatabaseReference dbusers= FirebaseDatabase.getInstance().getReference(NODE_USERS);
        dbusers.child(authenticationObject.getCurrentUser().getUid()).setValue(usr).addOnCompleteListener(new OnCompleteListener<Void>() {
            @Override
            public void onComplete(@NonNull Task<Void> task) {
                if (task.isSuccessful())
                {
                    Toast.makeText(trainsList.this, "Token Saved", Toast.LENGTH_SHORT).show();
                }
            }
        });
    }
}
