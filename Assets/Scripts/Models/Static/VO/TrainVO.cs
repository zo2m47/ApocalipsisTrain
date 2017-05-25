using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

public class TrainVO : DataVO, IGameElement, IMarketData, IComponentData
{
    [XmlAttribute("strength")]
    public int strength = 0;
    public int Strength { get { return strength; } }

    [XmlElement("weapon")]
    public WeaponData weapon;
    public WeaponData Weapon { get { return weapon; } }

    [XmlElement("storage")]
    public StorageData storage;
    public StorageData Storage { get { return storage; } }

    [XmlElement("collector")]
    public CollectorData collector;
    public CollectorData Collector { get { return collector; } }
    
    [XmlAttribute("engine")]
    public int engine = 0;

    [XmlElement("market")]
    public MarketData market = null;
    public MarketData Market { get { return market; } }

    [XmlArray("transmissions")]
    [XmlArrayItem("transmission")]
    public List<TransmissionData> transmissionList;
    
    public TransmissionData GetTransmissionDataByIndex(int index)
    {
        for (int i = 0; i < transmissionList.Count; i++)
        {
            if(transmissionList[i].index == index)
            {
                return transmissionList[i];
            }
        }
        LoggingManager.AddErrorToLog("Didn found "+index+ " transmission");
        return transmissionList[0];
    }

    public string PrefabUrl
    {
        get
        {
            return PrefabsURL.TRAIN_GAME_ELEMENT + view;
        }
    }
}
