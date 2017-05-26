using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Logic of controll all screens 
 * */
public class UIScreenManager : ManagerSingleTone<UIScreenManager>,IInitilizationProcess
{
    //events of change change screen
    public event EventHandler eventChangeScreen;
    // dictionary with all ui screen
    private Dictionary<EnumUIScreenID,IUIScreenController> _uiScreens;
    private IUIScreenController _currentScreen;
    /*Initialization progress */
    private EnumInitializationStatus _initializationStatus = EnumInitializationStatus.waiting;
    public bool allInitializated { get { return _initializationStatus == EnumInitializationStatus.initializated; } }
    public EnumInitializationStatus initializationStatus { get { return _initializationStatus; } }

    public string ClassNameInInitialization { get { return "Screen Manager"; } }

    private List<IUIScreenNavigationController> _screenStack = new List<IUIScreenNavigationController>();
    private EnumUIScreenID _finishScreen; //for navigation

    /*Initialization
     * */

    //add screens to initialization 
    private Dictionary<EnumUIScreenID,string> GetScreenList()
    {
        Dictionary<EnumUIScreenID, string> screenList = new Dictionary<EnumUIScreenID, string>();
        screenList.Add(EnumUIScreenID.main, PrefabsURL.MAIN_SCREEN);
        screenList.Add(EnumUIScreenID.gamePlay, PrefabsURL.GAME_PLAY_SCREEN);
        return screenList;
    }

    public void StartInitialization()
    {
        _initializationStatus = EnumInitializationStatus.inProgress;
        
        //get game obgect by his tag, where must be all ui screens 
        GameObject uiScreenContainer = GameObject.FindGameObjectWithTag(TagNames.TAG_UI_SCREEN_CONTAINER);
        if (uiScreenContainer == null)
        {
            LoggingManager.AddErrorToLog("Didn't found game object by tag "+ TagNames.TAG_UI_SCREEN_CONTAINER);
            _initializationStatus = EnumInitializationStatus.initializationError;
            return;
        }

        Dictionary<EnumUIScreenID, string> screenList = GetScreenList();
        
        //add all screens to dictionary by his id 
        _uiScreens = new Dictionary<EnumUIScreenID, IUIScreenController>();
        foreach (KeyValuePair<EnumUIScreenID,string> pair in screenList)
        {
            if (!_uiScreens.ContainsKey(pair.Key))
            {
                _uiScreens.Add(pair.Key, PrefabCreatorManager.Instance.InstanceComponent<IUIScreenController>(pair.Value, uiScreenContainer));
                _uiScreens[pair.Key].SetDefaulStartPosition();
            } else
            {
                LoggingManager.AddErrorToLog("Found repeat screen id " + pair.Key);
            }
        }

        StartCoroutine(CheckOfInitializateAllScreens());
       
    }

    private IEnumerator CheckOfInitializateAllScreens()
    {
        while (true)
        {
            foreach (IInitilizationProcess pair in _uiScreens.Values)
            {
                if (pair.initializationStatus == EnumInitializationStatus.initializationError)
                {
                    LoggingManager.AddErrorToLog("Problem with "+ pair.ClassNameInInitialization);
                    _initializationStatus = EnumInitializationStatus.initializationError;
                    yield break;
                }

                if (!pair.allInitializated)
                {
                    yield return null;
                }
            }
            
            if (MainInitializationProcess.Instance.FirstScreen != EnumUIScreenID.withOutName)
            {
                ShowScreenByID(MainInitializationProcess.Instance.FirstScreen);
            }

            _initializationStatus = EnumInitializationStatus.initializated;
            yield break;

        }
        yield break;
    }

    /*Logic */
    //show first screen 
    private void ShowScreenByID(EnumUIScreenID screenID)
    {
       
        if (!_uiScreens.ContainsKey(screenID))
        {
            LoggingManager.AddErrorToLog("Try open "+ screenID .ToString()+ " first Screen, but he is epsan in _uiScreens");
            return;
        }

        //set all deactivate
        foreach(KeyValuePair<EnumUIScreenID,IUIScreenController> pair in _uiScreens)
        {
            if (pair.Key!=screenID)
            {
                pair.Value.baseGameObject.SetActive(false);
            } 
        }

        ChangeCurrentScreen(_uiScreens[screenID]);
        _currentScreen.baseGameObject.SetActive(true);
        _currentScreen.SetData(null);
    }

    /// <summary>
    /// Change screen 
    /// </summary>
    /// <param name="screen">new screen</param>
    private void ChangeCurrentScreen(IUIScreenController screen)
    {
        _currentScreen = screen;
        if (eventChangeScreen!=null)
        {
            eventChangeScreen.Invoke(this, EventArgs.Empty); 
        }
    }
    
    /// <summary>
    /// return screen id - what is oppened at the moment
    /// </summary>
    public EnumUIScreenID CurrentOpenedScreen
    {
        get
        {
            if (_currentScreen == null)
            {
                return EnumUIScreenID.withOutName;
            }
            return _currentScreen.screenID;
        }
    }

    /// <summary>
    /// Open screen 
    /// </summary>
    /// <param name="navigationController"> navigation controller, where is saved date for opening screen</param>
    public void ShowNavigationScreen(IUIScreenNavigationController navigationController)
    {
        if (CheckOfScreen(navigationController.ScreenID))
        {
            return;
        }
        //chack of screen stack
        CheckOnScreenStack(navigationController);

        _uiScreens[navigationController.ScreenID].SetData(navigationController.Data);

        UIScreenAnimationManager.Instance.StartAnimateNavigation(navigationController.AnimationSettings, _uiScreens[navigationController.ScreenID], _currentScreen);
        ChangeCurrentScreen(_uiScreens[navigationController.ScreenID]);
    }

    /// <summary>
    /// Check of errors 
    /// </summary>
    /// <param name="screenID">id of checking screen</param>
    private bool CheckOfScreen(EnumUIScreenID screenID)
    {
        //if showing/hiding animation isnt finishd
        if (UIScreenAnimationManager.Instance.isAnimating)
        {
            return true;
        }
        //if doesn't found screen with this name in _uiScreens
        if (!_uiScreens.ContainsKey(screenID))
        {
            LoggingManager.AddErrorToLog("Try open Screen, but he is epsan in _uiScreens");
            return true;
        }
        if (screenID == _currentScreen.screenID)
        {
            return true;
        }
        return false;
    }

    /* Navigation by stack */
    /// <summary>
    /// Chack of stack
    /// </summary>
    /// <param name="navigationController">next showing screen</param>
    private void CheckOnScreenStack(IUIScreenNavigationController navigationController)
    {
        if (navigationController.ScreenID == _finishScreen)
        {
            _screenStack.Clear();
        }
        else
        {
            _screenStack.Add(navigationController);
        }
    }

    /// <summary>
    /// remove current screen from stack and show preview screen
    /// </summary>
    public void ShowPreviousScreen()
    {
        //if showing/hiding animation isnt finishd
        if (UIScreenAnimationManager.Instance.isAnimating)
        {
            return;
        }

        if (_screenStack.Count == 0)
        {
            LoggingManager.AddErrorToLog("Try return to preview screen, but screen stack is empty");
            return;
        }
        IUIScreenNavigationController previousScreenNavigationController = _screenStack[_screenStack.Count - 1];

        //remove last screen it must be curren opened screen
        _screenStack.RemoveAt(_screenStack.Count-1);
        
        if (_screenStack.Count == 0)
        {
            //go to main screen
            ShowNavigationOfPreviousScreen(_uiScreens[_finishScreen], previousScreenNavigationController.AnimationSettings, null);
        } else
        {
            //show preview screen from stack 
            ShowNavigationOfPreviousScreen(_uiScreens[_screenStack[_screenStack.Count - 1].ScreenID], previousScreenNavigationController.AnimationSettings, previousScreenNavigationController.Data);
        }
    }

    /// <summary>
    /// Show previous screen with animation
    /// </summary>
    /// <param name="navigationController"></param>
    private void ShowNavigationOfPreviousScreen(IUIScreenController previousScreen, UIScreenAnimationSettings animationSetting, object data)
    {
        if (CheckOfScreen(previousScreen.screenID))
        {
            return;
        }

        previousScreen.SetData(data);
        
        //get revert animation settings 
        UIScreenAnimationSettings revertAnimationSEtting = new UIScreenAnimationSettings();
        revertAnimationSEtting.SetRevertType(animationSetting);

        UIScreenAnimationManager.Instance.StartAnimateNavigation(revertAnimationSEtting, previousScreen, _currentScreen);
        ChangeCurrentScreen(previousScreen);
    }
}

