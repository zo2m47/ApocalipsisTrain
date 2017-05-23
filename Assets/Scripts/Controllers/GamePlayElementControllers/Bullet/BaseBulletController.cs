using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class BaseBulletController : MonoBehaviour, IRecyle
{
    /**
     * Controller of bullet logic 
     * */
    protected Quaternion _aimAngle;
    public Quaternion AimAngle { get { return _aimAngle; } }

    protected WeaponData _weaponData;
    public WeaponData WeaponData { get { return _weaponData; } }


    /*Components events*/
    private Dictionary<EnumBulletAction, List<Action>> _commponentActionDispatcher = new Dictionary<EnumBulletAction, List<Action>>();
    /// <summary>
    /// Add listener on bullet action
    /// </summary>
    /// <param name="bulletAction">name of action</param>
    /// <param name="listener">callback</param>
    public void AddComponentListener(EnumBulletAction bulletAction, Action listener)
    {
        if (!_commponentActionDispatcher.ContainsKey(bulletAction))
        {
            _commponentActionDispatcher.Add(bulletAction, new List<Action>());
        }
        _commponentActionDispatcher[bulletAction].Add(listener);
    }

    /// <summary>
    /// Remove listener of bullet componen action 
    /// </summary>
    /// <param name="bulletAction">name of action</param>
    /// <param name="listener">call back</param>
    public void RemoveComponentListener(EnumBulletAction bulletAction, Action listener)
    {
        if (_commponentActionDispatcher.ContainsKey(bulletAction))
        {
            for (int i = 0; i < _commponentActionDispatcher[bulletAction].Count; i++)
            {
                if (_commponentActionDispatcher[bulletAction][i] == listener)
                {
                    _commponentActionDispatcher[bulletAction].RemoveAt(i);
                }
            }
        }
    }

    /// <summary>
    /// Dicspatch bullet action 
    /// </summary>
    /// <param name="bulletAction">data of this action</param>
    public void CallComponentAction(EnumBulletAction bulletAction)
    {
        if (_commponentActionDispatcher.ContainsKey(bulletAction))
        {
            for (int i = 0; i < _commponentActionDispatcher[bulletAction].Count; i++)
            {
                _commponentActionDispatcher[bulletAction][i].DynamicInvoke();
            }
        }
    }
    /** END **/
    private BaseBulletComponent[] _components;
    private void Start()
    {
        // set static data to 
        _components = gameObject.GetComponents<BaseBulletComponent>();
        for (int i = 0; i < _components.Length; i++)
        {
            _components[i].GameElementController = this;
        }

        FirstInit();
    }

    protected void FirstInit()
    {

    }
    /// <summary>
    /// Set weapon data and position
    /// </summary>
    /// <param name="weaponData">data of weapon setting, where bullets components get params</param>
    /// <param name="aimPosition">Touched postion in word by player</param>
    public void SetBulletSettings(WeaponData weaponData, Quaternion aimAngle)
    {
        _aimAngle = aimAngle;
        _weaponData = weaponData;
    }

    public virtual void Restart()
    {
        
    }

    public virtual void Shutdown()
    {
        
    }
}
