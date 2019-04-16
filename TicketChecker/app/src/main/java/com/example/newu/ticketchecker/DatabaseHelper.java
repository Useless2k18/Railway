package com.example.newu.ticketchecker;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

public class DatabaseHelper extends SQLiteOpenHelper {

    public static final String Db_name = "LocalDb.db";
    public static final String Db_tableStation = "STATIONS";
    public static final String Db_station_col1 = "CODE";
    public static final String Db_station_col2 = "NAME";
    public static final String Db_station_col3 = "PINCODE";
    public static final String Db_tableDivision = "DIVISION";
    public static final String Db_division_col1 = "NAME";
    public static final String Db_division_col2 = "STATION";
    public static final String Db_tableZone = "ZONE";
    public static final String Db_zone_col1 = "ID";
    public static final String Db_zone_col2 = "NAME";
    public static final String Db_zone_col3 = "DIVISION_NAME";
    public static final String Db_zone_col4 = "NUMBER_OF";
    public DatabaseHelper(Context context) {
        super(context,Db_name,null,1);
    }

    @Override
    public void onCreate(SQLiteDatabase db) {
        db.execSQL("create table "+Db_tableStation+" (CODE varchar primary key,NAME varchar not null,PINCODE long not null)");
        db.execSQL("create table "+Db_tableDivision+" (NAME varchar primary key,STATION varchar not null,FOREIGN KEY(STATION) REFERENCES STATIONS(CODE))");
        db.execSQL("create table "+Db_tableZone+" (ID varchar primary key,DIVISION_NAME varchar not null,NUMBER_OF long not null,FOREIGN KEY(DIVISION_NAME) REFERENCES DIVISION(NAME))");
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        db.execSQL("DROP TABLE IF EXISTS "+Db_tableZone);
        db.execSQL("DROP TABLE IF EXISTS "+Db_tableDivision);
        db.execSQL("DROP TABLE IF EXISTS "+Db_tableStation);
        onCreate(db);
    }
    public long insertStationData(SQLiteDatabase db, String Station_code, String Station_Name, long Station_pincode) {
        db = this.getWritableDatabase();
        ContentValues c = new ContentValues();
        c.put(Db_station_col1,Station_code);
        c.put(Db_station_col2,Station_Name);
        c.put(Db_station_col3,Station_pincode);
        //long res = db.insert(Db_name,null,c);
        long i = db.insert(Db_tableStation,null,c);
        return i;
    }
    public long insertDivisionData(SQLiteDatabase db, String Division_Name, String Station_code) {
        db = this.getWritableDatabase();
        ContentValues c = new ContentValues();
        c.put(Db_division_col1,Division_Name);
        c.put(Db_division_col2,Station_code);
        long i = db.insert(Db_tableDivision,null,c);
        return i;
    }
    public long insertZoneData(SQLiteDatabase db, String Zone_id, String Zone_name,String Division_name,long noOfDivisions) {
        db = this.getWritableDatabase();
        ContentValues c = new ContentValues();
        c.put(Db_zone_col1,Zone_id);
        c.put(Db_zone_col2,Zone_name);
        c.put(Db_zone_col3,Division_name);
        c.put(Db_zone_col4,noOfDivisions);
        //long res = db.insert(Db_name,null,c);
        long i = db.insert(Db_tableZone,null,c);
        return i;
    }
    public Cursor getStationData(SQLiteDatabase db)
    {

        db = this.getWritableDatabase();
        Cursor stations = db.rawQuery("select * from "+Db_tableStation,null);
        return stations;
    }
    public Cursor getDivisionData(SQLiteDatabase db)
    {

        db = this.getWritableDatabase();
        Cursor divisions = db.rawQuery("select * from "+Db_tableDivision,null);
        return divisions;

    }
    public Cursor getZoneData(SQLiteDatabase db)
    {

        db = this.getWritableDatabase();
        Cursor zone = db.rawQuery("select * from "+Db_tableZone,null);
        return zone;

    }
}
