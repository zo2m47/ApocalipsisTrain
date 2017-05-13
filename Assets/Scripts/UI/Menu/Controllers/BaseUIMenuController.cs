using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Base controllers of all UI menues 
 * */
public abstract class BaseUIMenuController : MonoBehaviour, IUIMenuController {

    [SerializeField]
    private UIMenuAnimationSettings _animetionSettings;
    private EasyTween _tween;
    private RectTransform _currentRectTransform;
    private bool _isAnimationing = false;

    public void Init()
    {
        // if object hs button for screen navigation 
        IUIScreenNavigationController[] uiNavigationControllerArray = gameObject.GetComponentsInChildren<IUIScreenNavigationController>();
        for (int i = 0; i < uiNavigationControllerArray.Length; i++)
        {
            uiNavigationControllerArray[i].Source = gameObject;
        }

        _tween = gameObject.GetComponent<EasyTween>();
        if (_tween == null)
        {
            if (_animetionSettings.uiMenuAnimationType!=EnumUIMenuAnimationType.withOut)
            {
                _tween = gameObject.AddComponent<EasyTween>();
            }
        }
        _currentRectTransform = gameObject.GetComponent<RectTransform>();
        if (_tween != null)
        {
            _tween.rectTransform = _currentRectTransform;
            //_tween.ResetAnimationParts(false, false, false, UITween.AnimationParts.EndTweenClose.DEACTIVATE);
            SetAnimationSettings();
            SetStartStrrings();
        }
        Hide();
    }

    //for minimizate write code
    private float CurrentObjectWidth { get { return _currentRectTransform.rect.width; } }
    private float CurrentObjectHeight { get { return _currentRectTransform.rect.height; } }

    //set start settings by uiMenuAnimationType
    private void SetStartStrrings()
    {

        switch (_animetionSettings.uiMenuAnimationType)
        {
            case EnumUIMenuAnimationType.alpha:
                _tween.SetFade();
                break;
            case EnumUIMenuAnimationType.slideLeftRight:
                _currentRectTransform.anchoredPosition = new Vector2(-CurrentObjectWidth, 0);
                break;
            case EnumUIMenuAnimationType.slideRightLeft:
                _currentRectTransform.anchoredPosition = new Vector2(CurrentObjectWidth, 0);
                break;
            case EnumUIMenuAnimationType.slideBottomTop:
                _currentRectTransform.anchoredPosition = new Vector2(0, -CurrentObjectHeight);
                break;
            case EnumUIMenuAnimationType.slideTopBottom:
                _currentRectTransform.anchoredPosition = new Vector2(0, CurrentObjectHeight);
                break;
        }
    }

    //set animation setting by uiMenuAnimationType
    private void SetAnimationSettings()
    {
        _tween.SetAnimatioDuration(_animetionSettings.duration);

        switch (_animetionSettings.uiMenuAnimationType)
        {
            case EnumUIMenuAnimationType.alpha:
                _tween.SetFadeStartEndValues(0, 1);
                break;
            case EnumUIMenuAnimationType.slideLeftRight:
                _tween.SetAnimationPosition(new Vector2(-CurrentObjectWidth, 0), new Vector2(0, 0), _animetionSettings.showAnimationCurve, _animetionSettings.hideAnimationCurve);
                break;
            case EnumUIMenuAnimationType.slideRightLeft:
                 _tween.SetAnimationPosition(new Vector2(CurrentObjectWidth, 0), new Vector2(0, 0), _animetionSettings.showAnimationCurve, _animetionSettings.hideAnimationCurve);
                break;
            case EnumUIMenuAnimationType.slideBottomTop:
                _tween.SetAnimationPosition(new Vector2(0, -CurrentObjectHeight), new Vector2(0, 0), _animetionSettings.showAnimationCurve, _animetionSettings.hideAnimationCurve);
                break;
            case EnumUIMenuAnimationType.slideTopBottom:
                 _tween.SetAnimationPosition(new Vector2(0, CurrentObjectHeight), new Vector2(0, 0), _animetionSettings.showAnimationCurve, _animetionSettings.hideAnimationCurve);
                break;
            default:
                LoggingManager.AddErrorToLog("Doesnt release next animation type in UI menu " + _animetionSettings.uiMenuAnimationType.ToString());
                break;
        }
    }

    /* release IUIMenuController methods 
     * */
    public abstract EnumUIMenuID MenuID { get; }
    // hide menu without animation 
    public virtual void Hide()
    {
        if (_tween!=null)
        {
            _tween.ChangeSetState(false);
        }
            
        gameObject.SetActive(false);
    }
    // show menu without animation 
    public virtual void Show()
    {
        if (_tween != null)
        {
            _tween.ChangeSetState(true);
        }

        gameObject.SetActive(true);
    }
    //start hide tween animation 
    public virtual void HideAnimation()
    {
        if (_tween != null)
        {
            if (_tween.animationParts.ObjectState == UITween.AnimationParts.State.OPEN)
            {
                StartAnimation();
            }
        }
        else
        {
            Hide();
        }
    }
    //start show tween animation
    public virtual void ShowAnimation()
    {
        if (_tween != null)
        {
            if (_tween.animationParts.ObjectState == UITween.AnimationParts.State.CLOSE)
            {
                StartAnimation();
            }
        } else
        {
            Show();
        }
    }

    private void StartAnimation()
    {
        if (!_isAnimationing)
        {
            _tween.OpenCloseObjectAnimation();

            if (_animetionSettings.duration>0)
            {
                //recall this for reset settings for tweens bc if in game change display it all will work normal
                SetAnimationSettings();
                StartCoroutine(AnimationTimer());
            }
        }
    }

    private IEnumerator AnimationTimer()
    {
        _isAnimationing = true;
        float timerSpent = 0;
        while (timerSpent< _animetionSettings.duration)
        {
            timerSpent += Time.deltaTime;
            yield return null;
        }
        _isAnimationing = false;
        yield break;
    }

    // childe overide this method if i waiting some data 
    public virtual object Data
    {
        set
        {
            
        }
    }
    //set def position
    private void Start()
    {
        IUIScreenNavigationController[] uiNavigationControllerArray = gameObject.GetComponentsInChildren<IUIScreenNavigationController>();
        for (int i = 0; i < uiNavigationControllerArray.Length; i++)
        {
            uiNavigationControllerArray[i].Source = gameObject;
        }
        RectTransform baseRectTransform = gameObject.GetComponent<RectTransform>();
        if (baseRectTransform == null)
        {
            LoggingManager.AddErrorToLog("Didn't found RectTransform in menu " + MenuID.ToString());

        }
        else
        {
            baseRectTransform.offsetMin = new Vector2(0, 0);
            baseRectTransform.offsetMax = new Vector2(0, 0);
        }
    }

}
