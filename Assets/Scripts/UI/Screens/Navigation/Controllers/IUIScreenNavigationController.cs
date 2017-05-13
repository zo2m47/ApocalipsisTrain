using UnityEngine;

public interface IUIScreenNavigationController
{
    GameObject Source { set; }
    EnumUIScreenID ScreenID { get; }
    object Data { get; }
    UIScreenAnimationSettings AnimationSettings { get; }

}
