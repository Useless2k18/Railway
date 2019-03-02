package com.example.newu.ticketchecker;

public class StationInfo {
    private String railwayDivision:
    private String stationName;
    private String stationCode;
    private int stationPincode;


    public StationInfo(String nameOfStation, String codeOfStation, int zipCodeOfStation,String railwayDivisionName) {
        this.stationName = nameOfStation;
        this.stationCode = codeOfStation;
        this.stationPincode = zipCodeOfStation;
       this.railwayDivision=railwayDivisionName;
    }

    public String getStationName() {
        return stationName;
    }

    public String getStationCode() {
        return stationCode;
    }

    public int getStationPincode() {
        return stationPincode;
    }

    public String getRailwayDivision() {
        return railwayDivision;
    }
}
