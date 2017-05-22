using System;
using System.Collections.Generic;
using UnityEngine;

public class BaseGamePlayController : MonoBehaviour, IRecyle
{
    //container for connect train with carriages
    [SerializeField]
    private GameObject _connector;
    public GameObject Connector { get { return _connector; } }

    private BaseGamePlayComponent[] _components;

    private IStaticData _staticData;

    /// <summary>
    /// work with static data 
    /// </summary>
    public virtual IStaticData StaticData
    {
        set
        {
            _staticData = value;
        }
        get
        {
            return _staticData;
        }
    }

    /// <summary>
    /// return commponents interface 
    /// </summary>
    public virtual IComponentData CommponentsData
    {
        get
        {
            return _staticData as IComponentData;
        }
    }

    /**
 * Work with events vs commonents and controllers 
 * */
    /*Modifier delegate*/
    //get modified value after modifier it in buffs, calls from components 
    private Dictionary<EnumModifierAction, List<Action<ModifierActionData>>> _modifierActionDispatcher = new Dictionary<EnumModifierAction, List<Action<ModifierActionData>>>();
    /// <summary>
    /// add listener on modifier porperties
    /// </summary>
    /// <param name="action">name of modifier action</param>
    /// <param name="listener">callback</param>
    public void AddModifierListener(EnumModifierAction action, Action<ModifierActionData> listener)
    {
        if (!_modifierActionDispatcher.ContainsKey(action))
        {
            _modifierActionDispatcher.Add(action, new List<Action<ModifierActionData>>());
        }
        _modifierActionDispatcher[action].Add(listener);
    }

    /// <summary>
    /// Remove listener from modifier stak
    /// </summary>
    /// <param name="action">name of modifier action</param>
    /// <param name="listener">callback</param>
    public void RemoveModifierListener(EnumModifierAction action, Action<ModifierActionData> listener)
    {
        if (_modifierActionDispatcher.ContainsKey(action))
        {
            for (int i = 0; i < _modifierActionDispatcher[action].Count; i++)
            {
                if (_modifierActionDispatcher[action][i] == listener)
                {
                    _modifierActionDispatcher[action].RemoveAt(i);
                }
            }
        }
    }

    /// <summary>
    /// Modifier params
    /// </summary>
    /// <param name="action">name of modifier action</param>
    /// <param name="eventData">modifier params</param>
    public void CallModifierAction(EnumModifierAction action, ModifierActionData eventData)
    {
        if (_modifierActionDispatcher.ContainsKey(action))
        {
            for (int i = 0; i < _modifierActionDispatcher[action].Count; i++)
            {
                _modifierActionDispatcher[action][i].DynamicInvoke(eventData);
            }
        }
    }

    /*Components events*/
    private Dictionary<EnumComponentGroupAction, List<Action<IComponentAction>>> _commponentActionDispatcher = new Dictionary<EnumComponentGroupAction, List<Action<IComponentAction>>>();
    /// <summary>
    /// Add listener on actions
    /// </summary>
    /// <param name="componentGroupAction">name of event</param>
    /// <param name="listener">callback</param>
    public void AddComponentListener(EnumComponentGroupAction componentGroupAction, Action<IComponentAction> listener)
    {
        if (!_commponentActionDispatcher.ContainsKey(componentGroupAction))
        {
            _commponentActionDispatcher.Add(componentGroupAction, new List<Action<IComponentAction>>());
        }
        _commponentActionDispatcher[componentGroupAction].Add(listener);
    }

    /// <summary>
    /// Remove listener of componen action 
    /// </summary>
    /// <param name="componentGroupAction">name of action</param>
    /// <param name="listener">call back</param>
    public void RemoveComponentListener(EnumComponentGroupAction componentGroupAction, Action<IComponentAction> listener)
    {
        if (_commponentActionDispatcher.ContainsKey(componentGroupAction))
        {
            for (int i = 0; i < _commponentActionDispatcher[componentGroupAction].Count; i++)
            {
                if (_commponentActionDispatcher[componentGroupAction][i] == listener)
                {
                    _commponentActionDispatcher[componentGroupAction].RemoveAt(i);
                }
            }
        }
    }

    /// <summary>
    /// Dicspatch action 
    /// </summary>
    /// <param name="componentActionData">data of this action</param>
    private void CallComponentAction(IComponentAction componentActionData)
    {
        if (_commponentActionDispatcher.ContainsKey(componentActionData.GroupAction))
        {
            for (int i = 0; i < _commponentActionDispatcher[componentActionData.GroupAction].Count; i++)
            {
                _commponentActionDispatcher[componentActionData.GroupAction][i].DynamicInvoke(componentActionData);
            }
        }
    }
    /** END **/

    private void Start()
    {
        // set static data to 
        _components = gameObject.GetComponentsInChildren<BaseGamePlayComponent>();
        for (int i = 0; i < _components.Length; i++)
        {
            _components[i].GameElementController = this;
        }

        FirstInit();
    }

    protected virtual void FirstInit()
    {

    }

    protected void InitiListener()
    {
        ComponentsActionsManager.Instance.componentActionDispatcher += CallComponentAction;
    }

    protected void RemoveListener()
    {
        ComponentsActionsManager.Instance.componentActionDispatcher -= CallComponentAction;
    }
    /***
     * IRecyle
     * */
    public virtual void Restart()
    {
        InitiListener();
    }

    public virtual void Shutdown()
    {
        RemoveListener();
    }
}
