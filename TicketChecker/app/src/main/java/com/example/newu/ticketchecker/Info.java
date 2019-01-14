package com.example.newu.ticketchecker;

public class Info {
    String station_name;
    String station_code;
    String station_zip;

    public Info(String station_name, String station_code, String station_zip) {
        this.station_name = station_name;
        this.station_code = station_code;
        this.station_zip = station_zip;
    }

    public String getStation_name() {
        return station_name;
    }

    public String getStation_code() {
        return station_code;
    }

    public String getStation_zip() {
        return station_zip;
    }
}
