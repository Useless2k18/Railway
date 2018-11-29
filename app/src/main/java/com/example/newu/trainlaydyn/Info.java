package com.example.newu.trainlaydyn;

public class Info {
    String station;
    String num_of_pass;
    public Info(String station,String num_of_pass)
    {
        this.station=station;
        this.num_of_pass= num_of_pass;
    }
    public String getStation()
    {
        return station;
    }
    public String getNum_of_pass()
    {
        return num_of_pass;
    }

}
