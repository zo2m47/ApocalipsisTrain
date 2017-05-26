using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class BulletGamePlayController : GamePlayController
{
    /**
     * Controller of bullet logic 
     * */
    protected Quaternion _aimAngle;
    public Quaternion AimAngle { get { return _aimAngle; } }
    /// <summary>
    /// return weapon data, Static is baseBulletController
    /// </summary>
    public WeaponData WeaponData
    {
        get
        {
            return base.StaticData as WeaponData;
        }
    }

    /// <summary>
    /// Set weapon data and position
    /// </summary>
    /// <param name="weaponData">data of weapon setting, where bullets components get params</param>
    /// <param name="aimPosition">Touched postion in word by player</param>
    public void SetBulletSettings(WeaponData weaponData, Quaternion aimAngle)
    {
        _aimAngle = aimAngle;
        StaticData = weaponData;
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
