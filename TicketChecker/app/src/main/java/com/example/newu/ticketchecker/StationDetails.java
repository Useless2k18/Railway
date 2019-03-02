package com.example.newu.ticketchecker;

public class StationDetails {
    private String stationCode;
    private String stationName;
    private int stationPincode;
    private String railwayDivision;
    private String zone;

    public void setStationCode(String stationCode) {
        this.stationCode = stationCode;
    }

    public void setStationName(String stationName) {
        this.stationName = stationName;
    }

    public int getStationPincode() {
        return stationPincode;
    }

    public void setStationPincode(int stationPincode) {
        this.stationPincode = stationPincode;
    }

    public String getRailwayDivision() {
        return railwayDivision;
    }

    public void setRailwayDivision(String railwayDivision) {
        this.railwayDivision = railwayDivision;
    }

    public String getZone() {
        return zone;
    }

    public void setZone(String zone) {
        this.zone = zone;
    }

    public String getStationCode() {
        return stationCode;
    }

    public String getStationName() {
        return stationName;
    }

    public int getStationPin() {
        return stationPincode;
    }
}
