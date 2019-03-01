package com.example.newu.ticketchecker;

import android.content.Context;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

public class DatabaseHelper extends SQLiteOpenHelper {

    public static final String Db_name = "LocalDb.db";
    public static final String Db_tableStation = "Stations";
    public static final String Db_station_col1 = "CODE";
    public static final String Db_station_col2 = "NAME";
    public static final String Db_station_col3 = "PINCODE";
    public static final String Db_tableDivision = "Divisions";
    public static final String Db_division_col1 = "NAME";
    public static final String Db_division_col2 = "STATION";
    public static final String Db_tableZone = "Zones";
    public static final String Db_zone_col1 = "ID";
    public static final String Db_zone_col2 = "NAME";
    public static final String Db_zone_col3 = "DIVISION";
    public static final String Db_zone_col4 = "NUMBER_OF";
    public DatabaseHelper(Context context) {
        super(context,Db_name,null,1);
        SQLiteDatabase db =this.getWritableDatabase();
    }

    @Override
    public void onCreate(SQLiteDatabase db) {
        db.execSQL("create table "+Db_tableStation+" (CODE int primary key,NAME varchar not null,PINCODE varchar not null)");
        db.execSQL("create table "+Db_tableDivision+" (NAME int primary key,STATION varchar not null,FOREIGN KEY(STATION) REFERENCES Stations(CODE))");
        db.execSQL("create table "+Db_tableZone+" (ID int primary key,NAME varchar not null,DIVISION varchar not null,NUMBER_OF int not null,FOREIGN KEY(DIVISION) REFERENCES Divisions(NAME))");
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        db.execSQL("DROP TABLE IF EXISTS "+Db_tableZone);
        db.execSQL("DROP TABLE IF EXISTS "+Db_tableDivision);
        db.execSQL("DROP TABLE IF EXISTS "+Db_tableStation);
        onCreate(db);
    }
}
