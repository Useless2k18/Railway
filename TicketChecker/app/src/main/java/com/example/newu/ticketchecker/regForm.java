package com.example.newu.ticketchecker;

import android.content.Intent;
import android.support.annotation.NonNull;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ProgressBar;
import android.widget.Toast;

import com.google.android.gms.tasks.OnCompleteListener;
import com.google.android.gms.tasks.OnFailureListener;
import com.google.android.gms.tasks.OnSuccessListener;
import com.google.android.gms.tasks.Task;
import com.google.firebase.auth.AuthResult;
import com.google.firebase.auth.FirebaseAuth;
import com.google.firebase.auth.FirebaseAuthUserCollisionException;
import com.google.firebase.firestore.CollectionReference;
import com.google.firebase.firestore.FirebaseFirestore;

public class regForm extends AppCompatActivity {
    FirebaseAuth ob;
    Button signup, reset;
    EditText uid, pass, pass1, first, last, tteid;
    private FirebaseFirestore db = FirebaseFirestore.getInstance();
    private CollectionReference ttnode = db.collection("ROOT/TT_DETAILS/TT");

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_reg_form);
        ob = FirebaseAuth.getInstance();
        uid = (EditText) findViewById(R.id.mail);
        tteid = (EditText) findViewById(R.id.uid);
        pass = (EditText) findViewById(R.id.pass1);
        first = (EditText) findViewById(R.id.firstname);
        last = (EditText) findViewById(R.id.surname);
        pass1 = (EditText) findViewById(R.id.pass2);
        signup = (Button) findViewById(R.id.reg);
        reset = (Button) findViewById(R.id.reset);
        signup.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                createUser();
            }
        });
        reset.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                uid.setText("");
                pass.setText("");
                pass1.setText("");
                first.setText("");
                last.setText("");
                tteid.setText("");
            }
        });
    }

    public void createUser() {
        final String id, pas, pas1, firs, las, tte;
        id = uid.getText().toString().trim();
        pas = pass.getText().toString().trim();
        pas1 = pass1.getText().toString().trim();
        firs = first.getText().toString().trim();
        las = last.getText().toString().trim();
        tte = tteid.getText().toString().trim();
        if (firs.isEmpty()) {
            first.setError("First Name required");
            first.requestFocus();
            return;
        }
        if (las.isEmpty()) {
            last.setError("Last Name required");
            last.requestFocus();
            return;
        }
        if (id.isEmpty()) {
            uid.setError("UID required");
            uid.requestFocus();
            return;
        }
        if (tte.isEmpty()) {
            tteid.setError("TTEID required");
            tteid.requestFocus();
            return;
        }
        if (pas.isEmpty()) {
            pass.setError("Password required");
            pass.requestFocus();
            return;

        }
        if (pas1.isEmpty()) {
            pass1.setError("Re enter Password required");
            pass1.requestFocus();
            return;
        }
        if (pas.length() < 6) {
            pass.setError("Password short");
            pass.requestFocus();
            return;
        }
        if (pas.equals(pas1) == false) {
            pass1.setError("Password do not match");
            pass1.setText("");
            pass.setText("");
            pass.requestFocus();
            return;
        }
        ob.createUserWithEmailAndPassword(id, pas).addOnCompleteListener(new OnCompleteListener<AuthResult>() {
            @Override
            public void onComplete(@NonNull Task<AuthResult> task) {
                if (task.isSuccessful()) {
                    startActivity(new Intent(regForm.this, loginForm.class));
                } else {
                    /*if(task.getException() instanceof FirebaseAuthUserCollisionException){
                        userLogin(id,pas);

                    }else
                    {*/
                    Toast.makeText(regForm.this, task.getException().getMessage(), Toast.LENGTH_LONG).show();
                    //}
                }
                addnote();

            }
        });
    }

   public void addnote() {
        String ID = tteid.getText().toString();

        String FRST = first.getText().toString();
        String LST = last.getText().toString();
        String ZONE = "EAST";

      /*  Map<String,Object> note=new HashMap<>();
        note.put(KEY_TITLE,title);
        note.put(KEY_DESCRIPTION,description);*/
        //this is used instead of the hashmap a java class note is used
       ttnode note = new ttnode(ID, FRST, LST, ZONE);

        ttnode.document(ID).set(note);
    }
   /* private void userLogin(String mail,String password)
    {
        ob.signInWithEmailAndPassword(mail,password).addOnCompleteListener(new OnCompleteListener<AuthResult>() {
            @Override
            public void onComplete(@NonNull Task<AuthResult> task) {
                if(task.isSuccessful()){
                    startActivity(new Intent(regForm.this,loginForm.class));
                }else
                {
                    Toast.makeText(regForm.this,task.getException().getMessage(),Toast.LENGTH_LONG).show();
                }
            }
        });
    }*/
}