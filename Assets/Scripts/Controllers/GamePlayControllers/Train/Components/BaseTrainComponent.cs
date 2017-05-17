using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class BaseTrainComponent : MonoBehaviour, IRecyle, ITrainComponent
{
    /// <summary>
    /// Main Controller of current train prefab
    /// </summary>
    protected BaseTrainController _trainController;

    public virtual BaseTrainController MainController
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
