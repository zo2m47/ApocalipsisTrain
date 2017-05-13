using System;
using UnityEngine;

public abstract class BaseUIScreenController : MonoBehaviour, IUIScreenController
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
    }

    protected virtual void AfterStart()
    {

    }
}
