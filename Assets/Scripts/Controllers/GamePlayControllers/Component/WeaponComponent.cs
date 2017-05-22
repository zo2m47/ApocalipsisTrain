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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class WeaponComponent : BaseGamePlayComponent
{
    protected override void InitListener()
    {
        Debug.Log("InitListener");
        base.InitListener();
        AddComponentListener(EnumComponentGroupAction.attack, ActionListener);
    }

    protected override void RemoveListener()
    {
        base.RemoveListener();
        RemoveListener(EnumComponentGroupAction.attack, ActionListener);
    }

    /**
     * Listener
     * */
    private void ActionListener(IComponentAction componentActionData)
    {
        Debug.Log("ActionListener");
        if(MainGameController.Instance.SelectedGameElement == StaticName)
        {
            AttackComponenAction componentAction = componentActionData as AttackComponenAction;
            if(componentAction.Action == EnumComponentAction.aim)
            {
                LoggingManager.Log("НЕУЖЕЛИ!!!!!!");
            }

        }
    }
}
