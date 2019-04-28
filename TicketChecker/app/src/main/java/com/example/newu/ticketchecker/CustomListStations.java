package com.example.newu.ticketchecker;

import android.content.Context;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import java.util.ArrayList;

public class CustomListStations extends ArrayAdapter<StationInfo> {

    ArrayList<StationInfo> myList = new ArrayList<>();

    public CustomListStations(Context context, int textViewResourceId, ArrayList<StationInfo> objects) {
        super(context, textViewResourceId, objects);
    }

    @Override
    public int getCount() {
        return super.getCount();
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {

        View v = convertView;
        LayoutInflater inflater = (LayoutInflater) getContext().getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        v = inflater.inflate(R.layout.customlistlayout, null);
        TextView textView1 = (TextView) v.findViewById(R.id.textView_stn);
        TextView textView2 = (TextView) v.findViewById(R.id.textView_passenger_unverified);
        TextView textView3 = (TextView) v.findViewById(R.id.textView_passenger_verified);
        textView1.setText(myList.get(position).getStationCode());
        //textView2.setText(myList.get(position).getNum_of_pass());

        return v;
    }
}
