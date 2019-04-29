using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Blink());
        StartCoroutine(GoBackToYourCountry());
    }

    IEnumerator Blink()
    {
        GetComponent<TextMeshProUGUI>().enabled = !GetComponent<TextMeshProUGUI>().enabled;
        yield return new WaitForSeconds(.35f);
        StartCoroutine(Blink());
    }

    IEnumerator GoBackToYourCountry()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("Menu");
    }
}
