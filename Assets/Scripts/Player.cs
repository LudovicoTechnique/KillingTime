using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public List<Sprite> faces;
    public GameObject face;
    public int citations;
    public int daysWithoutCitations;
    public int daysSkipped;
    public bool bankClosed;
    public GameObject EventManager;
    public int Wage;
    public bool Warned;
    public bool WarnCite;
    public bool shiftCompleted;
    public int dumbcounter;

    public bool FirstDay, goingToSleep, goingToBar;
    private bool goingToWork;
    
    
    public float Happiness
    {
        get { return _happiness; }
        set
        {
            _happiness = value;
            if (_happiness > 2)
                _happiness = 2;
            else if (_happiness < 0)
                _happiness = 0;
            
            TrueHappiness = Mathf.Pow(Happiness + 1.8f, 2) / 8;


            if (face == null)
                face = GameObject.Find("Face");
            if (face == null){ return;}
            
            if (_happiness > 1.65)
                face.GetComponent<Image>().sprite = faces[0];
            else if (_happiness > 1.25)
                face.GetComponent<Image>().sprite = faces[1];
            else if (_happiness > .85)
                face.GetComponent<Image>().sprite = faces[2];
            else if (_happiness > .5)
                face.GetComponent<Image>().sprite = faces[3];
            else
                face.GetComponent<Image>().sprite = faces[4];
        }
    }

    public bool GoingToWork
    {
        get { return goingToWork; }
        set
        {
            goingToWork = value;
            if (value)
            {
                SceneManager.LoadScene("Events");
            }
        }
    }
    
    public bool GoingToSleep
    {
        get { return goingToSleep; }
        set
        {
            goingToSleep= value;
            if (value)
            {
                SceneManager.LoadScene("Events");
            }
        }
    }
    
    public bool GoingToBar
    {
        get { return goingToBar; }
        set
        {
            goingToBar= value;
            if (value)
            {
                SceneManager.LoadScene("Events");
            }
        }
    }
    
    public float TrueHappiness;

    public int CompUsage
    {
        get => _compUsage;
        set
        {
            _compUsage= value;
            if (_compUsage < 0)
                _compUsage = 0;
        }
    }

    private int _compUsage;
    public int Day;
    public bool Worked;
    private float _happiness;


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        Happiness = 1;
        CompUsage = 0;
        FirstDay = true;
        Wage = 150;
        dumbcounter = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
