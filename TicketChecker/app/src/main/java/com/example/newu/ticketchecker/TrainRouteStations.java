package com.example.newu.ticketchecker;

public class TrainRouteStations {
    private String arrivalTime;
    private String departureTime;
    private String stationCode;
    private String division;
    private String zone;
    public TrainRouteStations()
    {

    }

    public String getarrivalTime() {
        return arrivalTime;
    }

    public String getDepartureTime() {
        return departureTime;
    }

    public String getStationCode() {
        return stationCode;
    }

    public String getArrivalTime() {
        return arrivalTime;
    }

    public void setArrivalTime(String arrivalTime) {
        this.arrivalTime = arrivalTime;
    }

    public void setDepartureTime(String departureTime) {
        this.departureTime = departureTime;
    }

    public void setStationCode(String stationCode) {
        this.stationCode = stationCode;
    }

    public String getDivision() {
        return division;
    }

    public void setDivision(String division) {
        this.division = division;
    }

    public String getZone() {
        return zone;
    }

    public void setZone(String zone) {
        this.zone = zone;
    }
}
