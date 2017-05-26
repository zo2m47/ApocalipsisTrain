using UnityEngine;

public interface IUIScreenController
{
    void SetDefaulStartPosition();
    void SetData(object data);
    EnumUIScreenID screenID { get;  }
    GameObject baseGameObject { get; }
    RectTransform baseRectTransform { get; }
}
