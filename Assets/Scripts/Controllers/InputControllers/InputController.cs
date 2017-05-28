using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
/**
* Controll of input 
* */
public enum EnumInputAction
{
    touch,
    clicked,
    startDrag,
    draging,
    stopDrag
}

public class InputController : ControllerSingleTone<InputController>, IInitilizationProcess, ITouchCommand
{

    /* Dispatch action for listener out class 
     * */
    public delegate void WordTouchDispatcher(EnumInputAction action, Vector3 touchPosition);
    public WordTouchDispatcher wordTouchDispatcher;
    private void DispatchWordTouchAction(EnumInputAction action)
    {
        if (wordTouchDispatcher!=null)
        {
            wordTouchDispatcher(action, _newTouchPosition);
        }
    }

    //
    private const int START_DRAG_TIMER = 10;
    private const float SPEED_DRAG_TIMER = 1;

    private RaycastHit2D _hit;
    private ITouchCommand _touchCommand;

    private float _touchTimer;
    private bool _draging;
    private bool _touched;

    private Vector3 _oldTouchPosition;
    private Vector3 _newTouchPosition;

    // UI element was touched 
    private bool _uiELementWasTouched = false;
    /***
     * Initialization process 
     * */
    private EnumInitializationStatus _initializationStatus;
    public void StartInitialization()
    {
        _initializationStatus = EnumInitializationStatus.initializated;
    }


    public EnumInitializationStatus initializationStatus
    {
        get
        {
            return _initializationStatus;
        }
    }

    public bool allInitializated
    {
        get
        {
            return _initializationStatus == EnumInitializationStatus.initializated;
        }
    }

    public virtual string ClassNameInInitialization
    {
        get
        {
            return "Input controller";
        }
    }

    //take touch position, after touch started, call frome child
    public void TouchedInPosition(Vector3 startPosition)
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (_touched)
        {
            return;
        }

        _newTouchPosition = Camera.main.ScreenToWorldPoint(startPosition);
        _touched = true;
        _touchTimer = 0;

        GetHitRay();
    }

    //stop touched, call frome child   
    public void StopTouched()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            _touched = false;
            _draging = false;
            return;
        }

        if (_touched)
        {
            TouchClick();
        }
        if (_draging)
        {
            TouchStopDrag();
        }
    }

    //ray cast
    protected void GetHitRay()
    {
        _hit = Physics2D.Raycast(_newTouchPosition, Vector2.zero);
        if (_hit && _hit.collider!=null)
        {
            //if game object has TouchCommand
            _touchCommand = _hit.collider.gameObject.GetComponent<ITouchCommand>();
            if (_touchCommand != null)
            {
                return;
            }
        }
        DispatchWordTouchAction(EnumInputAction.touch);
        _touchCommand = null;
    }

    //call by child ever Frame in childe update function
    public void ChekOnTouching(Vector3 newPosition)
    {
        if (_touched)
        {
            if (_touchTimer < START_DRAG_TIMER)
            {
                _touchTimer += SPEED_DRAG_TIMER + Time.deltaTime;
            }
            else
            {
                TouchStartDrag();
            }
        }

        if (_draging)
        {
            TouchMoved(newPosition);
        }

    }

    //functions from interface
    public void TouchClick()
    {
        _touched = false;
        if (_touchCommand != null)
        {
            _touchCommand.TouchClick();
        }
        //Just for current game
        else
        {
            DispatchWordTouchAction(EnumInputAction.clicked);
        }
    }

    public void TouchMoved(Vector3 movedPosition)
    {
        _oldTouchPosition = _newTouchPosition;
        _newTouchPosition = Camera.main.ScreenToWorldPoint(movedPosition);
        //if touched object is not draggable will start dragging of camera
        if (Draggable)
        {
            _touchCommand.TouchMoved(_newTouchPosition- _oldTouchPosition);
        }
        else
        {
            Vector3 move = _oldTouchPosition - _newTouchPosition;
            DispatchWordTouchAction(EnumInputAction.draging);
            //CameraNavigationManager.Instance.MoveToNewPosition(move);
        }
    }

    public void TouchStartDrag()
    {
        _touched = false;
        _draging = true;
        if (Draggable)
        {
            _touchCommand.TouchStartDrag();
        } else
        {
            DispatchWordTouchAction(EnumInputAction.startDrag);
        }
    }

    public void TouchStopDrag()
    {
        _draging = false;
        if (Draggable)
        {
            _touchCommand.TouchStopDrag();
        }
        else
        {
            DispatchWordTouchAction(EnumInputAction.stopDrag);
        }
    }

    public bool Draggable
    {
        get
        {
            return (_touchCommand != null && _touchCommand.Draggable);
        }
    }
}
