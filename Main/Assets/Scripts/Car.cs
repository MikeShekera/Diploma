using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Car", menuName = "Assets/Cars")]
public class Car : ScriptableObject
{
    [SerializeField] private int _carID;
    [SerializeField] private string _carBrand;
    [SerializeField] private int _carWeight;
    [SerializeField] private int _horsePowers;
    [SerializeField] private string _driveType;
    [SerializeField] private Sprite _carSprite;
    [SerializeField] private GameObject _carPrefab;
    public int carID => this._carID;
    public string carBrand=> this._carBrand;
    public int carWeight => this._carWeight;
    public int horsePowers => this._horsePowers;
    public string driveType => this._driveType;
    public Sprite carSprite => this._carSprite;
    public GameObject carPrefab => this._carPrefab;
}
 