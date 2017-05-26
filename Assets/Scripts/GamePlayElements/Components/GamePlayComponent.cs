using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
/***
 * Parent of components 
 * */
public class GamePlayComponent : MonoBehaviour, IRecyle
{
    [SerializeField]
    protected GameObject _goOfComponent;
    /// <summary>
    /// Name of static data element
    /// </summary>
    protected virtual string StaticName
    {
        get
        {
            if (_gamePlayElementController == null)
            {
                return "";
            }
            return (_gamePlayElementController.StaticData as IStaticData).Name;
        }
    }

    /// <summary>
    /// return component data if static data has it
    /// </summary>
    protected IComponentData ComponentData { get { return _gamePlayElementController.StaticData as IComponentData; } }

    /*
     * Listener
     * */
    /// <summary>
    /// add listener to component manager
    /// </summary>
    /// <param name="componentAction">action name</param>
    /// <param name="listener">listener</param>
    protected void AddComponentListener(EnumComponentAction componentAction, Action<IComponentActionData> listener)
    {
        ComponentsActionsManager.Instance.AddComponentListener(componentAction, listener);
    }
    
    /// <summary>
    /// Remove listener from component manager
    /// </summary>
    /// <param name="componentAction">action name</param>
    /// <param name="listener">action listener</param>
    protected void RemoveComponentListener(EnumComponentAction componentAction, Action<IComponentActionData> listener)
    {
        ComponentsActionsManager.Instance.RemoveComponentListener(componentAction, listener);
    }

    /*
     * Game play element controller
     * */
    protected GamePlayController _gamePlayElementController;
    protected virtual GamePlayController GamePlayElementController
    {
        get
        {
            return _gamePlayElementController;
        }
    }

    /// <summary>
    /// try to found game play controller
    /// </summary>
    private void Start()
    {
        FindGamePlayController();
    }

    protected virtual void FindGamePlayController()
    {
        _gamePlayElementController = gameObject.GetComponent<GamePlayController>();
        if (_gamePlayElementController == null)
        {
            _gamePlayElementController = gameObject.GetComponentInParent<GamePlayController>();
        }
        if (_gamePlayElementController == null)
        {
            LoggingManager.AddErrorToLog("Didt found gamePlay Element Controller");
        }
        _gamePlayElementController.initStaticData += InitStaticData;
        InitStaticData();
    }

    /// <summary>
    /// When static data update in controller calls this mathod
    /// </summary>
    protected virtual void InitStaticData()
    {

    }
    /*
     * IRecyle
     * */
    public virtual void Restart()
    {
    }

    public virtual void Shutdown()
    {
    }
}
