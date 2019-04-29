using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cup : MonoBehaviour , IPointerClickHandler
{
    public int cupNum;
    public bool active;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("God is dead");
        if(active)
            GetComponentInParent<cupGame>().CheckWin(cupNum);
    }
}
