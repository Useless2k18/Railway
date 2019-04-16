package com.example.newu.ticketchecker;

import java.util.HashMap;
import java.util.Map;

public class TrainDetails {
    private String documentID;
    private  String destinationStation;
    private String trainName;
    private String rakeZone;
    private String sourceStation;
    private String trainNo;
    private String type;
    private String[] runningDate;
    private int noOfStations;
    private Map<String,String> coach =new HashMap<String, String>();
    Map<String,TrainRouteStations> route =new HashMap<String, TrainRouteStations>();
    public TrainDetails()
    {

    }

    public String getDocumentID() {
        return documentID;
    }

    public String getDestinationStation() {
        return destinationStation;
    }

    public String getTrainName() {
        return trainName;
    }

    public String getRakeZone() {
        return rakeZone;
    }

    public String getSourceStation() {
        return sourceStation;
    }

    public String getTrainNo() {
        return trainNo;
    }

    public String getType() {
        return type;
    }

    public String[] getRunningDate() {
        return runningDate;
    }

    public Map<String, String> getCoach() {
        return coach;
    }

    public Map<String, TrainRouteStations> getRoute() {
        return route;
    }

    public int getNoOfStations() {
        return noOfStations;
    }
}
