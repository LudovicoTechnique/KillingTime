using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class FormProcessor : MonoBehaviour
{
    public GameObject Form;
    public GameObject Factory;
    public int Quota;
    public int Mistakes;
    public GameObject Player, Response;
    public GameObject Canvas;
    public GameObject Check;

    public GameObject yes, no, startShift;

    public GameObject quota;

    public void SubmitAnswer(bool response)
    {
        if (Form.GetComponent<Form>().Acceptable == response)
        {
            /*       
                   Response.GetComponent<Image>().color = Color.green;
                   Response.GetComponentInChildren<TextMeshProUGUI>().text = "";
                   */
        }
        else
        {
            var newResponse = Instantiate(Response, Canvas.transform);
            newResponse.transform.position = new Vector3(0, Screen.height / 2, 0);
            newResponse.transform.rotation = Quaternion.Euler(0,0,Random.Range(-200,200) * .1f);
            newResponse.GetComponent<Citation>().Body.text = Form.GetComponent<Form>().FailureMessage;
            newResponse.GetComponent<Animator>().SetTrigger("SlideIn");
            Mistakes++;
        }

        Quota--;
        quota.GetComponent<TextMeshProUGUI>().text = "Quota: " + Quota;
        Destroy(Form);
        if (Quota != 0)
        {
            Factory.GetComponent<LoanFactory>().GenerateForm();
        }
        else
        {
            yes.SetActive(false);
            no.SetActive(false);
            Check.SetActive(true);
            Check.GetComponentInChildren<TextMeshProUGUI>().text =
                TimeFormater.FormatTime(Player.GetComponent<Player>().Wage - Mistakes * 15, 0);
            LifeTimer.TotalTime += Player.GetComponent<Player>().Wage - (Mistakes * 15);
            Player.GetComponent<Player>().citations += Mistakes;
            if (Mistakes == 0)
            {
                Player.GetComponent<Player>().daysWithoutCitations++;
            }
            Player.GetComponent<Player>().shiftCompleted = true;    
        }
    }

    public void StartShift()
    {
        Quota = ((1 + (int) Math.Round((decimal) (Player.GetComponent<Player>().Day / 5))) > 3
                    ? 3
                    : (1 + (int) Math.Round((decimal) (Player.GetComponent<Player>().Day / 5)))) *
                Player.GetComponent<Player>().Day + 6;
        Mistakes = 0;
        //quota.SetActive(true);
        yes.SetActive(true);
        no.SetActive(true);
        startShift.SetActive(false);
        quota.GetComponent<TextMeshProUGUI>().text = "Quota: " + Quota;
        Factory.GetComponent<LoanFactory>().GenerateForm();
    }
}
