using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TimeFormater
{
    public static string FormatTime(int value, int type)
    {
        switch (type)
        {
            case 1:
                return $"{value} minutes";
            case 2:
                return $"{(double)Mathf.Round((100 * value) / 60)/ 100 } hours"; 
            default:
                var minutes = value % 60;
                var hours = value / 60;
                return $"{hours}:{(minutes < 10 ?  "0" + minutes : minutes.ToString())}";
        }       
    }
}
