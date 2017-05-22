using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class ComponentsActionsManager : ManagerSingleTone<ComponentsActionsManager>, IInitilizationProcess
{
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
            return "Components actions manager";
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
        MainGameController.Instance.gamePlaywordTouchDispatcher += WordTouchListener;
        _initializationStatus = EnumInitializationStatus.initializated;
    }

    public delegate void ComponentAction(IComponentAction componentActionData);
    public ComponentAction componentActionDispatcher;
    
    /// <summary>
    /// Action of toch word by player
    /// </summary>
    /// <param name="wordPosition"></param>
    private void WordTouchListener(Vector3 wordPosition)
    {
        DispatchAction(new AttackComponenAction(EnumComponentAction.aim, wordPosition));
    }

    /// <summary>
    /// Dispatch action with action data
    /// </summary>
    /// <param name="actionData"></param>
    private void DispatchAction(IComponentAction action)
    {
        if (componentActionDispatcher!=null)
        {
            componentActionDispatcher(action);
        }
    }
}
