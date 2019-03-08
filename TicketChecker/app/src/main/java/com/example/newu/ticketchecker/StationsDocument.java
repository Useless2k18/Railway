package com.example.newu.ticketchecker;

public class StationsDocument {
    private long noOfZone;
    private String [] zoneList; ;


    public long getNoOfZone() {
        return noOfZone;
    }

    public String[] getZoneList() {
        return zoneList;
    }

    public void setNoOfZone(long noOfZone) {
        this.noOfZone = noOfZone;
    }

    public void setZoneList(String[] zoneList) {
        this.zoneList = zoneList;
    }
}
