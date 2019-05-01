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

public class loginForm extends AppCompatActivity {
    Button login;
    EditText tteid, pass;
    TextView signup;
    ProgressDialog progressDialog;
    FirebaseAuth ob;
    int firstLogin=0;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login_form);
        tteid = (EditText) findViewById(R.id.tteid);
        pass = (EditText) findViewById(R.id.password);
        login = (Button) findViewById(R.id.Login);
        signup = (TextView) findViewById(R.id.SignUp);
        progressDialog = new ProgressDialog(this);
        ob = FirebaseAuth.getInstance();
        if(ob.getCurrentUser()!=null)
        {
            Intent i = new Intent(loginForm.this, TrainsList.class);
            startActivity(i);
        }
        login.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String email, pas;
                email = tteid.getText().toString().trim();
                pas = pass.getText().toString().trim();
                if (email.isEmpty()) {
                    tteid.setError("UID required");
                    tteid.requestFocus();
                    return;
                }
                if (pas.isEmpty()) {
                    pass.setError("password required");
                    pass.requestFocus();
                    return;
                }
                ob.signInWithEmailAndPassword(email, pas).addOnCompleteListener(new OnCompleteListener<AuthResult>() {
                    @Override
                    public void onComplete(@NonNull Task<AuthResult> task) {
                        if (task.isSuccessful()) {
                            AlertDialog.Builder a_builder = new AlertDialog.Builder(loginForm.this);
                            View view = getLayoutInflater().inflate(R.layout.dialog_custom,null);
                            Button yes = (Button)view.findViewById(R.id.yes);
                            Button no = (Button)view.findViewById(R.id.no);
                            no.setOnClickListener(new View.OnClickListener() {
                                @Override
                                public void onClick(View v) {
                                    ob.signOut();
                                    Toast.makeText(loginForm.this, "NOT POSSIBLE!!! REVERTING...", Toast.LENGTH_SHORT).show();
                                    finish();
                                }
                            });
                            yes.setOnClickListener(new View.OnClickListener() {
                                @Override
                                public void onClick(View v) {
                                    Intent i = new Intent(loginForm.this, TrainsList.class);
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
                        if(!task.isSuccessful())
                        {
                            Toast.makeText(loginForm.this, "WRONG CREDENTIALS ENTER AGAIN", Toast.LENGTH_SHORT).show();
                            tteid.setText("");
                            pass.setText("");
                        }
                    }
                });
            }
        });
        signup.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent i = new Intent(loginForm.this,TteSignUp.class);
                startActivity(i);
            }
        });
    }
}


