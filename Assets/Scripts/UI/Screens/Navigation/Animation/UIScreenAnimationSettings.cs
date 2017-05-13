using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/*//
 * Animation Settings for UIScreen changes
 * Settings set in inspector 
 * 
//*/
[Serializable]
public class UIScreenAnimationSettings
{
    // COVER FLAG
    [Tooltip("true: NEXT UIscreen will be added under output UIScreen \nfalse: NEXT UIScreen will hide with animation")]
    [SerializeField]
    private bool _staticNextUIScreen = false;
    public bool staticNextUIScreen { get { return _staticNextUIScreen; } }

    [Tooltip("true: CURRENT UIscreen will be added under output UIScreen \nfalse: CURRENT UIScreen will hide with animation")]
    [SerializeField]
    private bool _staticCurrentUIScreen = false;
    public bool staticCurrentUIScreen { get { return _staticCurrentUIScreen;  } }
    
    //ANIMATION 
    [Tooltip("Animtion type of show/hid UIScreen")]
    [SerializeField]
    private EnumUIScreenAnimationType _uiScreenAnimationType = EnumUIScreenAnimationType.withOut;
    public EnumUIScreenAnimationType uiScreenAnimationType { get { return _uiScreenAnimationType;  } }

    [Tooltip("Animation style")]
    [SerializeField]
    private AnimationCurve _animationCurve;
    public AnimationCurve animationCurve { get { return _animationCurve; } }

    //ANIMATION DURATION
    [Tooltip("Animation duration")]
    [SerializeField]
    private float _duration = 1f;
    public float duration { get { return _duration; } }

    public UIScreenAnimationSettings()
    {

    }

    public void SetRevertType(UIScreenAnimationSettings animationSetting)
    {
        _duration = animationSetting.duration;
        _animationCurve = animationSetting.animationCurve;
        _staticNextUIScreen = animationSetting.staticNextUIScreen;
        _staticCurrentUIScreen = animationSetting.staticCurrentUIScreen;
        if (animationSetting.uiScreenAnimationType == EnumUIScreenAnimationType.slideBottomTop)
        {
            _uiScreenAnimationType = EnumUIScreenAnimationType.slideTopBottom;
        }
        if (animationSetting.uiScreenAnimationType == EnumUIScreenAnimationType.slideLeftRight)
        {
            _uiScreenAnimationType = EnumUIScreenAnimationType.slideRightLeft;
        }
        if (animationSetting.uiScreenAnimationType == EnumUIScreenAnimationType.slideRightLeft)
        {
            _uiScreenAnimationType = EnumUIScreenAnimationType.slideLeftRight;
        }
        if (animationSetting.uiScreenAnimationType == EnumUIScreenAnimationType.slideTopBottom)
        {
            _uiScreenAnimationType = EnumUIScreenAnimationType.slideBottomTop; ;
        }
    }

}
