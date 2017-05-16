using System;
using UnityEngine;

public abstract class BaseUIScreenController : MonoBehaviour, IUIScreenController, IInitilizationProcess
{
    protected object _data;
    protected RectTransform _baseRectTransform;

    public GameObject baseGameObject
    {
        get
        {
            return gameObject;
        }
    }

    public RectTransform baseRectTransform
    {
        get
        {
            return _baseRectTransform;
        }
    }

    public abstract EnumUIScreenID screenID { get; }

    private EnumInitializationStatus _initializationStatus;
    public EnumInitializationStatus initializationStatus
    {
        get
        {
            return _initializationStatus;
        }
    }

    public bool allInitializated
    {
        get
        {
            return _initializationStatus == EnumInitializationStatus.initializated;
        }
    }

    public abstract string ClassNameInInitialization
    {
        get;
    }

    public void StartInitialization()
    {
        throw new NotImplementedException();
    }

    //should be overriden by screens which require some data
    public virtual void SetData(object data)
    {
        _data = data;
    }

    private void Start()
    {
        IUIScreenNavigationController[] uiNavigationControllerArray = gameObject.GetComponentsInChildren<IUIScreenNavigationController>();
        for (int i = 0; i< uiNavigationControllerArray.Length; i++)
        {
            uiNavigationControllerArray[i].Source = gameObject;
        }
        _baseRectTransform = gameObject.GetComponent<RectTransform>();
        if (_baseRectTransform == null)
        {
            LoggingManager.AddErrorToLog("Didn't found RectTransform in screen "+screenID.ToString());

        } else
        {
            _baseRectTransform.offsetMin = new Vector2(0, 0);
            _baseRectTransform.offsetMax = new Vector2(0, 0);
        }
        AfterStart();
        _initializationStatus = EnumInitializationStatus.initializated;
    }

    protected virtual void AfterStart()
    {

    }

}
