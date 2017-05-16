//  ***************************************************************************
//  GamePlayModel.cs
//      
//  Copyright (c) 2017  Spina LLC
//  All rights reserved.
//
//  This software may not be copied, distributed or modified
//  without express permission of Spina LLC.  
//  The software is provided as is, in accordance with the license agreement.
//  ****************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/***
 * Logic of player data in game, data of prepering for game, game play progress  
 * */
public class GamePlayModel : ModelSingleTone<GamePlayModel>, IInitilizationProcess
{
    private TrainInGame _trainPrepareSetings = new TrainInGame();
    /**
     * Initialization logic 
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
            return "Game Play Model";
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

    /**
     * Preper player Train
     * */
    public void PrepareTrain()
    {
        _trainPrepareSetings.AddCarriage("carriage_1");
        _trainPrepareSetings.SelectTrain("train_1");
    }
}
