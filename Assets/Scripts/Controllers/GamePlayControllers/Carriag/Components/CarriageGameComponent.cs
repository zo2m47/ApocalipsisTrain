using System;
using System.Collections.Generic;
using UnityEngine;

public class CarriageGameComponent: MonoBehaviour, IRecyle, ICarriageComponent
{
    /// <summary>
    /// Main Controller of current train prefab
    /// </summary>
    protected CarriageGameController _carriageController;

    public virtual CarriageGameController MainGamePlayController
    {
        set
        {
            _carriageController = value;
        }
    }

    private void Start()
    {
        InitListener();
    }

    /// <summary>
    /// call only one time after instaciated prefab
    /// </summary>
    protected virtual void InitListener()
    {

    }

    /**
     * IRecyle
     * */
    public virtual void Restart()
    {

    }

    public virtual void Shutdown()
    {

    }
}
