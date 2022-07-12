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
            result.text = "������������ �������� �� �������";
            result.color = Color.red;
        }
        else if(DataHolder._brakingDistance == 0)
        {
            result.text = "� ���������� �� ���� �������������";
        }
        else
        {
            result.text = "��������� ���������� ���������";
            result.color = Color.green;
        }
        Report.AppendToReport();
    }
    public void Quit()
    {
        Application.Quit();
    }
}
