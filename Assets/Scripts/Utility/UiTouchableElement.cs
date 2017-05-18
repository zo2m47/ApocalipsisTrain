using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class UiTouchableElement : MonoBehaviour, IPointerDownHandler, IPointerClickHandler, IPointerExitHandler
{
    private const int CLICK_TIMER = 15;

    private bool _downed = false;
    private IEnumerator _coroutine;
    //нажали на елемент
    public virtual void OnPointerDown(PointerEventData eventData)
    {
        if (!_downed)
        {
            StopCoroutine(CheckOnHold());
        }
        _downed = true;
        StartCoroutine(CheckOnHold());
    }
    private IEnumerator coroutine
    {
        get
        {
            if (_coroutine == null)
            {
                _coroutine = CheckOnHold();
            }
            return _coroutine;
        }
    }

    //ждем CLICK_TIMER секунд
    private IEnumerator CheckOnHold()
    {
        int duration = 0;
        while(_downed && duration< CLICK_TIMER)
        {
            duration++;
            yield return null;
        }
        
        //если елемент не был отжат, значит это залипалка
        if (_downed)
        {
            _downed = false;
            Hold();
        }
        yield break;
    }
    // слушатель на клик
    public void OnPointerClick(PointerEventData eventData)
    {
        // елси флаг еще нажатой кнопки, то время проверки на зажатие еще не прошло
        if (_downed)
        {
            _downed = false;
            Click();
        }

    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        if (_downed)
        {
            _downed = false;
        }
    }
    
    protected virtual void Hold()
    {
        InputController.Instance.ClickedInUiElement();
    }
    
    protected virtual void Click()
    {
        InputController.Instance.ClickedInUiElement();
    }

}
