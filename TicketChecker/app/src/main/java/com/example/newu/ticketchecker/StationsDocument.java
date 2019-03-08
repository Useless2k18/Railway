package com.example.newu.ticketchecker;

public class StationsDocument {
    private int noOfZone;
    private String [] zoneList; ;


    public int getNoOfZone() {
        return noOfZone;
    }

    public String[] getZoneList() {
        return zoneList;
    }

    public void setNoOfZone(int noOfZone) {
        this.noOfZone = noOfZone;
    }

    public void setZoneList(String[] zoneList) {
        this.zoneList = zoneList;
    }
}
