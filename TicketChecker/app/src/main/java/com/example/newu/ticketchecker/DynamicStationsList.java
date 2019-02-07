package com.example.newu.ticketchecker;

import android.Manifest;
import android.content.Context;
import android.content.pm.PackageManager;
import android.location.Address;
import android.location.Geocoder;
import android.support.annotation.NonNull;
import android.support.v4.app.ActivityCompat;
import android.support.v4.content.ContextCompat;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import com.google.android.gms.tasks.OnFailureListener;
import com.google.android.gms.tasks.OnSuccessListener;
import com.google.firebase.firestore.CollectionReference;
import com.google.firebase.firestore.DocumentSnapshot;
import com.google.firebase.firestore.FirebaseFirestore;

import java.io.IOException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Locale;
import java.util.Map;

public class DynamicStationsList extends AppCompatActivity {
    private static final String KEY="route";
    Map<String,TrainRouteStations> trainRoute =new HashMap<String ,TrainRouteStations>();
    TrainRouteStations routeStations = new TrainRouteStations();
    GPSTracker gps;
    TextView result;
    Geocoder geocoder;
    List<Address> addressList;
    Context mContext;
    double latitude,longitude;
    //Map<String,String>routeStations=new HashMap<String, String>();
    int noOfStops;
    private FirebaseFirestore trainDatabaseObject = FirebaseFirestore.getInstance();
    private FirebaseFirestore stationsDatabaseObject =FirebaseFirestore.getInstance();
    private CollectionReference trainDetails = trainDatabaseObject.collection("ROOT/TRAIN_DETAILS/12073");
    private CollectionReference stationDetails = stationsDatabaseObject.collection("ROOT/STATIONS/STN_DETAILS");
    //HashMap<String, HashMap<String, String>> RO_TE = new HashMap<String, HashMap<String,String>>();
    //HashMap<String, HashMap<String, String>> route = new HashMap<String, HashMap<String,String>>();
    //Map<String,Map>route=new HashMap<String, Map>();
    //HashMap<String,Map>RO_TE=new HashMap<String, Map>();


    ArrayList<StationInfo> stationsList;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        ListView lv = (ListView) findViewById(R.id.listdyn);
        setContentView(R.layout.activity_train__dy__list);
        geocoder = new Geocoder(this, Locale.getDefault());
        mContext = this;
        if (ContextCompat.checkSelfPermission(mContext,Manifest.permission.ACCESS_FINE_LOCATION) != PackageManager.PERMISSION_GRANTED && ActivityCompat.checkSelfPermission(mContext, Manifest.permission.ACCESS_COARSE_LOCATION) != PackageManager.PERMISSION_GRANTED) {
            ActivityCompat.requestPermissions(DynamicStationsList.this, new String[]{Manifest.permission.ACCESS_FINE_LOCATION}, 1);
        } else {
            Toast.makeText(mContext, "You need have granted permission", Toast.LENGTH_SHORT).show();
            gps = new GPSTracker(mContext, DynamicStationsList.this);
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
            String postalcodeStr = addressList.get(0).getPostalCode();
            //fullAddress = addressStr+", "+areaStr+", "+cityStr+", "+countryStr+", "+postalcodeStr;
        } catch (IOException e) {
            e.printStackTrace();
        }
        //moveTaskToBack(true);   moves task to previous activity
        CustomListAdapter cla = new CustomListAdapter(this,R.layout.customlistlayout,stationsList);

        //ADD TO STATIONSlIST ACCORDING TO PIN AND THEN SET ADAPTER EVERY TIME


        lv.setAdapter(cla);
    }

    @Override
    protected void onStart() {
        super.onStart();

    }



    //FETCH DATA FROM DATABASE
    public void download()
    {
        trainDetails.document("12073").get().addOnSuccessListener(new OnSuccessListener<DocumentSnapshot>() {
            @Override
            public void onSuccess(DocumentSnapshot documentSnapshot) {
                if(documentSnapshot.exists()) {
                    TrainDetails note = documentSnapshot.toObject(TrainDetails.class);
                    trainRoute = note.getRoute();
                    noOfStops = note.getNoOfStations();
                    for (int i = 0; i <= noOfStops; i++) {
                        String code, stnpincode, stn;
                        routeStations = trainRoute.get(i);
                        code = routeStations.getStationCode();
                        stationDetails.document(code).get().addOnSuccessListener(new OnSuccessListener<DocumentSnapshot>() {
                            @Override
                            public void onSuccess(DocumentSnapshot documentSnapshot) {
                                if (documentSnapshot.exists()) {
                                    StationDetails stationobject = documentSnapshot.toObject(StationDetails.class);
                                    StationInfo ob = new StationInfo(stationobject.getStationName(), stationobject.getStationCode(), stationobject.getStationPin());
                                    stationsList.add(ob);

                                } else {
                                    Toast.makeText(DynamicStationsList.this, "STATION LIST DOESNOT EXISTS", Toast.LENGTH_LONG).show();
                                }
                                //String description=note.getDescription();
                                // String title=documentSnapshot.getString(KEY_TITLE);
                                //String description=documentSnapshot.getString(KEY_DESCRIPTION);

                                //Map<String,Object> note =documentSnapshot.getData()
                            }
                        }).addOnFailureListener(new OnFailureListener() {
                            @Override
                            public void onFailure(@NonNull Exception e) {

                            }
                        });
                    }
                }

                else
                {
                    Toast.makeText(DynamicStationsList.this,"Not exists",Toast.LENGTH_LONG).show();
                }
            }
        }).addOnFailureListener(new OnFailureListener() {
            @Override
            public void onFailure(@NonNull Exception e) {
                Toast.makeText(DynamicStationsList.this,"ERROR",Toast.LENGTH_LONG).show();

            }
        });
    }
}