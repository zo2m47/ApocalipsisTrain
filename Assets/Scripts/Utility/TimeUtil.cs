using UnityEngine;
using System.Collections;
using System;

/**
 * Useful time utilities to convert time formats and display formats
 */
public class TimeUtil
{


    public static System.DateTime UnixTimeStampToUTCDateTime(double unixTimeStamp)
    {
        // Unix timestamp is seconds past epoch
        DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);

        dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToUniversalTime();
        return dtDateTime;
    }

    public static System.DateTime UnixTimeStampToLocalDateTime(double unixTimeStamp)
    {
        // Unix timestamp is seconds past epoch
        DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
        dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();

        return dtDateTime;
    }

    public static DateTime DateTimeFromTS(uint ts)
    {
        return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(ts);
    }
    // need for testing with out werver 
    public static double ConvertToTimestamp(DateTime value)
    {
        //create Timespan by subtracting the value provided from
        //the Unix Epoch
        TimeSpan span = (value - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime());

        //return the total seconds (which is a UNIX timestamp)
        return (double)span.TotalSeconds;
    }

    public static string GetHHcolMMfromTS(uint ts)
    {
        DateTime utsDateTime = DateTimeFromTS(ts);
        int hour = utsDateTime.Hour;
        int min = utsDateTime.Minute;
        return hour + ":" + (min < 10 ? "0" + min : min.ToString());
    }

    public static string FormatFinishTimeStrFromMS(int mss)
    {
        int ms = mss % 1000;
        int s = (mss / 1000) % 60;
        int m = (mss / 1000) / 60;
        string sStr = s < 10 ? "0" + s : s.ToString();
        string msStr = ms.ToString();
        if (ms < 10)
        {
            msStr = "00" + ms;
        }
        else if (ms < 100)
        {
            msStr = "0" + ms;
        }
        return m + ":" + sStr + "." + msStr;
    }
}
