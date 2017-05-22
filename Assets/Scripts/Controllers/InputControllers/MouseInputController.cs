using System;
using UnityEngine;
/**
 * Use for testing in pc without touch functionals
 * Add in uity
 * */
public class MouseInputController : ControllerSingleTone<MouseInputController>, IInitilizationProcess
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            InputController.Instance.TouchedInPosition(Input.mousePosition);
        }
        if (Input.GetMouseButtonUp(0))
        {
            InputController.Instance.StopTouched();
        }

        InputController.Instance.ChekOnTouching(Input.mousePosition);
    }
    
    public void StartInitialization()
    {
        InputController.Instance.StartInitialization();
    }

    public string ClassNameInInitialization
    {
        get
        {
            return "Mouse Input controller";
        }
    }

    public EnumInitializationStatus initializationStatus
    {
        get
        {
            return InputController.Instance.initializationStatus;
        }
    }

    public bool allInitializated
    {
        get
        {
            return InputController.Instance.allInitializated;
        }
    }
}
