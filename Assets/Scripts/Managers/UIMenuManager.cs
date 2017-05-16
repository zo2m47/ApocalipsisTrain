using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UIMenuManager : ManagerSingleTone<UIMenuManager>, IInitilizationProcess
{
    // dictionary with all ui menu
    private Dictionary<EnumUIMenuID, IUIMenuController> _uiMenus;
    private RectTransform _containerRectTransform;

    /*Initialization progress */
    private EnumInitializationStatus _initializationStatus = EnumInitializationStatus.waiting;
    public bool allInitializated { get { return _initializationStatus == EnumInitializationStatus.initializated; } }
    public EnumInitializationStatus initializationStatus { get { return _initializationStatus; } }
    public string ClassNameInInitialization { get { return "Menu"; } }
    
    /*Initialization
     * */
         
    //add screens to initialization 
    private Dictionary<EnumUIMenuID, string> GetMenuList()
    {
        Dictionary<EnumUIMenuID, string> menuList = new Dictionary<EnumUIMenuID, string>();

        return menuList;
    }

    public void StartInitialization()
    {
        _initializationStatus = EnumInitializationStatus.inProgress;

        //get game obgect by his tag, where must be all ui screens 
        GameObject uiMenuContainer = GameObject.FindGameObjectWithTag(TagNames.TAG_UI_MENU_CONTAINER);
        if (uiMenuContainer == null)
        {
            LoggingManager.AddErrorToLog("Didn't found game object by tag " + TagNames.TAG_UI_MENU_CONTAINER);
            _initializationStatus = EnumInitializationStatus.initializationError;
            return;
        }

        Dictionary<EnumUIMenuID, string> menuList = GetMenuList();

        //add all screens to dictionary by his id 
        _uiMenus = new Dictionary<EnumUIMenuID, IUIMenuController>();
        foreach (KeyValuePair<EnumUIMenuID, string> pair in menuList)
        {
            if (!_uiMenus.ContainsKey(pair.Key))
            {
                _uiMenus.Add(pair.Key, PrefabCreatorManager.Instance.InstanceComponent<IUIMenuController>(pair.Value, uiMenuContainer));
            }
            else
            {
                LoggingManager.AddErrorToLog("Found repeat menu id " + pair.Key);
            }
        }

        //show menu wat should be add in start game
        for (int i =0;i<MainInitializationProcess.Instance.ActivateMenu.Count;i++)
        {
            ShowMenu(MainInitializationProcess.Instance.ActivateMenu[i],null);
        }

        _initializationStatus = EnumInitializationStatus.initializated;
    }
  
    /* Logic 
     * */
    // show menu animation 
    public void ShowMenu(EnumUIMenuID menuID, object data = null)
    {
        if (!_uiMenus.ContainsKey(menuID))
        {
            LoggingManager.AddErrorToLog("Try show, but Didnt found menu "+menuID.ToString());
            return;
        }
        if (data != null)
        {
            _uiMenus[menuID].Data = data;
        }

        _uiMenus[menuID].ShowAnimation();
    }

    //hide menu 
    public void HideMenu(EnumUIMenuID menuID)
    {
        if (!_uiMenus.ContainsKey(menuID))
        {
            LoggingManager.AddErrorToLog("Try hide, but Didnt found menu " + menuID.ToString());
            return;
        }

        _uiMenus[menuID].HideAnimation();
    }

    //hide all exept exepList, hide and show withOut animation
    public void HideAllMenu(List<EnumUIMenuID> exeptList = null)
    {
        foreach (IUIMenuController menuController in _uiMenus.Values)
        {
            if (exeptList!=null && exeptList.IndexOf(menuController.MenuID)!=-1)
            {
                menuController.Show();
            } else
            {
                menuController.Hide();
            }
        }
    }
}
