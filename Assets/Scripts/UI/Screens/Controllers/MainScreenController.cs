//  ***************************************************************************
//  MainScreenController.cs
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

public class MainScreenController : BaseUIScreenController, IGamePlayScreenDataProvider
{
    public override string ClassNameInInitialization
    {
        get
        {
            return "Main Screen Controller";
        }
    }

    public override EnumUIScreenID screenID
    {
        get
        {
            return EnumUIScreenID.main;
        }
    }
}
