using System;
using System.Collections.Generic;
using UnityEngine;

public class BaseGamePlayController : MonoBehaviour, IRecyle
{
    //container for connect train with carriages
    [SerializeField]
    private GameObject _connector;
    public GameObject Connector { get { return _connector; } }
    /**
 * Work with events vs commonents and controllers 
 * */
    /*Modifier delegate*/
    //get modified value after modifier it in buffs, calls from components 
    private Dictionary<EnumModifierAction, List<Func<ModifierActionData>>> _modifierActionDispatcher = new Dictionary<EnumModifierAction, List<Func<ModifierActionData>>>();
    /// <summary>
    /// add listener on modifier porperties
    /// </summary>
    /// <param name="action">name of modifier action</param>
    /// <param name="listener">callback</param>
    public void AddModifierListener(EnumModifierAction action, Func<ModifierActionData> listener)
    {
        if (!_modifierActionDispatcher.ContainsKey(action))
        {
            _modifierActionDispatcher.Add(action, new List<Func<ModifierActionData>>());
        }
        _modifierActionDispatcher[action].Add(listener);
    }

    /// <summary>
    /// Remove listener from modifier stak
    /// </summary>
    /// <param name="action">name of modifier action</param>
    /// <param name="listener">callback</param>
    public void RemoveModifierListener(EnumModifierAction action, Func<ModifierActionData> listener)
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
    private Dictionary<EnumComponentEvent, List<Func<IComponentActionData>>> _commponentActionDispatcher = new Dictionary<EnumComponentEvent, List<Func<IComponentActionData>>>();
    /// <summary>
    /// Add listener on actions
    /// </summary>
    /// <param name="action">name of event</param>
    /// <param name="listener">callback</param>
    public void AddComponentListener(EnumComponentEvent action, Func<IComponentActionData> listener)
    {
        if (!_commponentActionDispatcher.ContainsKey(action))
        {
            _commponentActionDispatcher.Add(action, new List<Func<IComponentActionData>>());
        }
        _commponentActionDispatcher[action].Add(listener);
    }

    /// <summary>
    /// Remove listener of componen action 
    /// </summary>
    /// <param name="action">name of action</param>
    /// <param name="listener">call back</param>
    public void RemoveComponentListener(EnumComponentEvent action, Func<IComponentActionData> listener)
    {
        if (_commponentActionDispatcher.ContainsKey(action))
        {
            for (int i = 0; i < _commponentActionDispatcher[action].Count; i++)
            {
                if (_commponentActionDispatcher[action][i] == listener)
                {
                    _commponentActionDispatcher[action].RemoveAt(i);
                }
            }
        }
    }

    /// <summary>
    /// Dicspatch action 
    /// </summary>
    /// <param name="action">name of action</param>
    /// <param name="eventData">data of this action</param>
    public void CallComponentAction(EnumComponentEvent action, IComponentActionData eventData)
    {
        if (_commponentActionDispatcher.ContainsKey(action))
        {
            for (int i = 0; i < _commponentActionDispatcher[action].Count; i++)
            {
                _commponentActionDispatcher[action][i].DynamicInvoke(eventData);
            }
        }
    }
    /** END **/

    private void Start()
    {
        FirstInit();
    }

    protected virtual void FirstInit()
    {

    }
    /***
     * IRecyle
     * */
    public virtual void Restart()
    {
        
    }

    public virtual void Shutdown()
    {

    }
}
