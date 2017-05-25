using System;
using System.Collections.Generic;
using UnityEngine;

public class MainGameController : ControllerSingleTone<MainGameController>, IInitilizationProcess
{

    /**
     * Initialization process 
     * */
    private EnumInitializationStatus _initializationStatus;
    public bool allInitializated
    {
        get
        {
            return _initializationStatus == EnumInitializationStatus.initializated;
        }
    }

    public string ClassNameInInitialization
    {
        get
        {
            return "Main game controller";
        }
    }

    public EnumInitializationStatus initializationStatus
    {
        get
        {
            return _initializationStatus;
        }
    }

    public void StartInitialization()
    {
        _initializationStatus = EnumInitializationStatus.initializated;
    }
    /***
     * GameLogic
     * */
    //moving 
    
    private TransmissionData _selectedTransmission;
    public TransmissionData SelectedTransmission { get { return _selectedTransmission; } }
    
    private void SelectTrasmision(int index)
    {
        _selectedTransmission = _locomotiveSettings.Train.GetTransmissionDataByIndex(index);
    }
    // train settings 
    private LocomotiveSettings _locomotiveSettings = new LocomotiveSettings();
    public LocomotiveSettings LocomotiveSettings
    {
        get
        {
            return _locomotiveSettings;
        }
    }

    private void PrepareTrain()
    {
        _locomotiveSettings.AddCarriage("carriage_1");
        _locomotiveSettings.SelectTrain("train_1");
        int selectedTransmisionINdex = 0;
        for (int i = 0; i < _locomotiveSettings.Train.transmissionList.Count; i++)
        {
            if (i == 0)
            {
                selectedTransmisionINdex = _locomotiveSettings.Train.transmissionList[i].index;
            }
            else
            {
                if (selectedTransmisionINdex > _locomotiveSettings.Train.transmissionList[i].index)
                {
                    selectedTransmisionINdex = _locomotiveSettings.Train.transmissionList[i].index;
                }
            }
        }
        SelectTrasmision(selectedTransmisionINdex);
    }

    //state of game flow at the moment
    public delegate void ChangeEmptyDelegate();
    public ChangeEmptyDelegate changeFlowStateDispatcher;
    //
    private EnumGameFlowState _gameFlowState = EnumGameFlowState.gamePlay;
    /// <summary>
    /// Dispatch event when game controller change game flow state
    /// </summary>
    /// <param name="newState">new game flow state</param>
    private void CahngeGameState(EnumGameFlowState newState)
    {
        if (newState != _gameFlowState)
        {
            _gameFlowState = newState;
            if (changeFlowStateDispatcher!= null)
            {
                changeFlowStateDispatcher();
            }
        }
    }
    // controll of selected game element
    //when player select train or carriage by tab in
    public delegate void SelectGamePlayElement();
    public SelectGamePlayElement selectGamePlayElementDispatcher;

    private string _selectedGameElement = "carriage_1";
    public string SelectedGameElement { get { return _selectedGameElement; } }
    /// <summary>
    /// Select game element in game word by user 
    /// </summary>
    /// <param name="value">name of new game elemnt</param>
    public void SelecteGameElement(string value)
    {
        if (value != _selectedGameElement)
        {
            _selectedGameElement = value;
            if (selectGamePlayElementDispatcher!=null)
            {
                selectGamePlayElementDispatcher();
            }
        }
        
    }
    /// <summary>
    /// Finish prepering and start game
    /// </summary>
    public void StartGame()
    {
        //TODO temp 
        PrepareTrain();
        GameViewManager.Instance.ShowGamePlayView();

        
        
    }
    
    // controll of touch in game 
    //cpmmponents add listener to this event, if it need 
    public delegate void GamePlayWordTouchDispatcher(Vector3 touchPosition);
    public GamePlayWordTouchDispatcher gamePlaywordTouchDispatcher;

    /// <summary>
    /// Word click
    /// </summary>
    /// <param name="position">position of click in word</param>
    public void WordTouchCordinat(Vector3 position)
    {
        if(gamePlaywordTouchDispatcher!=null && _gameFlowState == EnumGameFlowState.gamePlay)
        {
            gamePlaywordTouchDispatcher(position);
        }
    }
}
