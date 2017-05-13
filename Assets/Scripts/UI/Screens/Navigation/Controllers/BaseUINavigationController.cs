using System;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class BaseUINavigationController : MonoBehaviour, IUIScreenNavigationController, IPointerClickHandler
{
    protected GameObject _source;

    [SerializeField]
    private UIScreenAnimationSettings _animationSettings;

    public virtual GameObject Source
    {
        set
        {
            _source = value;
        }
    }
    
    public UIScreenAnimationSettings AnimationSettings
    {
        get
        {
            return _animationSettings;
        }
    }        

    public virtual object Data {
        get
        {
            return null;
        }
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
       UIScreenManager.Instance.ShowNavigationScreen(this);
    }

    protected virtual T GetDataProvider<T>() where T : class
    {
        T dataProvider = _source.GetComponent<T>();
        if (dataProvider == null) LoggingManager.AddErrorToLog("Source must implement the data provider interface!");
        return dataProvider;
    }

    public abstract EnumUIScreenID ScreenID { get; }
}