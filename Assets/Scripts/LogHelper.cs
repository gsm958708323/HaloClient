using System.Collections;
using UnityEngine;

public class LogHelper 
{
    public static void Log(string str)
    {
        Debug.Log(str);
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