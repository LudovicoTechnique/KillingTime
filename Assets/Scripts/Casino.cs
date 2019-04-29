
using UnityEngine;
using UnityEngine.SceneManagement;

public class Casino : MonoBehaviour
{
    public GameObject Player;
    public Animator Animator;
    public GameObject play;
    private int _ballLocation;
    public GameObject ball;

    public void Bar()
    {
        LifeTimer.ChangeTime(-20);
        Player.GetComponent<Player>().GoingToBar = true;
    }

    public void Bank()
    {
        LifeTimer.ChangeTime(-10);
        Player.GetComponent<Player>().GoingToWork = true;
    }

    public void Home()
    {
        LifeTimer.ChangeTime(-10);
        SceneManager.LoadScene("Home", LoadSceneMode.Single);
    }

    public void Play()
    {
        ball.GetComponent<RectTransform>().anchoredPosition = new Vector2(16, -Screen.height / 4f);
        LifeTimer.ChangeTime(-20);
        Animator.SetTrigger("Start");
        _ballLocation = Random.Range(0, 3);
        play.SetActive(false);
    }

    public void CheckWin(int cup)
    {

        switch (_ballLocation)
        {
            case 0:
                ball.GetComponent<RectTransform>().anchoredPosition = new Vector2(-629, -Screen.height / 4f);
                break;
            case 1:
                ball.GetComponent<RectTransform>().anchoredPosition = new Vector2(16, -Screen.height / 4f);
                break;
            case 2:
                ball.GetComponent<RectTransform>().anchoredPosition = new Vector2(645, -Screen.height / 4f);
                break;
        }
        
        if (cup - 1 == _ballLocation)
        {
            LifeTimer.ChangeTime(40);
            Player.GetComponent<Player>().Happiness += .1f;
        }   
        Animator.SetTrigger("OnSelect");
        play.SetActive(true);
    }
}
