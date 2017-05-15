using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Class with logic of missions progress
 * */
public class MissionManager : ManagerSingleTone<MissionManager>, IInitilizationProcess
{
    /**
     * Initialization logic
     * */
    private EnumInitializationStatus _initializationStatus;
    public bool allInitializated
    {
        get
        {
            return _initializationStatus == EnumInitializationStatus.initializated;
        }
    }

    public string classNameInInitialization
    {
        get
        {
            return "Mission manager";
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
    }

    private IEnumerator WaitOfStaticModelInit()
    {
        while (!StaticDataModel.Instance.allInitializated)
        {
            yield return null;
        }
        yield break;
    }
}
