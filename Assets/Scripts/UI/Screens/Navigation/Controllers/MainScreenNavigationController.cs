//  ***************************************************************************
//  MainScreenNavigationController.cs
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


public class MainScreenNavigationController : BaseUINavigationController
{
    public override EnumUIScreenID ScreenID
    {
        get
        {
            return EnumUIScreenID.main;
        }
    }
}
