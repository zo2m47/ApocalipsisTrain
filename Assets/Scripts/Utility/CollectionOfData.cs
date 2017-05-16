
using System;
using System.Collections.Generic;
using UnityEngine;

public class CollectionOfData:IInitilizationProcess 
{
    //Dictionary with elements of static where key is id static data elemtn
    private Dictionary<string, IStaticData> _collaction;
    private List<string> _listOfAllNames;
    //uses for error logging
    private string _collactionName = "";
    /**
     * Initialization process 
     * */
    private EnumInitializationStatus _initializationStatus;
    public void StartInitialization()
    {
        _initializationStatus = EnumInitializationStatus.inProgress;
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

    public string ClassNameInInitialization
    {
        get
        {
            return _collactionName;
        }
    }

    public void InitCollaction<T>(string staticFileName) where T : DataVO
    {
        StartInitialization();
        T traceValue;
        LoggingManager.Log(typeof(T) + " Start initialization");
        _collactionName = staticFileName;
        StaticResourcesXmlLoader<T> container = StaticResourcesXmlLoader<T>.LoadContainer(UrlXmls.staticData+staticFileName);
        _collaction = new Dictionary<string, IStaticData>();
        _listOfAllNames = new List<string>();
        foreach (T data in container.dataList)
        {
            if (!_collaction.ContainsKey(data.Name))
            {
                _collaction.Add(data.Name, data);
                _listOfAllNames.Add(data.Name);
            } else
            {
                LoggingManager.AddErrorToLog("Repeated static data element with id "+ data.Name);
            }
        }
        LoggingManager.Log(typeof(T) + " Finish initialization");
        _initializationStatus = EnumInitializationStatus.initializated;
    }
    /**
     * Logic 
     * */
    public IStaticData GetDataById(string name)
    {
        if (_collaction.ContainsKey(name))
        {
            return _collaction[name];
        }
        LoggingManager.AddErrorToLog("Did't found data with id "+name+" in collection "+_collactionName);
        return (IStaticData)new object();
    }

   
    public Dictionary<string, IStaticData> Collaction
    {
        get
        {
            return _collaction;
        }
    }

    public List<string> List
    {
        get
        {
            return _listOfAllNames;
        }
    }


}
