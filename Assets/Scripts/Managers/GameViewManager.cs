using System;
using System.Collections.Generic;
using UnityEngine;
/**
 * Logic of all game play process 
 * */
public class GameViewManager : ManagerSingleTone<GameViewManager>, IInitilizationProcess
{
    private GameObject _container;
    private LocomotiveViewManager _locomotiveViewManager;

    /**
     * Initializaiotn process 
     * */
    private EnumInitializationStatus _initializationStatus;
    public bool allInitializated
    {
        get
        {
            return _initializationStatus == EnumInitializationStatus.initializated;
        }
    }

    public string ClassNameInInitialization
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
            return _initializationStatus;
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

        //creat prefab with train game view manager for view train 
        _locomotiveViewManager = PrefabCreatorManager.Instance.InstanceComponent<LocomotiveViewManager>(PrefabsURL.LOCOMOTIVE_GAME_VIEW, _container);

        _initializationStatus = EnumInitializationStatus.initializated;
    }
    /***
     * Logic of manager 
     * */
    public void ShowGamePlayView()
    {
        _locomotiveViewManager.Init();
    }
}
