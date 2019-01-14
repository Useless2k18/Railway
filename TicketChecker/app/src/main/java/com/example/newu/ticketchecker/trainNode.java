package com.example.newu.ticketchecker;

import java.util.HashMap;
import java.util.Map;

public class trainNode {
    private String documentID;
    private  String DEST_STN;
    private String NAME;
    private String RAKE_ZONE;
    private String SRC_STN;
    private String TRAIN_NO;
    private String TYPE;
    private String[] RUNN_DATE;
    private int NO_OF_STATIONS;
    Map<String,String> COACH=new HashMap<String, String>();
    Map<String,trainRouteStations>ROUTE=new HashMap<String, trainRouteStations>();

    public String getDocumentID() {
        return documentID;
    }

    public String getDEST_STN() {
        return DEST_STN;
    }

    public String getNAME() {
        return NAME;
    }

    public String getRAKE_ZONE() {
        return RAKE_ZONE;
    }

    public String getSRC_STN() {
        return SRC_STN;
    }

    public String getTRAIN_NO() {
        return TRAIN_NO;
    }

    public String getTYPE() {
        return TYPE;
    }

    public String[] getRUNN_DATE() {
        return RUNN_DATE;
    }

    public Map<String, String> getCOACH() {
        return COACH;
    }

    public Map<String, trainRouteStations> getROUTE() {
        return ROUTE;
    }

    public int getNO_OF_STATIONS() {
        return NO_OF_STATIONS;
    }
}
