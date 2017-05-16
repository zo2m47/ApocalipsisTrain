using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Manager of hide and show UIscreen with animations 
 */

public class UIScreenAnimationManager : ManagerSingleTone<UIScreenAnimationManager>,IInitilizationProcess
{
    private bool _isAnimating = false;
    private GameObject _nextUIScreen;
    private GameObject _currentUIScreen;
    private UIScreenAnimationSettings _animtionSettings;
    private EasyTween _nextUIScreenTween;
    private EasyTween _currentUIScreenTween;
    private RectTransform _display;

    public bool isAnimating { get { return _isAnimating; } }
    /*
     * Initialization progress 
     * */
    private EnumInitializationStatus _initializationStatus;
    public EnumInitializationStatus initializationStatus { get { return _initializationStatus; } }
    public bool allInitializated { get { return _initializationStatus == EnumInitializationStatus.initializated; }}
    public string ClassNameInInitialization { get { return "Screen animations"; } }
    public void StartInitialization()
    {
        _initializationStatus = EnumInitializationStatus.inProgress;
        StartCoroutine(CheckOnAllInitializate());
    }

    private IEnumerator CheckOnAllInitializate()
    {
        while (_nextUIScreenTween == null || _currentUIScreenTween == null || _display == null)
        {
            yield return null;
        }
        _initializationStatus = EnumInitializationStatus.initializated;
        yield break;
    }

    private void Start()
    {
        if (_nextUIScreenTween == null)
        {
            _nextUIScreenTween = gameObject.AddComponent<EasyTween>();
            _nextUIScreenTween.ResetAnimationParts();
        }

        if (_currentUIScreenTween == null)
        {
            _currentUIScreenTween = gameObject.AddComponent<EasyTween>();
            _currentUIScreenTween.ResetAnimationParts();
        }
        if (_display == null)
        {
            _display = GameObject.FindGameObjectWithTag(TagNames.TAG_UI_SCREEN_CONTAINER).GetComponent<RectTransform>();
        }
    }

    /*Logic 
     * */
    public void StartAnimateNavigation(UIScreenAnimationSettings settings, IUIScreenController nextUIScreen = null, IUIScreenController currentUIScreen = null)
    {
        _animtionSettings = settings;
        _nextUIScreen = nextUIScreen.baseGameObject;
        _currentUIScreen = currentUIScreen.baseGameObject;

        _nextUIScreenTween.rectTransform = nextUIScreen.baseRectTransform;
        _nextUIScreenTween.ChangeSetState(false);
        _currentUIScreenTween.rectTransform = currentUIScreen.baseRectTransform;
        _currentUIScreenTween.ChangeSetState(false);
        //set layer position 
        UIScreensLayerPositions();
        //set uration of tweens
        SetDuration();
        //set tween settings 
        SetAnimationParams();
        //start animations
        StartAnimation();
    }
    
    /*set layer position
     * */
    private void UIScreensLayerPositions()
    {
        //check if on of object is null 
        if (_currentUIScreen == null && _nextUIScreen == null)
        {
            LoggingManager.AddErrorToLog("Try show UI screen animation without nex and current screen");
            return;
        }

        if (_currentUIScreen == null)
        {
            _nextUIScreen.transform.SetSiblingIndex(0);
            return;
        }


        if (_nextUIScreen == null )
        {
            _currentUIScreen.transform.SetSiblingIndex(0);
            return;
        }

        //if next screen withOut animation so position
        if (_animtionSettings.staticNextUIScreen)
        {
            _currentUIScreen.transform.SetSiblingIndex(1);
            _nextUIScreen.transform.SetSiblingIndex(0);
        }
        else
        {
            _currentUIScreen.transform.SetSiblingIndex(0);
            _nextUIScreen.transform.SetSiblingIndex(1);
        }
    }
    /* Set durations 
     * */
    private void SetDuration()
    {
        _currentUIScreenTween.SetAnimatioDuration(_animtionSettings.duration);
        _nextUIScreenTween.SetAnimatioDuration(_animtionSettings.duration);
    }
    /*Logic of animation 
     * */
    private void SetAnimationParams()
    {
        switch (_animtionSettings.uiScreenAnimationType)
        {
            case EnumUIScreenAnimationType.withOut:
                WithOutAnimation();
                break;
            case EnumUIScreenAnimationType.slideBottomTop:
                SlideBottomTop();
                break;
            case EnumUIScreenAnimationType.slideTopBottom:
                SlideTopBottom();
                break;
            case EnumUIScreenAnimationType.slideLeftRight:
                SlideLeftRight();
                break;
            case EnumUIScreenAnimationType.slideRightLeft:
                SlideRightLeft();
                break;
            default:
                LoggingManager.AddErrorToLog(_animtionSettings.uiScreenAnimationType + "Doesn't realesed in UIAinimationManager");
                break;
        }
    }
    /* fade animation*/
    private void WithOutAnimation()
    {
        _nextUIScreen.transform.localPosition = new Vector3(0, 0, 0);
        _currentUIScreen.transform.localPosition = new Vector3(0, 0, 0);
    }
    /*Slide Next screen start animation in Bottom and current screen hid to Top */
    private void SlideBottomTop()
    {
        if (!_animtionSettings.staticCurrentUIScreen)
        {
            _currentUIScreenTween.SetAnimationPosition(new Vector2(0, 0), new Vector2(0, ScreenHeight(_currentUIScreenTween.rectTransform)), _animtionSettings.animationCurve, _animtionSettings.animationCurve);
        }

        if (!_animtionSettings.staticNextUIScreen)
        {
            _nextUIScreenTween.SetAnimationPosition(new Vector2(0, -1* ScreenHeight(_nextUIScreenTween.rectTransform)), new Vector2(0, 0), _animtionSettings.animationCurve, _animtionSettings.animationCurve);
        }
    }
    /*Slide Next screen start animation in TOP and current screen hid to Bottom */
    private void SlideTopBottom()
    {
        if (!_animtionSettings.staticCurrentUIScreen)
        {
            _currentUIScreenTween.SetAnimationPosition(new Vector2(0, 0), new Vector2(0, -1* ScreenHeight(_currentUIScreenTween.rectTransform)), _animtionSettings.animationCurve, _animtionSettings.animationCurve);
        }

        if (!_animtionSettings.staticNextUIScreen)
        {
            _nextUIScreenTween.SetAnimationPosition(new Vector2(0, ScreenHeight(_nextUIScreenTween.rectTransform)), new Vector2(0, 0), _animtionSettings.animationCurve, _animtionSettings.animationCurve);
        }
    }
    /*Slide Next screen start animation in Left and current screen hid to Right */
    private void SlideLeftRight()
    {
        if (!_animtionSettings.staticCurrentUIScreen)
        {
            _currentUIScreenTween.SetAnimationPosition(new Vector2(0, 0), new Vector2(ScreenWidth(_currentUIScreenTween.rectTransform), 0), _animtionSettings.animationCurve, _animtionSettings.animationCurve);
        }

        if (!_animtionSettings.staticNextUIScreen)
        {
            _nextUIScreenTween.SetAnimationPosition(new Vector2(-1* ScreenWidth(_nextUIScreenTween.rectTransform), 0), new Vector2(0, 0), _animtionSettings.animationCurve, _animtionSettings.animationCurve);
        }
    }
    /*Slide Next screen start animation in Right and current screen hid to Left */
    private void SlideRightLeft()
    {
        if (!_animtionSettings.staticCurrentUIScreen)
        {
            _currentUIScreenTween.SetAnimationPosition(new Vector2(0, 0), new Vector2(-1 * ScreenWidth(_currentUIScreenTween.rectTransform), 0), _animtionSettings.animationCurve, _animtionSettings.animationCurve);
        }

        if (!_animtionSettings.staticNextUIScreen)
        {
            _nextUIScreenTween.SetAnimationPosition( new Vector2(ScreenWidth(_nextUIScreenTween.rectTransform), 0), new Vector2(0, 0), _animtionSettings.animationCurve, _animtionSettings.animationCurve);
        }
    }
    /* Some methods for help 
     * */
    private void StartAnimation()
    {
        bool startAnimationDuration = false;
        if (_animtionSettings.uiScreenAnimationType != EnumUIScreenAnimationType.withOut)
        {
            if (_animtionSettings.staticNextUIScreen)
            {
                _nextUIScreen.transform.localPosition = new Vector3(0, 0, 0);
                _nextUIScreen.SetActive(true);
            }
            else
            {
                _nextUIScreenTween.OpenCloseObjectAnimation();
                startAnimationDuration = true;
            }

            if (_animtionSettings.staticCurrentUIScreen)
            {
                _currentUIScreen.transform.localPosition = new Vector3(0, 0, 0);
            }
            else
            {
                _currentUIScreenTween.OpenCloseObjectAnimation();
                startAnimationDuration = true;
            }
        }
        else 
        {
            _nextUIScreen.transform.localPosition = new Vector3(0, 0, 0);
        }
        
        if (startAnimationDuration)
        {
            StartCoroutine(StartWaitingOfFinishAnimation());
        }
        else
        {
            _nextUIScreen.SetActive(true);
            _currentUIScreen.SetActive(false);
        }
    }

    private IEnumerator StartWaitingOfFinishAnimation()
    {
        _isAnimating = true;
        float timerSpent = 0;
        while (timerSpent< _animtionSettings.duration)
        {
            timerSpent += Time.deltaTime;
            yield return null;
        }
        _currentUIScreen.SetActive(false);
        _isAnimating = false;
        yield break;
    }

    private float ScreenWidth(RectTransform rectTransform)
    {
        float res = rectTransform.rect.width;
        return res;
    }

    private float ScreenHeight(RectTransform rectTransform)
    {
        float res = rectTransform.rect.height;
        return res;
    }
}
