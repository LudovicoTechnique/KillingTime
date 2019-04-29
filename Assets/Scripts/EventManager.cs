using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private bool checkingDeath;
    
    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        if (LifeTimer.TotalTime <= 0 && !checkingDeath)
        {
            checkingDeath = true;
            StartCoroutine(DeathCheck());
        }
    }

    IEnumerator DeathCheck()
    {
        yield return new WaitForSeconds(.75f);
        if (LifeTimer.TotalTime <= 0)
        {
            kill();
        }
        else
        {
            checkingDeath = false;
        }
    }

    public void kill()
    {
        SceneManager.LoadScene("Death");
        Destroy(player);
        Destroy(gameObject);
    }
}
