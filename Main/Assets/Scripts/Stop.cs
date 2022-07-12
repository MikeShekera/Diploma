using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stop : MonoBehaviour
{
    private double decelerationAcceleration = 0;
    private double decelerationAccelerationTime = 0;
    private bool decelerationAccelerationCounted = false;
    private double S = 0;
    private void FixedUpdate()
    {
        
        if (DataHolder._stopCarCoeff == 0)
        {

            if (DataHolder._distance <= 100 && (DataHolder._distance / (DataHolder._startSpeed * 1000 / 3600)) < DataHolder._timeToRed && DataHolder._startSpeed != 0)
            {
                DataHolder._output = "В торможении нет необходимости";
                Debug.Log("В торможении нет необходимости");
                DataHolder._stopCarCoeff = 2;
                DataHolder._brakingDistance = 0;
                DataHolder._startSpeedOfBreak = 0;
            }
            else if (DataHolder._distance <= 100 && DataHolder._startSpeed != 0)
            {
                if (DataHolder._stopCarCoeff == 0)
                {
                    DataHolder._brakingDistance = Math.Round(DataHolder._breakCoeff * Mathf.Pow((float)DataHolder._startSpeed,2)/(254*DataHolder._weatherCoeff));
                    DataHolder._startSpeedOfBreak = Math.Round(DataHolder._startSpeed);
                    DataHolder._stopCarCoeff = 1;
                    Debug.Log("Длина тормозного пути" + DataHolder._brakingDistance);
                    if (DataHolder._brakingDistance > 100)
                        S = DataHolder._brakingDistance;
                    else
                        S = 100;
                }
            } 
        }
        if (DataHolder._stopCarCoeff == 1 && DataHolder._startSpeed > 0)
        {
            if (decelerationAccelerationCounted == false)
                StopCar();
            DataHolder._startSpeed = DataHolder._startSpeed - (decelerationAcceleration / 1000 * 3600);
        }
    }

    private void StopCar()
    {
        decelerationAccelerationTime = 2*S / (DataHolder._startSpeed*1000/3600);
        decelerationAcceleration = (DataHolder._startSpeed*1000/3600) / decelerationAccelerationTime/50;
        decelerationAccelerationCounted = true;
        Debug.Log("AAA" + decelerationAcceleration);
        Debug.Log("Time: " + decelerationAccelerationTime);
    }

}
