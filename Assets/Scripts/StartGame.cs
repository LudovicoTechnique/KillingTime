using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] private GameObject _player, _slide1, _slide2, _slide3;


    public void ToSlideTwo()
    {
        _slide1.SetActive(false);
        _slide2.SetActive(true);
    }
    
    public void ToSlideThree()
    {
        _slide2.SetActive(false);
        _slide3.SetActive(true);
    }
    
    public void StartGamer()
    {
        _player.GetComponent<Timer>()._stopwatch.Start();
        SceneManager.LoadScene("Home", LoadSceneMode.Single);
    }
}
