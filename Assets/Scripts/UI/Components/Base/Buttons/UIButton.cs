using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIButton : MonoBehaviour, IUIButton, IPointerClickHandler
{
    protected Button _sourceBtn;

    void Awake()
    {
        _sourceBtn = gameObject.GetComponent<Button>();
    }

    public bool Enabled {
        get {
            return _sourceBtn.enabled;
        }
        set {
            _sourceBtn.enabled = value;
        }
    }

    public event EventHandler Selected;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Selected != null)
            Selected.Invoke(this, EventArgs.Empty);
    }
}
