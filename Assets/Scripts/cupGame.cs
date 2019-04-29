using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cupGame : MonoBehaviour
{
    public GameObject casino;
    public void CheckWin(int cup)
    {
        casino.GetComponent<Casino>().CheckWin(cup);
        GetComponentInChildren<Cup>().active = false;
    }
}
