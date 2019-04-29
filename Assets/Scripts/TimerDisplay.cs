using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerDisplay : MonoBehaviour
{

    public GameObject Player;
    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = Player.GetComponent<Timer>().time;
    }
}
