using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slider : MonoBehaviour
{
    public GameObject Player;

    // Update is called once per frame
    void Update()
    {
        GetComponent<UnityEngine.UI.Slider>().value = Player.GetComponent<Player>().Happiness;
    }
}
