using System;
using System.Collections.Generic;
using UnityEngine;
/**
 * Logic of all game play process 
 * */
public class GameViewManager : ManagerSingleTone<GameViewManager>, IInitilizationProcess
{
    private GameObject _container;
    public GameObject Container { get { return _container; } }

    private LocomotiveViewManager _locomotiveViewManager;
    private LocationViewManager _locationViewManager;

    public GameObject LocationViewContainer
    {
        get { return _locationViewManager.gameObject; }
    }

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
        _locomotiveViewManager = PrefabCreatorManager.Instance.InstanceComponent<LocomotiveViewManager>(PrefabsURL.LOCOMOTIVE_GAME_VIEW, _container,EnumPositioning.local,new Vector3(0,0,0));
        _locationViewManager = PrefabCreatorManager.Instance.InstanceComponent<LocationViewManager>(PrefabsURL.LOCATION_GAME_VIEW, _container, EnumPositioning.local, new Vector3(0, 0, 10));

        _initializationStatus = EnumInitializationStatus.initializated;
    }

    public float Width
    {
        get
        {
            return _locationViewManager.Width;
        }
    }

    public float Height
    {
        get
        {
            return _locationViewManager.Height;
        }
    }
    /***
     * Logic of manager 
     * */
    private bool _startShow = false;
    public bool StartShow { get { return _startShow; } }
    public void ShowGamePlayView()
    {
        _locomotiveViewManager.Init();
        _locationViewManager.InitLocationParts();
        _startShow = true;
    }
}
