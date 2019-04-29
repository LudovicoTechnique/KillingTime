using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DateFormater 
{
    private static readonly int IntialMonth = 8;
    private static readonly int IntialDay = 16;
    private static readonly int IntialYear = 82;

    private static readonly List<int> DaysPerMoth = new List<int>
    {
        31,
        28,
        31,
        30,
        31,
        30,
        31,
        31,
        30,
        31,
        30,
        31
    };

    public enum DayOfTheWeek
    {
        Mon,
        Tues,
        Wed,
        Thur,
        Fri,
        Sat,
        Sun        
    }

    public static string FormatDate(int daysPasts, bool errors)
    {               
        int monthsPast = IntialMonth;
        int yearsPast = IntialYear;
        var dayOfTheWeek = (DayOfTheWeek) (daysPasts % 7);
        var daysPast = IntialDay + daysPasts;
        
        if (errors)
        {
            var result = Random.Range(0, 6);
            switch (result)
            {
                case 0:
                    daysPast--;
                    break;
                case 1:
                    daysPast -= 2;
                    break;
                case 2:
                    daysPast -= Random.Range(0, 2) + 1;
                    break;
                case 3:
                    yearsPast--;
                    break;
                case 4:
                    monthsPast--;
                    if (monthsPast <= 0)
                        monthsPast = 12;
                    break;
                case 6:
                    dayOfTheWeek = (DayOfTheWeek) Random.Range(0, 7);
                    break;
            }

            if (daysPast <= 0)
            {
                monthsPast--;
                daysPast = DaysPerMoth[monthsPast - 1];
            }
        }
        
        while (daysPast > DaysPerMoth[monthsPast - 1])
        {
            daysPast %= DaysPerMoth[monthsPast - 1];
            daysPast++;
            monthsPast++;
        }

        if (monthsPast > 12)
        {
            monthsPast %= 13;
            monthsPast++;
            yearsPast++;
        }

        return $"{dayOfTheWeek} {monthsPast}/{daysPast}/{yearsPast}";
    }
}
