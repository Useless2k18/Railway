package com.example.newu.trainlaydyn;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

public class DatabaseHelper extends SQLiteOpenHelper
{
    public static final String Db_name = "Train.db";
    public static final String Db_tableName = "stations";
    public static final String Db_col1 = "ID";
    public static final String Db_col2 = "TRAIN1";
    public static final String Db_col3 = "TRAIN2";
    public DatabaseHelper(Context context) {
        super(context,Db_name,null,1);
    }

    @Override
    public void onCreate(SQLiteDatabase db) {
        db.execSQL("create table "+Db_tableName+" (id int primary key,train1 varchar not null,train2 varchar not null)");
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {

    }
    public long insetData(SQLiteDatabase db,int id,String t1,String t2) {
        db = this.getWritableDatabase();
        ContentValues c = new ContentValues();
        c.put(Db_col1,id);
        c.put(Db_col2,t1);
        c.put(Db_col3,t2);
        //long res = db.insert(Db_name,null,c);
        long i = db.insert(Db_tableName,null,c);
        return i;
    }
    public Cursor getAllData(SQLiteDatabase db)
    {

        db = this.getWritableDatabase();
        Cursor res = db.rawQuery("select * from "+Db_tableName,null);
        return res;

    }

}
