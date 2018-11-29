package com.example.newu.trainlaydyn;

import android.app.AlertDialog;
import android.content.Intent;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.BaseAdapter;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import java.util.ArrayList;

public class Stations extends AppCompatActivity {
    SQLiteDatabase db;
    DatabaseHelper mydb;
    ListView lv;
    ArrayList<Info> theList =new ArrayList<>();
    Cursor c;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_stations);
        mydb = new DatabaseHelper(this);
        db = mydb.getWritableDatabase();
        Intent i = getIntent();
        int temp = i.getIntExtra("k",0);
        lv = (ListView) findViewById(R.id.listdyn);
        c=mydb.getAllData(db);
        if (c.getCount() == 0) {
            Toast.makeText(this, "THE DATABASE IS EMPTY!", Toast.LENGTH_SHORT).show();
        }
        else
        {
            while(c.moveToNext())
            {
                Info ob = new Info(c.getString(temp),"");
                theList.add(ob);
            }
        }
        CustomListAdapter cla = new CustomListAdapter(this,R.layout.customlistlayout,theList);
        lv.setAdapter(cla);
    }
}

