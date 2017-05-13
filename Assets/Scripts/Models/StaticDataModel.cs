using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
/**
* Logic with all static data in the game 
* */
public class StaticDataModel : ModelSingleTone<StaticDataModel>,IInitilizationProcess
{
    //static colactions
    private Dictionary<EnumStaticDataType, CollectionOfData> _allStaticData;
    private List<Collection> _initializationData;
    
    /**
     * Initialization Process 
     * */
    private EnumInitializationStatus _initializationStatus;
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

    public string classNameInInitialization
    {
        get
        {
            return "Static model";
        }
    }

    /// <summary>
    /// Add static data to initialization list, for initializat it
    /// </summary>
    public void StartInitialization()
    {
        _initializationStatus = EnumInitializationStatus.inProgress;
        _initializationData = new List<Collection>();
        _initializationData.Add(new Collection(EnumStaticDataType.carriage));
        _initializationData.Add(new Collection(EnumStaticDataType.mission));
        _initializationData.Add(new Collection(EnumStaticDataType.railway));
        _initializationData.Add(new Collection(EnumStaticDataType.terminal));
        _initializationData.Add(new Collection(EnumStaticDataType.train));
        StartCoroutine(CheckOnInitialized());

    }
    /// <summary>
    /// Wait of initializat all static data
    /// </summary>
    /// <returns></returns>
    private IEnumerator CheckOnInitialized()
    {
        bool allInitializated = false;
        while (!allInitializated)
        {
            allInitializated = true;
            foreach (Collection initilizationClass in _initializationData)
            {
                if (!initilizationClass.allInitializated)
                {
                    allInitializated = false;
                    yield return null;
                }
                if (initilizationClass.initializationStatus == EnumInitializationStatus.initializationError)
                {
                    yield break;
                }
            }
        }
        _allStaticData = new Dictionary<EnumStaticDataType, CollectionOfData>();
        for (int i = 0;i<_initializationData.Count;i++)
        {
            _allStaticData.Add(_initializationData[i].Type, _initializationData[i].CollectionOfData);
        }

        _initializationStatus = EnumInitializationStatus.initializated;
        yield break;
    }

    /// <summary>
    /// get static element by his unical name 
    /// </summary>
    /// <param name="name">unicel name of Statis Data</param>
    /// <returns>element VO Data</returns>
    public IStaticData GetStaticDataByName(string name)
    {
        foreach(CollectionOfData collection in _allStaticData.Values)
        {
            if (collection.List.IndexOf(name)!=-1)
            {
                return collection.Collaction[name];
            }
        }
        LoggingManager.AddErrorToLog("Didnt found "+name+" in static data");
        return null;
    }

    /// <summary>
    /// Get Collection data by static type 
    /// </summary>
    /// <param name="type">Static type</param>
    /// <returns>Static data</returns>
    public CollectionOfData GetCollectionByType(EnumStaticDataType type)
    {
        if (!_allStaticData.ContainsKey(type))
        {
            LoggingManager.AddErrorToLog("Try get static collection by type "+ type.ToString());
            return null;
        }
        return _allStaticData[type];
    }
}
/**
 * Class just for initialization list 
 * */
class Collection : IInitilizationProcess
{
    private CollectionOfData _collectionOfData;
    public CollectionOfData CollectionOfData { get { return _collectionOfData; } }
    
    public void StartInitialization()
    {
        throw new NotImplementedException();
    }

    public EnumInitializationStatus initializationStatus
    {
        get
        {
            return _collectionOfData.initializationStatus;
        }
    }

    public bool allInitializated
    {
        get
        {
            return _collectionOfData.allInitializated;
        }
    }

    public string classNameInInitialization
    {
        get
        {
           return _collectionOfData.classNameInInitialization;
        }
    }

    private EnumStaticDataType _type;
    public EnumStaticDataType Type { get { return _type; } }

    public Collection(EnumStaticDataType type)
    {
        _collectionOfData = new CollectionOfData();
        _type = type;
        switch (_type)
        {
            case EnumStaticDataType.withOutType:
                break;
            case EnumStaticDataType.carriage:
                _collectionOfData.InitCollaction<CarriageVO>(UrlXmls.CARRIAGE_LIST);
                break;
            case EnumStaticDataType.mission:
                _collectionOfData.InitCollaction<MissionVO>(UrlXmls.MISSION_LIST);
                break;
            case EnumStaticDataType.railway:
                _collectionOfData.InitCollaction<RailwayVO>(UrlXmls.RAILWAY_LIST);
                break;
            case EnumStaticDataType.terminal:
                _collectionOfData.InitCollaction<TerminalVO>(UrlXmls.TERMINAL_LIST);
                break;
            case EnumStaticDataType.train:
                _collectionOfData.InitCollaction<TrainVO>(UrlXmls.TRAIN_LIST);
                break;
            default:
                break;
        }
    }
}

