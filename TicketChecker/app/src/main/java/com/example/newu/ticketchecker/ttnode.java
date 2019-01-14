package com.example.newu.ticketchecker;
import com.google.firebase.firestore.Exclude;

import java.util.HashMap;
import java.util.Map;

public class ttnode {
    private String documentID;
    private  String TT_ID;
    private String F_NAME;
    private String L_NAME;
    private String ZONE;
    Map<String,String>STATION_FROM=new HashMap<String, String>();
    Map<String,String>STATION_TO=new HashMap<String, String>();
public ttnode(){

}


    public ttnode(String ttid,String ttfrstname,String ttlastname,String zone )
    {

        this.TT_ID=ttid;
        this.F_NAME=ttfrstname;
        this.L_NAME=ttlastname;
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
        return TT_ID;
    }

    public String getzone() {
        return ZONE;
    }

   public String getF_NAME() {
        return F_NAME;
    }

    public String getL_NAME() {
        return L_NAME;
    }


}
