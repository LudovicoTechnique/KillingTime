using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class Timer : MonoBehaviour
{
    public readonly Stopwatch _stopwatch = new Stopwatch();
    public string time;
    public bool pause;

    void Start()
    {

    }
    
    
    private void CountDown()
    {
        LifeTimer.ChangeTime(-1);
    }

    private void Update()
    {
        if (_stopwatch.ElapsedMilliseconds >= GetComponent<Player>().TrueHappiness * 1000 && !pause)
        {
            CountDown();
            _stopwatch.Restart();
        }
        
        time = $"{LifeTimer.LifeHours}:{(LifeTimer.LifeMinutes < 10 ?  "0" + LifeTimer.LifeMinutes : LifeTimer.LifeMinutes.ToString())}";
    }
    
    
    void Awake()
    {
        LifeTimer.LifeHours = 3;
        LifeTimer.LifeMinutes = 0;
        LifeTimer.TotalTime = 180;
    }
}
