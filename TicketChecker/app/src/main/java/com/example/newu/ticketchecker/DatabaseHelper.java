package com.example.newu.ticketchecker;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.util.Log;

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

    public static final String Db_tableRoute = "ROUTE";
    public static final String Db_route_col1 = "SERIAL";
    public static final String Db_route_col2 = "STATIONCODE";
    public static final String Db_route_col3 = "STATUS";
    public static final String Db_route_col4 = "ARRIVALTIME";
    public static final String Db_route_col5 = "DEPARTURETIME";
    public static final String Db_route_col6 = "DAY";

    public static final String Db_tablePassenger = "PASSENGER";
    public static final String Db_passenger_col1 = "PNR";
    public static final String Db_passenger_col2 = "FNAME";
    public static final String Db_passenger_col3 = "LNAME";
    public static final String Db_passenger_col4 = "BOARDINGSTATION";
    public static final String Db_passenger_col5 = "DEPARTURESTATION";
    public static final String Db_passenger_col6 = "COACH";
    public static final String Db_passenger_col7 = "STATUS";
    public static final String Db_passenger_col7_i = "VERIFIED";
    public static final String Db_passenger_col8 = "SEAT";
    public static final String Db_passenger_col9 = "CLASSOF";
    public static final String Db_passenger_col10 = "AGE";
    public static final String Db_passenger_col11 = "WLNO";


    public DatabaseHelper(Context context) {
        super(context,Db_name,null,1);
    }

    @Override
    public void onCreate(SQLiteDatabase db) {
        db.execSQL("create table "+Db_tableStation+" (CODE varchar primary key,NAME varchar not null,PINCODE long not null)");
        db.execSQL("create table "+Db_tableDivision+" (NAME varchar primary key,STATION varchar not null,FOREIGN KEY(STATION) REFERENCES STATIONS(CODE))");
        db.execSQL("create table "+Db_tableZone+" (ID varchar primary key,NAME varchar not null,DIVISION_NAME varchar not null,NUMBER_OF long not null,FOREIGN KEY(DIVISION_NAME) REFERENCES DIVISION(NAME))");
        //db.execSQL("create table "+Db_tableRoute+" (SERIAL long not null,STATIONCODE varchar not null,STATUS long not null,ARRIVALTIME varchar not null,DEPARTURETIME varchar not null,DAY varchar not null)");
        db.execSQL("create table "+Db_tableRoute+" (SERIAL long ,STATIONCODE varchar ,STATUS long ,ARRIVALTIME varchar ,DEPARTURETIME varchar,DAY varchar )");
        db.execSQL("create table "+Db_tablePassenger+" (PNR varchar not null,FNAME varchar not null,LNAME varchar not null,BOARDINGSTATION varchar not null,DEPARTURESTATION varchar not null,COACH varchar not null,STATUS varchar not null,VERIFIED varchar not null,SEAT varchar not null,CLASSOF varchar not null,AGE varchar not null,WLNO varchar not null)");
    }
    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        db.execSQL("DROP TABLE IF EXISTS "+Db_tableZone);
        db.execSQL("DROP TABLE IF EXISTS "+Db_tableDivision);
        db.execSQL("DROP TABLE IF EXISTS "+Db_tableStation);
        db.execSQL("DROP TABLE IF EXISTS "+Db_tableRoute);
        db.execSQL("DROP TABLE IF EXISTS "+Db_tablePassenger);
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
    public long insertRouteData(SQLiteDatabase routeDb,long serial_number,String station_code,long status,String arrival_time,String departure_time,String day )
    {
        //System.out.println(station_code);
        Log.i("myTag",station_code);
        routeDb = this.getWritableDatabase();
        ContentValues c = new ContentValues();
        c.put(Db_route_col1,serial_number);
        c.put(Db_route_col2,station_code);
        c.put(Db_route_col3,status);
        c.put(Db_route_col4,arrival_time);
        c.put(Db_route_col5,departure_time);
        c.put(Db_route_col6,day);
        //long res = db.insert(Db_name,null,c);
        long i = routeDb.insert("ROUTE",null,c);
        return i;
    }
    public long insertPassengerData(SQLiteDatabase db,String pnr,String firstName,String lastName,String boardingStation,String destinationStation,String coach,String status,String verified,String seat,String classOf,String age,String wl_No)
    {
        db = this.getWritableDatabase();
        ContentValues c = new ContentValues();
        c.put(Db_passenger_col1,pnr);
        c.put(Db_passenger_col2,firstName);
        c.put(Db_passenger_col3,lastName);
        c.put(Db_passenger_col4,boardingStation);
        c.put(Db_passenger_col5,destinationStation);
        c.put(Db_passenger_col6,coach);
        c.put(Db_passenger_col7,status);
        c.put(Db_passenger_col7_i,verified);
        c.put(Db_passenger_col8,seat);
        c.put(Db_passenger_col9,classOf);
        c.put(Db_passenger_col10,age);
        c.put(Db_passenger_col11,wl_No);

        //long res = db.insert(Db_name,null,c);
        long i = db.insert(Db_tablePassenger,null,c);
        return i;
    }
    public Cursor getPassengerData(SQLiteDatabase db)
    {

        db = this.getWritableDatabase();
        Cursor pass = db.rawQuery("select * from "+Db_tablePassenger,null);
        return pass;
    }
    public Cursor getRouteData(SQLiteDatabase db)
    {

        db = this.getWritableDatabase();
        Cursor route = db.rawQuery("select * from "+"ROUTE",null);
        return route;
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
