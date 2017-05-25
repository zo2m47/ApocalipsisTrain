using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
public enum EnumBulletAction
{
    startMove,
    hitting,
    remove
}
public class BaseBulletComponent : MonoBehaviour, IRecyle
{
    protected BaseBulletController _bulletController;
    
    /// <summary>
    /// set static base bullet controller
    /// </summary>
    public virtual BaseBulletController GameElementController
    {
        set
        {
            _bulletController = value;
        }
    }
    /// <summary>
    /// call from controller when static data is updated
    /// </summary>
    public void UpdateStaticData()
    {
        InitActionListener();
    }

    protected WeaponData WeaponData
    {
        get
        {
            return _bulletController.WeaponData;
        }
    }

    protected Quaternion AimAngle
    {
        get
        {
            return _bulletController.AimAngle;
        }
    }

    /**Listener
     * */

    /// <summary>
    /// add listernr on element game play controller
    /// </summary>
    /// <param name="action">name on action</param>
    /// <param name="listener">call back</param>
    protected void AddComponentListener(EnumBulletAction action, Action listener)
    {
        _bulletController.AddComponentListener(action, listener);
    }

    /// <summary>
    /// remove listenr form element controller
    /// </summary>
    /// <param name="action">name of action</param>
    /// <param name="listener"></param>
    protected void RemoveListener(EnumBulletAction action, Action listener)
    {
        _bulletController.RemoveComponentListener(action, listener);
    }
    /// <summary>
    /// This component Dispatch action for other component
    /// </summary>
    /// <param name="action">name of action</param>
    protected void DispatcAction(EnumBulletAction action)
    {
        _bulletController.CallComponentAction(action);
    }

    protected virtual void InitActionListener()
    {

    }

    protected virtual void RemoveActionListener()
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
        RemoveActionListener();
    }
}
