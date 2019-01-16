package com.example.newu.ticketchecker;

import java.util.HashMap;
import java.util.Map;

public class TteDetails {
    private String documentID;
    private  String tteID;
    private String trainNo;
    private String lastName;
    private String firstName;
    private String date;

    private String ZONE;
    Map<String,String>STATION_FROM=new HashMap<String, String>();
    Map<String,String>STATION_TO=new HashMap<String, String>();
public TteDetails(){

}


    public TteDetails(String ttid, String ttfrstname, String ttlastname, String zone )
    {

        this.tteID =ttid;
        this.trainNo =ttfrstname;
        this.lastName =ttlastname;
        this.ZONE=zone;
        this.STATION_FROM.put("STATION_FRM_ID","");
        this.STATION_FROM.put("TT_BOARD_TIME:","");
        this.STATION_TO.put("STATION_TO_ID","");
        this.STATION_TO.put("TT_DEBOARD_TIME","");

        //STATION_FRM_ID.put("STATION_FRM_ID","");
        //TT_BOARD_TIME.put("TT_BOARD_TIME","");
        //STATION_TO_ID.put("STATION_TO_ID","");
        //TT_DEBOARD_TIME.put("TT_DEBOARD_TIME","");
        //this.STATION_FROM()


    }

    public String gettt_ID() {
        return tteID;
    }

    public String getzone() {
        return ZONE;
    }

   public String getTrainNo() {
        return trainNo;
    }

    public String getLastName() {
        return lastName;
    }


}
