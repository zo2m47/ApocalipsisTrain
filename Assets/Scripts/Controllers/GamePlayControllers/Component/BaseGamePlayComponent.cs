//  ***************************************************************************
//  BaseGamePlayComponent.cs
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

public class BaseGamePlayComponent : MonoBehaviour, IRecyle 
{
    /// <summary>
    /// Main Controller of current train prefab
    /// </summary>
    protected BaseGamePlayController _gameElementController;

    public virtual BaseGamePlayController GameElementController
    {
        set
        {
            _gameElementController = value;
        }
    }

    protected void AddComponentListener(EnumComponentEvent action, Action<IComponentActionData> listener)
    {
        _gameElementController.AddComponentListener(action,listener);
    }

    private void Start()
    {
        
    }
    
    /// <summary>
    /// call only one time after instaciated prefab
    /// </summary>
    protected virtual void InitListener()
    {

    }

    /**
     * IRecyle
     * */
    public virtual void Restart()
    {
        InitListener();
    }

    public virtual void Shutdown()
    {

    }
}
