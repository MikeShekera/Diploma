using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class InputOutput : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI speed;
    [SerializeField] private TextMeshProUGUI distance;
    [SerializeField] private TextMeshProUGUI time;
    [SerializeField] private SpriteRenderer trafficLight;
    [SerializeField] private Sprite redLight;
    [SerializeField] private Sprite greenLight;
    [SerializeField] private Button endButton;
    private bool gas = false;
    private bool carBreak = false;
    public void BreakClick()
    {
        carBreak = !carBreak;
    }
    public void GasClick()
    {
        gas = !gas;
    }
    public void FixedUpdate()
    {
        ShowLight();
        speed.text = DataHolder._startSpeed.ToString("0.0") + "km/h";
        DataHolder._distance = DataHolder._distance - (DataHolder._startSpeed * 1000 / (3600 * 50));
        distance.text = DataHolder._distance.ToString("0.0") + "m";
        if (DataHolder._timeToRed > 0)
        {
            DataHolder._timeToRed = DataHolder._timeToRed - 0.02;
        }
        time.text = DataHolder._timeToRed.ToString("0.0") + "sec";
        if (gas == true)
        {
            DataHolder._startSpeed = DataHolder._startSpeed + 0.2;
        }
        else if(carBreak == true)
        {
            DataHolder._startSpeed = DataHolder._startSpeed - 0.3;
        }
        ShowQuitButton();
    }
    private void ShowLight()
    {
        if (DataHolder._timeToRed > 0)
            trafficLight.sprite = greenLight;
        else
            trafficLight.sprite = redLight;
    }

    private void ShowQuitButton()
    {
        if (DataHolder._startSpeed <= 0)
        {
            DataHolder._startSpeed = 0;
            endButton.gameObject.SetActive(true);
        }
        else if(DataHolder._distance < 0)
        {
            endButton.gameObject.SetActive(true);
        }
    }
    public void EndSimulatuion()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
