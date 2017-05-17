using System;
using System.Collections.Generic;
using UnityEngine;
/***
 * Class with logic of carriage in game 
 * */
public class CarriageGameController : BaseGamePlayController, ICarriageController
{

    //static data 
    private CarriageVO _carriageData;
    public CarriageVO CarriageData { get { return _carriageData; } }

    private ICarriageComponent[] _components;
    
    CarriageVO ICarriageController.StaticData
    {
        set
        {
            throw new NotImplementedException();
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
            LoggingManager.AddErrorToLog(gameObject.name + " doesnt have connector");
        }
        _components = gameObject.GetComponentsInChildren<ICarriageComponent>();
        for (int i = 0; i < _components.Length; i++)
        {
            _components[i].MainGamePlayController = this;
        }
    }

}
