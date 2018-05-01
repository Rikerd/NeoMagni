using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TimerStat {

    private static int minute;
    private static int second;

    public static int Minute
    {
        get
        {
            return minute;
        }

        set
        {
            minute = value;
        }
    }

    public static int Second
    {
        get
        {
            return second;
        }

        set
        {
            second = value;
        }
    }
}
