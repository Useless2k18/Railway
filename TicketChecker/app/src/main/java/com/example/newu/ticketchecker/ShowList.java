package com.example.newu.ticketchecker;

import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.widget.ListView;

import java.util.ArrayList;

public class ShowList extends AppCompatActivity {

    ListView lv;
    DatabaseHelper dbhelp;
    SQLiteDatabase sd;
    Cursor c;
    CustomListAdapter cla;
    ArrayList<StationInfo> myList = new ArrayList<>();
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_show_list);
        lv=findViewById(R.id.list);
        dbhelp=new DatabaseHelper(this);
        sd=dbhelp.getReadableDatabase();
        c = dbhelp.getRouteData(sd);

        c=dbhelp.getRouteData(sd);
        while (c.moveToNext())
        {
            StationInfo ob = new StationInfo(" ",c.getString(1),0,"");
            myList.add(ob);
        }
        cla=new CustomListAdapter(getApplicationContext(),R.layout.customlistlayout,myList);
        lv.setAdapter(cla);
    }
}
