using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LastSceneController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI distance;
    [SerializeField] private TextMeshProUGUI result;

    private void Start()
    {
        distance.text = DataHolder._brakingDistance.ToString() + "m";
        if(DataHolder._brakingDistance > 100)
        {
            result.text = "Столкновения избежать не удалось";
            result.color = Color.red;
        }
        else if(DataHolder._brakingDistance == 0)
        {
            result.text = "В торможении не было необходимости";
        }
        else
        {
            result.text = "Произошла нормальная остановка";
            result.color = Color.green;
        }
        Report.AppendToReport();
    }
    public void Quit()
    {
        Application.Quit();
    }
}
