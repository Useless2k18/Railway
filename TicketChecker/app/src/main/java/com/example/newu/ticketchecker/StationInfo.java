package com.example.newu.ticketchecker;

public class StationInfo {
    private String stationName;
    private String stationCode;
    private String stationPincode;


    public StationInfo(String nameOfStation, String codeOfStation, String zipCodeOfStation) {
        this.stationName = nameOfStation;
        this.stationCode = codeOfStation;
        this.stationPincode = zipCodeOfStation;
    }

    public String getStationName() {
        return stationName;
    }

    public String getStationCode() {
        return stationCode;
    }

    public String getStationPincode() {
        return stationPincode;
    }
}
