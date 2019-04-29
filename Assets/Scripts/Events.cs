using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Events : MonoBehaviour
{
    private GameObject player;
    private GameObject EventManager;
    public GameObject Firstday, BankClosed, Underpreforming, FirstSkip, Promotion, Term, TermCite, crepper, gud, bud;

    private string destination;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        EventManager = GameObject.Find("EventHandler");
        player.GetComponent<Timer>().pause = true;

        if (player.GetComponent<Player>().GoingToSleep)
        {
            player.GetComponent<Player>().GoingToSleep = false;
            if (!player.GetComponent<Player>().shiftCompleted && !player.GetComponent<Player>().Warned)
            {
                FirstSkip.SetActive(true);
                player.GetComponent<Player>().Warned = true;
                destination = "Home";
            }
            else if (!player.GetComponent<Player>().shiftCompleted)
            {
                Term.SetActive(true);
            }
            else
            {
                player.GetComponent<Player>().shiftCompleted = false;
                player.GetComponent<Timer>().pause = false;
                SceneManager.LoadScene("Home");
            }
        }
        else if (player.GetComponent<Player>().GoingToWork)
        {
            player.GetComponent<Player>().GoingToWork = false;
            if (player.GetComponent<Player>().FirstDay)
            {
                Firstday.SetActive(true);
                player.GetComponent<Player>().FirstDay = false;
                destination = "Bank";
            }
            else if (player.GetComponent<Player>().bankClosed)
            {
                BankClosed.SetActive(true);
                destination = "Home";
;           }
            else if (player.GetComponent<Player>().daysWithoutCitations == player.GetComponent<Player>().dumbcounter)
            {
                player.GetComponent<Player>().dumbcounter++;
                player.GetComponent<Player>().Wage += 60;
                player.GetComponent<Player>().daysWithoutCitations = 0;
                Promotion.SetActive(true);
                destination = "Bank";
            }
            else if ((!player.GetComponent<Player>().WarnCite && player.GetComponent<Player>().citations >= 5 + player.GetComponent<Player>().Day * 2))
            {
                player.GetComponent<Player>().WarnCite = true;
                Underpreforming.SetActive(true);
                destination = "Bank";
            }
            else if(player.GetComponent<Player>().citations >= 7 + player.GetComponent<Player>().Day * 2)
            {
                TermCite.SetActive(true);
            }
            else
            {
                player.GetComponent<Timer>().pause = false;
                SceneManager.LoadScene("Bank");
            }
        }
        else if (player.GetComponent<Player>().GoingToBar)
        {
            player.GetComponent<Player>().GoingToBar = false;
            switch (Random.Range(0, 3))
            {
                case 0:
                    crepper.SetActive(true);
                    destination = "Home";
                    break;
                case 1:
                    gud.SetActive(true);
                    player.GetComponent<Player>().Happiness += .4f;
                    destination = "Home";
                    break;
                case 2:
                    bud.SetActive(true);
                    player.GetComponent<Player>().Happiness -= .1f;
                    destination = "Home";
                    break;
            }
        }
    }


    public void buttonPress()
    {
        player.GetComponent<Timer>().pause = false;
        SceneManager.LoadScene(destination, LoadSceneMode.Single);
    }

    public void quit()
    {
        EventManager.GetComponent<EventManager>().kill();
    }
}
