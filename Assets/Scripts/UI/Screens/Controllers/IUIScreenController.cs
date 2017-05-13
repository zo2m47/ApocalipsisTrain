using UnityEngine;

public interface IUIScreenController
{
    void SetData(object data);
    EnumUIScreenID screenID { get;  }
    GameObject baseGameObject { get; }
    RectTransform baseRectTransform { get; }
}
