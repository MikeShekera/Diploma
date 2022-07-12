using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ExcelExporter 
{
    private static string reportFolderName = "Report";
    private static string reportFileName = "report.csv";
    private static string reportSeparator = ";";
    private static string[] reportHeaders = new string[7]{
        "Car",
        "Start speed (km/h)",
        "Distance to traffic light (m)",
        "Braking distance (m)",
        "Speed at the start of breaking (km/h)",
        "Time to red light (sec)",
        "Weather"
    };
    private static string timeStampHeader = "Time stamp";

    static void VerifyDirectory()
    {
        string dir = GetDirectoryPath();
        if(!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
    }

    public static void AppendToReport(string[] strings)
    {
        VerifyDirectory();
        VerifyFile();
        using(StreamWriter sw = File.AppendText(GetFilePath()))
        {
            string finalString = "";
            for(int i = 0; i<strings.Length; i++)
            {
                if(finalString != "")
                {
                    finalString += reportSeparator;
                }
                finalString += strings[i];
            }
            finalString += reportSeparator +GetTimeStamp();
            sw.WriteLine(finalString);
        }
    }

    public static void CreateReport()
    {
        using (StreamWriter sw = File.CreateText(GetFilePath()))
        {
            string finalString = "";
            for(int i = 0; i<reportHeaders.Length; i++)
            {
                if(finalString != "")
                {
                    finalString += reportSeparator;
                }
                finalString += reportHeaders[i];
            }
            finalString += reportSeparator + timeStampHeader;
            sw.WriteLine(finalString);
        }
    }

    static void VerifyFile()
    {
        string file = GetFilePath();
        if (!File.Exists(file))
        {
            CreateReport();
        }
    }

    static string GetDirectoryPath()
    {
        return Application.dataPath + "/" + reportFolderName;
    }

    static string GetFilePath()
    {
        return GetDirectoryPath() + "/" + reportFileName;
    }

    static string GetTimeStamp()
    {
        return System.DateTime.Now.ToString();
    }
}
