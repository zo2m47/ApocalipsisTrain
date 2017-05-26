using System;
using System.Collections.Generic;
using UnityEngine;
/**
 * Settings of train before game 
 * */
public class LocomotiveData
{
    private TrainVO _train;
    public TrainVO Train { get { return _train; } }

    private List<CarriageVO> _carriageList = new List<CarriageVO>();
    public List<CarriageVO> CarriageList { get { return _carriageList; } }

    
    /**
     * Prepating train to game 
     * */
    public void SelectTrain(string name)
    {
        _train = StaticDataModel.Instance.GetTrain(name);
    }
    /**
     * Preparing Carriage to game
     * */
    //TODO check of weight train, 
    public void AddCarriage(string carriage)
    {
        _carriageList.Add(StaticDataModel.Instance.GetCarriage(carriage));
        
    }
}