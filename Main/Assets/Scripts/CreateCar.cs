using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCar : MonoBehaviour
{
    public GameObject[] carPrefabs;

    void Start()
    {
        GameObject car = Instantiate(DataHolder._carPrefab, new Vector3(1.1f,-8f, 0f), Quaternion.Euler(0,0,90));
        car.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        car.AddComponent<MoveCar>();

        DataHolder._breakCoeff = 1 + 0.00008 * (DataHolder._carWeight - 1200);
        DataHolder._BeginSpeed = DataHolder._startSpeed;
        DataHolder._beginTimeToRed = DataHolder._timeToRed;
        Debug.Log(DataHolder._breakCoeff);

    }
}
