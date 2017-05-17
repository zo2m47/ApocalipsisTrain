using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class TrainGameComponent : MonoBehaviour, IRecyle, ITrainComponent
{
    /// <summary>
    /// Main Controller of current train prefab
    /// </summary>
    protected TrainGameController _trainController;

    public virtual TrainGameController MainGamePlayController
    {
        set
        {
            _trainController = value;
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
