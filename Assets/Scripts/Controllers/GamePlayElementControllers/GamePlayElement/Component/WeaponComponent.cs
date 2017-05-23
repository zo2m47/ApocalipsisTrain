//  ***************************************************************************
//  WeaponComponent.cs
//      
//  Copyright (c) 2017  Spina LLC
//  All rights reserved.
//
//  This software may not be copied, distributed or modified
//  without express permission of Spina LLC.  
//  The software is provided as is, in accordance with the license agreement.
//  ****************************************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
/**
 * Component with logic of weapon shooting
 * */

public class WeaponComponent : BaseGamePlayComponent
{
    [SerializeField]
    private Transform _bulletStartPosition;
    //state of weapon at the moment 
    private bool _readyToShot = false;
    private bool _aiminig = false;
    //data of event
    private AttackComponenAction _attackComponenAction;

    public override void Restart()
    {
        _readyToShot = true;
    }
    
    protected override void InitListener()
    {
        base.InitListener();
        AddComponentListener(EnumComponentGroupAction.attack, ActionListener);
    }

    protected override void RemoveAllListener()
    {
        base.RemoveAllListener();
        RemoveListener(EnumComponentGroupAction.attack, ActionListener);
    }

    /** 
     * call back of attack listener 
     */
    private void ActionListener(IComponentAction componentActionData)
    {
        if(MainGameController.Instance.SelectedGameElement == StaticName)
        {
            _attackComponenAction = componentActionData as AttackComponenAction;
            //aim weapon
            if (_attackComponenAction.Action == EnumComponentAction.aim)
            {
                StartAiming();
            }
        }
    }

    /**
     *  Aim logic 
     */
    private Quaternion _aimingAnlge;
    private float _aimingSpeed = 0;
    private void StartAiming()
    {
        _aimingAnlge = Quaternion.LookRotation(Vector3.forward, _attackComponenAction.WordTouchedPosition - _goOfComponent.transform.position);
        var angle = Quaternion.Angle(_goOfComponent.transform.rotation,_aimingAnlge);
        _aimingSpeed = ComponentData.Weapon.aimSpeed* angle / 180f;
        _aiminig = true;
    }

    private bool Aimed { get { return _goOfComponent.transform.rotation == _aimingAnlge; } }
    
    /**
     * Shot logic
     * */
    private void Shot()
    {
        WeaponData weaponData = ComponentData.Weapon;
        BaseBulletController baseBulletController = PrefabCreatorManager.Instance.InstanceComponent<BaseBulletController>(PrefabsURL.BULLET_GAME_ELEMENT + weaponData.bulletView,GameViewManager.Instance.Container,EnumPositioning.global,_bulletStartPosition.position);
        baseBulletController.SetBulletSettings(weaponData, _aimingAnlge);
        //go to calldown
        StartCooldown();
    }

    /**
     * Cooldown logic 
     * */
    private void StartCooldown()
    {
        _readyToShot = false;
        StartCoroutine(WeaponCooldown());
    }

    private IEnumerator WeaponCooldown()
    {
        yield return new WaitForSeconds(ComponentData.Weapon.cooldown);
        _readyToShot = true;
        yield break;
    }

    /**
     * Logic in update
     * */
    void Update()
    {
        //work with aiming
        if (!Aimed)
        {
            float t = 0f;
            if (t<1 )
            {
                t += Time.deltaTime / _aimingSpeed;
                _goOfComponent.transform.rotation = Quaternion.Slerp(_goOfComponent.transform.rotation, _aimingAnlge, t);
            }
        } else
        {
            if (_aiminig && _readyToShot)
            {
                _aiminig = false;
                Shot();
            }
        }
    }

}
