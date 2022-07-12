using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataHolder
{
    public static string _carName;
    public static string _weatherName;
    public static string _brakeName;
    public static string _driveTypeName;

    public static double _distance;
    public static double _startSpeed;
    public static double _timeToRed;

    public static double _beginDistance;
    public static double _beginTimeToRed;
    public static double _BeginSpeed;
    public static double _startSpeedOfBreak;

    public static int _carWeight;
    public static double _weatherCoeff;
    public static double _breakCoeff;
    public static double _brakingDistance;
    public static int _stopCarCoeff = 0;
    public static string _output;
    public static int _transmission;
    public static GameObject _carPrefab = null;
}
