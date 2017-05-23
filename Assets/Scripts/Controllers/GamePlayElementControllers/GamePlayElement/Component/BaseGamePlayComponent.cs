﻿//  ***************************************************************************
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
    [SerializeField]
    protected GameObject _goOfComponent;
    /// <summary>4
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

    /// <summary>
    /// called from element controller when static data is updated 
    /// </summary>
    public void UpdateStaticData()
    {
        InitListener();
    }
    /// <summary>
    /// add listernr on element game play controller
    /// </summary>
    /// <param name="action">name on action</param>
    /// <param name="listener">call back</param>
    protected void AddComponentListener(EnumComponentGroupAction action, Action<IComponentAction> listener)
    {
        _gameElementController.AddComponentListener(action,listener);
    }

    /// <summary>
    /// remove listenr form element controller
    /// </summary>
    /// <param name="action">name of action</param>
    /// <param name="listener"></param>
    protected void RemoveListener(EnumComponentGroupAction action, Action<IComponentAction> listener)
    {
        _gameElementController.RemoveComponentListener(action, listener);
    }
    /// <summary>
    /// Name of static data element
    /// </summary>
    protected string StaticName
    {
        get
        {
            return _gameElementController.StaticData.Name;
        }
    }
    
    protected IComponentData ComponentData { get { return _gameElementController.StaticData as IComponentData; } }

    private void Start()
    {
        
    }
    
    /// <summary>
    /// call only one time after instaciated prefab
    /// </summary>
    protected virtual void InitListener()
    {
        
    }
    /// <summary>
    /// Remove delegate listener 
    /// </summary>
    protected virtual void RemoveAllListener()
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
        RemoveAllListener();
    }
}
