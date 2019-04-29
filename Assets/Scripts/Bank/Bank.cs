using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{
    public GameObject Player;
    public GameObject Popup;
    public int choice;
    
    public void Bar(bool overrided)
    {
        if (Player.GetComponent<Player>().shiftCompleted || overrided)
        {
            LifeTimer.ChangeTime(-30);
            Player.GetComponent<Player>().bankClosed = true;
            Player.GetComponent<Player>().GoingToBar = true;
        }
        else
        {
            choice = 1;
            Popup.SetActive(true);
        }
    }

    public void Casino(bool overrided)
    {
        if (Player.GetComponent<Player>().shiftCompleted || overrided)
        {
            LifeTimer.ChangeTime(-10);
            Player.GetComponent<Player>().bankClosed = true;
            SceneManager.LoadScene("Casino");
        }
        else
        {
            choice = 2;
            Popup.SetActive(true);
        }
    }

    public void Home(bool overrided)
    {
        if (Player.GetComponent<Player>().shiftCompleted || overrided)
        {
            LifeTimer.ChangeTime(-15);
            Player.GetComponent<Player>().bankClosed = true;
            SceneManager.LoadScene("Home");
        }
        else
        {
            choice = 3;
            Popup.SetActive(true);
        }
    }

    public void Yes()
    {
        switch (choice)
        {
            case 1:
                Bar(true);
                break;
            case 2:
                Casino(true);
                break;
            case 3:
                Home(true);
                break;
        }
    }

    public void No()
    {
        Popup.SetActive(false);
    }
    
}
