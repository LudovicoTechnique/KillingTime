using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BankHud : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text, _date;
    [SerializeField] private UnityEngine.UI.Slider _slider;
    [SerializeField] private GameObject _buttons, _loanFactory, _loanPro, _bank;
    
    void Start()
    {
        var player = GameObject.Find("Player");
        _text.GetComponent<TimerDisplay>().Player = player;
        _slider.GetComponent<Slider>().Player = player;
        _loanFactory.GetComponent<LoanFactory>().Player = player;
        _loanPro.GetComponent<FormProcessor>().Player = player;
        _bank.GetComponent<Bank>().Player = player;
        _date.GetComponent<TextMeshProUGUI>().text = DateFormater.FormatDate(player.GetComponent<Player>().Day, false);
    }
}
