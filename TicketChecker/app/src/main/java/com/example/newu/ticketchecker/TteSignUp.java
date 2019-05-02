package com.example.newu.ticketchecker;

import android.content.Intent;
import android.support.annotation.NonNull;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import com.google.android.gms.tasks.OnCompleteListener;
import com.google.android.gms.tasks.Task;
import com.google.firebase.auth.AuthResult;
import com.google.firebase.auth.FirebaseAuth;
import com.google.firebase.firestore.CollectionReference;
import com.google.firebase.firestore.FirebaseFirestore;

public class TteSignUp extends AppCompatActivity {
    FirebaseAuth firebaseAuthenticationObject;
    Button signUp,reset;
    EditText userId, password, verifyPassword, firstName, lastName, tteId;
    private FirebaseFirestore databaseObject = FirebaseFirestore.getInstance();
    private CollectionReference ttnode = databaseObject.collection("ROOT/TT_DETAILS/TT");

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_reg_form);
        Intent intent =getIntent();
        //String url=intent.getStringExtra("url");
        firebaseAuthenticationObject = FirebaseAuth.getInstance();
        userId = (EditText) findViewById(R.id.mail);
        tteId = (EditText) findViewById(R.id.uid);
        password = (EditText) findViewById(R.id.pass1);
        firstName = (EditText) findViewById(R.id.firstname);
        lastName = (EditText) findViewById(R.id.surname);
        verifyPassword = (EditText) findViewById(R.id.pass2);
        signUp = (Button) findViewById(R.id.reg);
        reset = (Button) findViewById(R.id.reset);
        signUp.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                createUser();
            }
        });
        reset.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                userId.setText("");
                password.setText("");
                verifyPassword.setText("");
                firstName.setText("");
                lastName.setText("");
                tteId.setText("");
            }
        });
    }

    public void createUser() {
        final String id, pas, pas1, firs, las, tte;
        id = userId.getText().toString().trim();
        pas = password.getText().toString().trim();
        pas1 = verifyPassword.getText().toString().trim();
        firs = firstName.getText().toString().trim();
        las = lastName.getText().toString().trim();
        tte = tteId.getText().toString().trim();
        if (firs.isEmpty()) {
            firstName.setError("First Name required");
            firstName.requestFocus();
            return;
        }
        if (las.isEmpty()) {
            lastName.setError("Last Name required");
            lastName.requestFocus();
            return;
        }
        if (id.isEmpty()) {
            userId.setError("UID required");
            userId.requestFocus();
            return;
        }
        if (tte.isEmpty()) {
            tteId.setError("TTEID required");
            tteId.requestFocus();
            return;
        }
        if (pas.isEmpty()) {
            password.setError("password required");
            password.requestFocus();
            return;

        }
        if (pas1.isEmpty()) {
            verifyPassword.setError("Re enter password required");
            verifyPassword.requestFocus();
            return;
        }
        if (pas.length() < 6) {
            password.setError("password short");
            password.requestFocus();
            return;
        }
        if (pas.equals(pas1) == false) {
            verifyPassword.setError("password do not match");
            verifyPassword.setText("");
            password.setText("");
            password.requestFocus();
            return;
        }
        firebaseAuthenticationObject.createUserWithEmailAndPassword(id, pas).addOnCompleteListener(new OnCompleteListener<AuthResult>() {
            @Override
            public void onComplete(@NonNull Task<AuthResult> task) {
                if (task.isSuccessful()) {
                    startActivity(new Intent(TteSignUp.this, loginForm.class));
                } else {
                    /*if(task.getException() instanceof FirebaseAuthUserCollisionException){
                        userLogin(id,pas);

                    }else
                    {*/
                    Toast.makeText(TteSignUp.this, task.getException().getMessage(), Toast.LENGTH_LONG).show();
                    //}
                }
                addnote();

            }
        });
    }

   public void addnote() {
        String ID = tteId.getText().toString();

        String FRST = firstName.getText().toString();
        String LST = lastName.getText().toString();
        String ZONE = "EAST";

      /*  Map<String,Object> note=new HashMap<>();
        note.put(KEY_TITLE,title);
        note.put(KEY_DESCRIPTION,description);*/
        //this is used instead of the hashmap a java class note is used
       TteDetails note = new TteDetails(ID, FRST, LST, ZONE);

        ttnode.document(ID).set(note);
    }
   /* private void userLogin(String mail,String password)
    {
        firebaseAuthenticationObject.signInWithEmailAndPassword(mail,password).addOnCompleteListener(new OnCompleteListener<AuthResult>() {
            @Override
            public void onComplete(@NonNull Task<AuthResult> task) {
                if(task.isSuccessful()){
                    startActivity(new Intent(TteSignUp.this,loginForm.class));
                }else
                {
                    Toast.makeText(TteSignUp.this,task.getException().getMessage(),Toast.LENGTH_LONG).show();
                }
            }
        });
    }*/
}