using UnityEngine;

public static class LifeTimer
{
    public static int LifeHours;
    public static int LifeMinutes;
    public static int TotalTime;

    public static void ChangeTime(int value)
    {
        TotalTime += value;
        if (TotalTime < 0)
        {
            TotalTime = 0;
        }
        LifeMinutes = TotalTime % 60;
        LifeHours = Mathf.FloorToInt(TotalTime / 60);
    }
}
