package com.example.newu.ticketchecker;

import android.Manifest;
import android.content.Context;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.location.Address;
import android.location.Geocoder;
import android.support.v4.app.ActivityCompat;
import android.support.v4.content.ContextCompat;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import java.util.Locale;

public class ShowList extends AppCompatActivity {

    ListView lv;
    DatabaseHelper dbhelp;
    SQLiteDatabase sd;
    Cursor c;
    CustomListAdapter cla;
    ArrayList<StationInfo> myList = new ArrayList<>();
    GPSTracker gps;
    Geocoder geocoder;
    List<Address> addressList;
    Context mContext;
    double latitude,longitude;
    String GPSPinCode;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_show_list);
        lv=findViewById(R.id.list);
        dbhelp=new DatabaseHelper(this);
        sd=dbhelp.getReadableDatabase();
        c = dbhelp.getRouteData(sd);

        c=dbhelp.getRouteData(sd);
        

        geocoder = new Geocoder(this, Locale.getDefault());
        mContext = this;
        if (ContextCompat.checkSelfPermission(mContext,Manifest.permission.ACCESS_FINE_LOCATION) != PackageManager.PERMISSION_GRANTED && ActivityCompat.checkSelfPermission(mContext, Manifest.permission.ACCESS_COARSE_LOCATION) != PackageManager.PERMISSION_GRANTED) {
            ActivityCompat.requestPermissions(ShowList.this, new String[]{Manifest.permission.ACCESS_FINE_LOCATION}, 1);
        } else {
            Toast.makeText(mContext, "You need have granted permission", Toast.LENGTH_SHORT).show();
            gps = new GPSTracker(mContext, ShowList.this);
            if (gps.canGetLocation()) {

                latitude = gps.getLatitude();
                longitude = gps.getLongitude();
                Toast.makeText(getApplicationContext(),"Your Location is - \nLat: " + latitude + "\nLong: " + longitude, Toast.LENGTH_LONG).show();
            } else {
                gps.showSettingsAlert();
            }
        }
        try {
            addressList = geocoder.getFromLocation(latitude,longitude,1);
            String addressStr = addressList.get(0).getAddressLine(0);
            String areaStr = addressList.get(0).getLocality();
            String cityStr = addressList.get(0).getAdminArea();
            String countryStr = addressList.get(0).getCountryName();
            GPSPinCode = addressList.get(0).getPostalCode();
            String fullAddress = addressStr+", "+areaStr+", "+cityStr+", "+countryStr+", "+GPSPinCode;
            Toast.makeText(getApplicationContext(), "POSTAL CODE : "+GPSPinCode, Toast.LENGTH_SHORT).show();
        } catch (IOException e) {
            e.printStackTrace();
        }
        while (c.moveToNext())
        {
            StationInfo ob = new StationInfo(" ",c.getString(1),0,"");
           // Cursor res = sd.rawQuery("SELECT * FROM STATIONS WHERE CODE = '"+ob.getStationCode()+"'",null);
           // Toast.makeText(mContext, res.getString(0), Toast.LENGTH_SHORT).show();
           // if(GPSPinCode.equalsIgnoreCase("751024"))
            myList.add(ob);
        }

        cla=new CustomListAdapter(getApplicationContext(),R.layout.customlistlayout,myList);
        lv.setAdapter(cla);
    }
    @Override
    public void onRequestPermissionsResult(int requestCode, String[] permissions, int[] grantResults) {
        super.onRequestPermissionsResult(requestCode, permissions, grantResults);
        switch (requestCode) {
            case 1: {
                if (grantResults.length > 0 && grantResults[0] == PackageManager.PERMISSION_GRANTED) {
                    gps = new GPSTracker(mContext, ShowList.this);
                    if (gps.canGetLocation()) {
                        double latitude = gps.getLatitude();
                        double longitude = gps.getLongitude();
                        Toast.makeText(getApplicationContext(),
                                "Your Location is - \nLat: " + latitude + "\nLong: " + longitude, Toast.LENGTH_LONG).show();
                    } else {
                        gps.showSettingsAlert();
                    }
                } else {
                    Toast.makeText(mContext, "You need to grant permission", Toast.LENGTH_SHORT).show();
                }
                return;
            }
        }
    }

}
