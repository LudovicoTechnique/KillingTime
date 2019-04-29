using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HomeHud : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text, _date;
    [SerializeField] private UnityEngine.UI.Slider _slider;
    [SerializeField] private GameObject _buttons;
    
    void Start()
    {
        var player = GameObject.Find("Player");
        _text.GetComponent<TimerDisplay>().Player = player;
        _slider.GetComponent<Slider>().Player = player;
        _buttons.GetComponent<Home>().Player = player;
        player.GetComponent<Player>().Happiness = player.GetComponent<Player>().Happiness;
        _date.GetComponent<TextMeshProUGUI>().text = DateFormater.FormatDate(player.GetComponent<Player>().Day, false);
    }
}
