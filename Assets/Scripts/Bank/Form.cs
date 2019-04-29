using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class Form : MonoBehaviour
{
    public string Name;

    public string SubmitBy;

    public int Amount;

    public string BodyText;

    public bool Acceptable;

    public string FailureMessage;

    [SerializeField] private GameObject _name, _submitBy, _amount, _bodyText;

    private int randNum;
    
    private void Start()
    {
        randNum = Random.Range(0, 3);
    }

    public void SetValues()
    {
        _name.GetComponent<TextMeshProUGUI>().text = "Name: " + Name;
        _submitBy.GetComponent<TextMeshProUGUI>().text = "Submit By: " + SubmitBy;
        _amount.GetComponent<TextMeshProUGUI>().text = "Amount: " + TimeFormater.FormatTime(Amount, randNum);
        _bodyText.GetComponent<TextMeshProUGUI>().text = BodyText;
    }
}
