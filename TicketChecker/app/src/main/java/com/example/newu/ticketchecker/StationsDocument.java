package com.example.newu.ticketchecker;

import java.util.List;

public class StationsDocument {
    private static long noOfZone;
    private List<String> zoneList; ;


    public static long getNoOfZone() {
        return noOfZone;
    }

    public List<String> getZoneList() {
        return zoneList;
    }

    public void setNoOfZone(long noOfZone) {
        this.noOfZone = noOfZone;
    }

    public void setZoneList(List<String> zoneList) {
        this.zoneList = zoneList;
    }
}
