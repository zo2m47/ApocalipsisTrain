using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***
 * Class with logic of Train in game
 * */
public class TrainGameController : BaseGamePlayController, ITrainController
{
   
    //static data 
    private TrainVO _trainData;
    public TrainVO TrainData { get { return _trainData; } }

    private ITrainComponent[] _components;
    public TrainVO StaticData
    {
        set
        {
            _trainData = value;
        }
    }
    
    private void Start()
    {
        FirstInit();
    }

    /// <summary>
    /// Give this controllers to all components in this prefab 
    /// </summary>
    protected override void FirstInit()
    {
        if (Connector == null)
        {
            LoggingManager.AddErrorToLog(gameObject.name+" doesnt have connector");
        }
        _components = gameObject.GetComponentsInChildren<ITrainComponent>();
        for (int i = 0;i< _components.Length; i++)
        {
            _components[i].MainGamePlayController = this;
        }
    }
      
}
