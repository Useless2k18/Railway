package com.example.newu.ticketchecker;

public class StationInfo {
    private String railwayDivision;
    private String stationName;
    private String stationCode;
    private long stationPincode;

public StationInfo(){}

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

    public long getStationPincode() {
        return stationPincode;
    }

    public String getRailwayDivision() {
        return railwayDivision;
    }
}
