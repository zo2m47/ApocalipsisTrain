using System;
using System.Collections.Generic;
using UnityEngine;
/**
 * Logic of all game play process 
 * */
public class GameViewManager : ManagerSingleTone<GameViewManager>, IInitilizationProcess
{
    private GameObject _container;
    /**
     * Initializaiotn process 
     * */
    private EnumInitializationStatus _initializationStatus;
    public bool allInitializated
    {
        get
        {
            return _initializationStatis == EnumInitializationStatus.initializated;
        }
    }

    public string classNameInInitialization
    {
        get
        {
            return "Game play manager";
        }
    }

    public EnumInitializationStatus initializationStatus
    {
        get
        {
            return _initializationStatis;
        }
    }

    public void StartInitialization()
    {
        _initializationStatus = EnumInitializationStatus.inProgress;
        _container = GameObject.FindGameObjectWithTag(TagNames.TAG_GAME_VIEW_CONTAINER);
        if (_container == null)
        {
            LoggingManager.AddErrorToLog("Didn't found game object by tag " + TagNames.TAG_GAME_VIEW_CONTAINER);
            _initializationStatus = EnumInitializationStatus.initializationError;
            return;
        }
        _initializationStatus = EnumInitializationStatus.initializated;
    }
}
