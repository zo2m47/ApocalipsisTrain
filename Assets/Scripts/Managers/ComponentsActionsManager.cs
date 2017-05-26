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
    /*
     * Component dispatcher
     * */
    /*Components events*/
    private Dictionary<EnumComponentAction, List<Action<IComponentActionData>>> _commponentActionDispatcher = new Dictionary<EnumComponentAction, List<Action<IComponentActionData>>>();
    /// <summary>
    /// Add listener on actions
    /// </summary>
    /// <param name="componentAction">name of event</param>
    /// <param name="listener">callback</param>
    public void AddComponentListener(EnumComponentAction componentAction, Action<IComponentActionData> listener)
    {
        if (!_commponentActionDispatcher.ContainsKey(componentAction))
        {
            _commponentActionDispatcher.Add(componentAction, new List<Action<IComponentActionData>>());
        }
        _commponentActionDispatcher[componentAction].Add(listener);
    }

    /// <summary>
    /// Remove listener of componen action 
    /// </summary>
    /// <param name="componentAction">name of action</param>
    /// <param name="listener">call back</param>
    public void RemoveComponentListener(EnumComponentAction componentAction, Action<IComponentActionData> listener)
    {
        if (_commponentActionDispatcher.ContainsKey(componentAction))
        {
            for (int i = 0; i < _commponentActionDispatcher[componentAction].Count; i++)
            {
                if (_commponentActionDispatcher[componentAction][i] == listener)
                {
                    _commponentActionDispatcher[componentAction].RemoveAt(i);
                }
            }
        }
    }

    /// <summary>
    /// Dicspatch action 
    /// </summary>
    /// <param name="componentActionData">data of this action</param>
    private void CallComponentAction(IComponentActionData componentActionData)
    {
        if (_commponentActionDispatcher.ContainsKey(componentActionData.Action))
        {
            for (int i = 0; i < _commponentActionDispatcher[componentActionData.Action].Count; i++)
            {
                _commponentActionDispatcher[componentActionData.Action][i].DynamicInvoke(componentActionData);
            }
        }
    }

   /*
    * Work with game events and transform it to components events
    * */
    /// <summary>
    /// Action of toch word by player
    /// </summary>
    /// <param name="wordPosition"></param>
    private void WordTouchListener(Vector3 wordPosition)
    {
        CallComponentAction(new AttackComponenAction(wordPosition));
    }

}
