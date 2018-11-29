package com.example.newu.trainlaydyn;

import android.content.ClipData;
import android.content.Context;
import android.support.annotation.NonNull;
import android.support.annotation.Nullable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import java.util.ArrayList;
import java.util.List;

class CustomListAdapter extends ArrayAdapter<Info> {

    ArrayList<Info> myList = new ArrayList<>();

    public CustomListAdapter(Context context, int textViewResourceId, ArrayList<Info> objects) {
        super(context, textViewResourceId, objects);
        myList = objects;
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
        textView1.setText(myList.get(position).getStation());
        textView2.setText(myList.get(position).getNum_of_pass());
        return v;

    }
}
