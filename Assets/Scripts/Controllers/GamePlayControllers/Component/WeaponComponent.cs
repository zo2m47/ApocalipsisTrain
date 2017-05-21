﻿//  ***************************************************************************
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


public class WeaponComponent : BaseGamePlayComponent
{
    protected override void InitListener()
    {
        base.InitListener();
        AddComponentListener(EnumComponentEvent.attack, StartAttack);
    }

    /**
     * Listener
     * */
    private void StartAttack(IComponentActionData componentActionData)
    {

    }
}