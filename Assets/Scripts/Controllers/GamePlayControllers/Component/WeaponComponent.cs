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

public class WeaponComponent : BaseGamePlayComponent
{
    protected override void InitListener()
    {
        base.InitListener();
        AddComponentListener(EnumComponentGroupAction.attack, ActionListener);
        coroutine = AimingProcess();
    }

    protected override void RemoveAllListener()
    {
        base.RemoveAllListener();
        RemoveListener(EnumComponentGroupAction.attack, ActionListener);
    }

    /**
     * Listener
     * */
    private void ActionListener(IComponentAction componentActionData)
    {
        if(MainGameController.Instance.SelectedGameElement == StaticName)
        {
            AttackComponenAction componentAction = componentActionData as AttackComponenAction;
            if (componentAction.Action == EnumComponentAction.aim)
            {
                StartAiming((Vector3)componentAction.Data);
            }

        }
    }

    private Quaternion _aimingAnlge;
    private float _aimingSpeed = 0;
    private IEnumerator coroutine;
    private void StartAiming(Vector3 position)
    {
        _aimingAnlge = Quaternion.LookRotation(Vector3.forward, position - _goOfComponent.transform.position);
        var angle = Quaternion.Angle(_goOfComponent.transform.rotation,_aimingAnlge);
        StopCoroutine(coroutine);
        StartCoroutine(coroutine);
    }

    private int _counter = 0;
    private IEnumerator AimingProcess()
    {
        //while (_goOfComponent.transform.rotation != _aimingAnlge)
        //{

        //    yield return null;
        //}
        _counter += 1;
        int c = _counter;
        
        float t = 0f;
        while (t<1 )
        {
            Debug.Log(c);
            t += Time.deltaTime / 2f;
            _goOfComponent.transform.rotation = Quaternion.Slerp(_goOfComponent.transform.rotation, _aimingAnlge, t);
            yield return null;
        }
        yield break;
    }
}
