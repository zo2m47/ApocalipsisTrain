using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Initializate all controllers for starts
 * Nedd add this class to main unity project
 * */
public class MainInitializationProcess : SingletonMonoBehaviour<MainInitializationProcess>
{
    [SerializeField]
    private List<EnumUIMenuID> _activateMenu = new List<EnumUIMenuID>();
    public List<EnumUIMenuID> ActivateMenu { get { return _activateMenu; } }
    [SerializeField]
    private EnumUIScreenID _firstScreen;
    public EnumUIScreenID FirstScreen { get { return _firstScreen; } }

    public EnumInitializationStatus initializationStatus { get ; private set; }
    private List<IInitilizationProcess> _initializationList = new List<IInitilizationProcess>();

    public void Start()
    {
        Debug.Log("Start initializate");
        _initializationList.Add(UIScreenManager.Instance);
        _initializationList.Add(UIMenuManager.Instance);
        _initializationList.Add(UIScreenAnimationManager.Instance);
        _initializationList.Add(StaticDataModel.Instance);
        _initializationList.Add(TimerManager.Instance);
        
        StartInitialization();
    }

    //start initialization process
    public void StartInitialization()
    {
        for (int i = 0;i< _initializationList.Count;i++)
        {
            _initializationList[i].StartInitialization();
        }
        StartCoroutine(CheckOnInitialization());
        StartCoroutine(TracingProcess());
    }

    //tracing of initialization process 
    private IEnumerator TracingProcess()
    {
        while (!allInitializated)
        {
            LoggingManager.Instance.AddLog("-------INITIALIZATION TRACE-------");
            foreach (IInitilizationProcess initilizationClass in _initializationList)
            {
                if (initilizationClass.initializationStatus == EnumInitializationStatus.initializationError)
                {
                    LoggingManager.AddErrorToLog(string.Format("InitializationError in {0}", initilizationClass.classNameInInitialization));
                    yield break;
                }

            }
            yield return new WaitForSeconds(1f);
        }
        LoggingManager.Instance.AddLog("All were initializated");
        yield break;
    }

    //initializat all model step by step 
    private IEnumerator CheckOnInitialization()
    {
        bool allInitializated = false;
        while (!allInitializated)
        {
            allInitializated = true;
            foreach (IInitilizationProcess initilizationClass in _initializationList)
            {
                if (!initilizationClass.allInitializated)
                {
                    allInitializated = false;
                    yield return null;
                } 
                if (initilizationClass.initializationStatus == EnumInitializationStatus.initializationError)
                {
                    yield break;
                }
            }
        }
        initializationStatus = EnumInitializationStatus.initializated;
        yield break;
    }
    
    public bool allInitializated
    {
        get
        {
            return initializationStatus == EnumInitializationStatus.initializated;
        }
    }
}
