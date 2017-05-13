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
public class UIMenuAnimationSettings
{
    //ANIMATION 
    [Tooltip("Animtion type of UIMenu")]
    [SerializeField]
    private EnumUIMenuAnimationType _uiMenuAnimationType = EnumUIMenuAnimationType.withOut;
    public EnumUIMenuAnimationType uiMenuAnimationType { get { return _uiMenuAnimationType; } }
    
    [Tooltip("Animation style of show UIMenu")]
    [SerializeField]
    private AnimationCurve _showAnimationCurve;
    public AnimationCurve showAnimationCurve { get { return _showAnimationCurve; } }

    [Tooltip("Animation style of hide UIMenu")]
    [SerializeField]
    private AnimationCurve _hideAnimationCurve;
    public AnimationCurve hideAnimationCurve { get { return _hideAnimationCurve; } }

    //ANIMATION DURATION
    [Tooltip("Animation duration")]
    [SerializeField]
    private float _duration = 1f;
    public float duration { get { return _duration; } }
}
