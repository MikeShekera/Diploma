using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Report
{ 
    public static void AppendToReport()
    {
        Debug.Log("CLICKED");
        ExcelExporter.AppendToReport(
            new string[7]{
                DataHolder._carName,
                DataHolder._BeginSpeed.ToString(),
                DataHolder._beginDistance.ToString(),
                DataHolder._brakingDistance.ToString(),
                DataHolder._startSpeedOfBreak.ToString(),
                DataHolder._beginTimeToRed.ToString(),
                DataHolder._weatherName.ToString()
            }
        );
    }
    public static void ResetReport()
    {
        Debug.Log("Report Reset");
        ExcelExporter.CreateReport();
    }
}
