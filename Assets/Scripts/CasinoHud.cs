using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CasinoHud : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text, _date;
    [SerializeField] private UnityEngine.UI.Slider _slider;
    [SerializeField] private GameObject _buttons;
    
    void Start()
    {
        var player = GameObject.Find("Player");
        _text.GetComponent<TimerDisplay>().Player = player;
        _slider.GetComponent<Slider>().Player = player;
        _buttons.GetComponent<Casino>().Player = player;
        _date.GetComponent<TextMeshProUGUI>().text = DateFormater.FormatDate(player.GetComponent<Player>().Day, false);
    }
}
