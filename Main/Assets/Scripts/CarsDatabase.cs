using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Cars Database", menuName = "Assets/Databases/Cars Database")]
public class CarsDatabase : ScriptableObject
{
    public List<Car> allCars;
}
 