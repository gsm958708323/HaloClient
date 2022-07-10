using System.Collections;
using UnityEngine;

public class LogHelper 
{
    public static void Log(string str)
    {
        Debug.Log(str);
    }

    public static void LogYellow(string str)
    {
        Debug.Log($"<color=yellow>{str}</color>");
    }

    public static void LogBlue(string str)
    {
        Debug.Log($"<color=blue>{str}</color>");
    }

    public static void LogGreen(string str)
    {
        Debug.Log($"<color=green>{str}</color>");
    }
    public static void LogError(string str)
    {
        Debug.LogError(str);
    }

    public static void LogWarning(string str)
    {
        Debug.LogWarning(str);
    }
}