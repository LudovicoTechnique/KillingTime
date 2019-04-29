using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Home : MonoBehaviour
{
    [SerializeField] private Button _sleep, _computer, _bank, _bar, _casino;
    public GameObject Player;
    [SerializeField] private GameObject fadeOut;
    [SerializeField] private Animator anim;
    public GameObject popup;

    public void Sleep(bool overrided)
    {
        if (Player.GetComponent<Player>().shiftCompleted || overrided)
        {
            if (overrided)
            {
                Player.GetComponent<Player>().daysSkipped++;
            }
            StartCoroutine(WaitUntilFadeOut());
            LifeTimer.ChangeTime(-60);
            ++Player.GetComponent<Player>().Day;
            --Player.GetComponent<Player>().CompUsage;
            Player.GetComponent<Player>().Happiness -= .15f;
            Player.GetComponent<Player>().bankClosed = false;
        }
        else
        {
            popup.SetActive(true);
        }
    }

    public void No()
    {
        popup.SetActive(false);
    }

    IEnumerator WaitUntilFadeOut()
    {
        fadeOut.SetActive(true);
        anim.SetTrigger("FadeOut");
        yield return new WaitUntil(() => fadeOut.GetComponent<Image>().color.a >= .98);
        Player.GetComponent<Player>().GoingToSleep = true;
    }

    public void Computer()
    {
        LifeTimer.ChangeTime(-15);
        var amount = .15f - (Player.GetComponent<Player>().CompUsage * .025f);
        Player.GetComponent<Player>().Happiness += amount > 0 ? amount : 0;
        ++Player.GetComponent<Player>().CompUsage;

    }

    public void Bank()
    {
        LifeTimer.ChangeTime(-15);
        Player.GetComponent<Player>().GoingToWork = true;
    }

    public void Bar()
    {
        LifeTimer.ChangeTime(-15);
        Player.GetComponent<Player>().GoingToBar = true;
    }

    public void Casino()
    {
        LifeTimer.ChangeTime(-10);
        SceneManager.LoadScene("Casino", LoadSceneMode.Single);
    }
}
