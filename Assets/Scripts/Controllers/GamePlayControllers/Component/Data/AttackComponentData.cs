//  ***************************************************************************
//  AttackComponentData.cs
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

public class AttackComponentData
{
    public static EnumComponentEvent action = EnumComponentEvent.attack;
    private Vector3 _wordPosition;
    public Vector3 WordPosition { get { return _wordPosition; } }
    public AttackComponentData(Vector3 position)
    {
        _wordPosition = position;
    }
}
