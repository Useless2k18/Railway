package com.example.newu.trainlaydyn;
import android.app.AlertDialog;
import android.content.Context;
import android.content.Intent;
import android.database.Cursor;
import android.database.sqlite.SQLiteOpenHelper;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.database.sqlite.SQLiteDatabase;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;

public class MainActivity extends AppCompatActivity {
    SQLiteDatabase db;
    DatabaseHelper mydb;
    Button train1,train2;
    Button view;
    ArrayAdapter<String> adapter;
    int id[] = {1,2,3,4,5,6,7,8,9};
    String tr1[] = {"BBS","CTC","JJKR","BHC","SORO","BLS","JER","KGP","HWH"};
    String tr2[] = {"PURI","KUR","BBS","CTC","JJKR","BHC","BLS","KGP","HWH"};
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        mydb=new DatabaseHelper(this);
        db=mydb.getWritableDatabase();
        view = (Button)findViewById(R.id.view);
        mydb = new DatabaseHelper(this);
        train1 = (Button)findViewById(R.id.train1);
        train2 = (Button)findViewById(R.id.train2);
        int i;
        int k;
        for(i = 0;i<9;i++)
            mydb.insetData(db,id[i],tr1[i],tr2[i]);
        train1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent i = new Intent(MainActivity.this,Stations.class);
                i.putExtra("k",1);
                startActivity(i);

            }
        });
        train2.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent i = new Intent(MainActivity.this,Stations.class);
                i.putExtra("k",2);
                startActivity(i);

            }
        });
        view.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Cursor res = mydb.getAllData(db);
                if(res.getCount() == 0) {
                    // show message
                    showMessage("Error", "Nothing found");
                    return;
                }
                StringBuffer buffer = new StringBuffer();
                while (res.moveToNext()) {
                    buffer.append("Id :"+ res.getString(0)+"\n");
                    buffer.append("TRAIN 1 :"+ res.getString(1)+"\n");
                    buffer.append("TRAIN 2 :"+ res.getString(2)+"\n");
                }
                // Show all data
                showMessage("Data",buffer.toString());
            }
        });
    }
    public void showMessage(String title,String Message){
        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        builder.setCancelable(true);
        builder.setTitle(title);
        builder.setMessage(Message);
        builder.show();
    }
}


