using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDown : MonoBehaviour
{
    CarsDatabase cars;
    public Dropdown dropdown;
    public Image selectedCar;
    List<string> names = new List<string>();
    void Start()
    {
        var allCarsBrands = Resources.LoadAll<Car>("Cars");
        foreach (var car in allCarsBrands)
        {
            names.Add(car.carBrand);
        }
        dropdown.AddOptions(names);
    }

    public void Dropdown_IDChanged(int id)
    {
        var allCarsBrands = Resources.LoadAll<Car>("Cars");
        foreach (var car in allCarsBrands)
        {
            if(car.carID == id+1)
            {
                selectedCar.sprite = car.carSprite;
            }
        }
    }
}
