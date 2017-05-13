using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/**
 * Collect all errors in game
 * */
public class LoggingManager : ManagerSingleTone<LoggingManager>
{
    private List<string> _loggindList = new List<string>();
    private Text _debugConsole;
    private string _logMsg = "";
   void Start()
    {
        GameObject debugGO = GameObject.Find(TagNames.TAG_DEBUG);
        if (debugGO != null)
        {
            _debugConsole = debugGO.GetComponentInChildren<Text>();
        }
    }

    public void AddLog(string message)
    {
        Debug.Log(message);
        _loggindList.Add(message);

        if (_debugConsole != null)
            _logMsg+= '\n' + message;
    }

    public void ShowError(string message)
    {
        Debug.LogError(message);

        if (_debugConsole != null)
            _logMsg += '\n' + "<color=red>" + message + "</color>";
    }

    private void Update()
    {
        if (_debugConsole != null)
        {
            _debugConsole.text = _logMsg;
        }
    }



    public static void AddErrorToLog(string error)
    {
        LoggingManager.Instance.ShowError("ERROR - " + error);
    }

    internal static void Log(bool v)
    {
        throw new NotImplementedException();
    }

    public static void Log(string msg)
    {
        LoggingManager.Instance.AddLog(msg);
    }
}
