using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class ButtonVisibleListenerByScreen : MonoBehaviour
{
    [SerializeField]
    private GameObject _button;
    [SerializeField]
    private List<EnumUIScreenID> _screensWhenButtonShouldBeHide;

    private void Start()
    {
        UIScreenManager.Instance.eventChangeScreen += ChangeScreenListener;
        CheckOfHidButton();
    }

    private void CheckOfHidButton()
    {
        if (_screensWhenButtonShouldBeHide.IndexOf(UIScreenManager.Instance.CurrentOpenedScreen) == -1)
        {
            ShowButton(true);
        }
        else
        {
            ShowButton(false);
        }
    }
    /// <summary>
    /// Hide of show button
    /// </summary>
    /// <param name="show"></param>
    private void ShowButton(bool show)
    {
        if (_button == null)
        {
            gameObject.SetActive(show);
        } else
        {
            _button.SetActive(show);
        }
    }

    /// <summary>
    /// Listener of screen change 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="evt"></param>
    private void ChangeScreenListener(object sender, EventArgs evt)
    {
        CheckOfHidButton();
    }
}
