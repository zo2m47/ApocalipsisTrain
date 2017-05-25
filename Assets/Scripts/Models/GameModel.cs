using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/***
 * Logic of player data in game, data of prepering for game, game play progress  
 * */
public class GameModel : ModelSingleTone<GameModel>, IInitilizationProcess
{
   
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
   
}
