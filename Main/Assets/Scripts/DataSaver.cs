using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DataSaver : MonoBehaviour
{
    [SerializeField] private InputField distanceToTrafficLight;
    [SerializeField] private InputField speed;
    [SerializeField] private InputField timeToRed;
    [SerializeField] private ToggleGroup weather;
    [SerializeField] private ToggleGroup brakeType;
    [SerializeField] private ToggleGroup carDriveType;
    [SerializeField] private Dropdown car;

    public void SaveCahnges()
    {
        SetDistance();
        SetSpeed();
        SetTransmission();
        SetTimeToRed();
        SetWeather();
        SetBrakeType();
        SetDriveType();
        SetCar(car);
        Debug.Log("Данные сохранены");
        ChoosePrefab(DataHolder._carName);
        //CheckSaved();
    }


    public void SetCar(Dropdown sender)
    {
        DataHolder._carName = car.options[car.value].text;
    }

    public void SetDistance()
    {
        if (distanceToTrafficLight.text == "")
        {
            Debug.Log("Missing input");
        }
        else
        {
            DataHolder._distance = int.Parse(distanceToTrafficLight.text);
            DataHolder._beginDistance = int.Parse(distanceToTrafficLight.text);
        }
    }

    public void SetWeather()
    {
        Toggle theActiveToggle = weather.ActiveToggles().FirstOrDefault();
        DataHolder._weatherName = theActiveToggle.name;
        if (theActiveToggle.name == "Sunny")
            DataHolder._weatherCoeff = 0.7;
        else if(theActiveToggle.name == "Rainy")
            DataHolder._weatherCoeff = 0.4;
        else if (theActiveToggle.name == "Snowy")
            DataHolder._weatherCoeff = 0.2;
        else if (theActiveToggle.name == "Icy")
            DataHolder._weatherCoeff = 0.1;
        Debug.Log(DataHolder._weatherCoeff);
    }

    public void SetBrakeType()
    {
        Toggle theActiveToggle = brakeType.ActiveToggles().FirstOrDefault();
        DataHolder._brakeName = theActiveToggle.name;
    }

    public void SetDriveType()
    {
        Toggle theActiveToggle = carDriveType.ActiveToggles().FirstOrDefault();
        DataHolder._driveTypeName = theActiveToggle.name;
    }

    public void SetSpeed()
    {
        if (speed.text == "")
        {
            Debug.Log("Missing input");
        }
        else
        {
            DataHolder._startSpeed = int.Parse(speed.text);
            Math.Round(DataHolder._BeginSpeed = int.Parse(speed.text));
        }
    }

    public void SetTimeToRed()
    {
        if(timeToRed.text == "")
        {
            Debug.Log("Missing input");
        }
        else
        {
            DataHolder._timeToRed = float.Parse(timeToRed.text);
            Math.Round(DataHolder._beginTimeToRed = float.Parse(timeToRed.text));
        }
    }

    public void ChoosePrefab(string carName)
    {
        var allCarsBrands = Resources.LoadAll<Car>("Cars");
        foreach (var car in allCarsBrands)
        {
            if (car.carBrand == carName)
            {
                DataHolder._carPrefab = car.carPrefab;
                DataHolder._carWeight = car.carWeight;
            }
        }
    }

    public void SetTransmission()
    {
        if (DataHolder._startSpeed < 20)
            DataHolder._transmission = 1;
        else if (DataHolder._startSpeed > 20 && DataHolder._startSpeed < 40)
            DataHolder._transmission = 2;
        else if (DataHolder._startSpeed > 40 && DataHolder._startSpeed < 60)
            DataHolder._transmission = 3;
        else if (DataHolder._startSpeed > 60 && DataHolder._startSpeed < 90)
            DataHolder._transmission = 4;
        else if (DataHolder._startSpeed > 90 && DataHolder._startSpeed < 150)
            DataHolder._transmission = 5;
        else if (DataHolder._startSpeed > 150 && DataHolder._startSpeed < 210)
            DataHolder._transmission = 6;
        else
            Debug.Log("Error");
        Debug.Log(DataHolder._transmission);
    }

    public void CheckSaved()
    {
        Debug.Log(DataHolder._distance);
        Debug.Log(DataHolder._startSpeed);
        Debug.Log(DataHolder._timeToRed);
        Debug.Log(DataHolder._weatherName);
        Debug.Log(DataHolder._brakeName);
        Debug.Log(DataHolder._driveTypeName);
        Debug.Log(DataHolder._carName);
    }
}
