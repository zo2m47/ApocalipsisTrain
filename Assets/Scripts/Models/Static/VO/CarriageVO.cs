using System;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;

public class CarriageVO : DataVO,IGameElement, IComponentData, IMarketData
{
    public override EnumStaticDataType Type
    {
        get
        {
            return EnumStaticDataType.carriage;
        }
    }
    
    [XmlAttribute("weight")]
    public int weight = 0;

    [XmlAttribute("strength")]
    public int strength = 0;
    public int Strength{ get{ return strength;}}

    [XmlElement("weapon")]
    public WeaponData weapon;
    public WeaponData Weapon { get { return weapon; }}

    [XmlElement("storage")]
    public StorageData storage;
    public StorageData Storage { get { return storage; }}

    [XmlElement("collector")]
    public CollectorData collector;
    public CollectorData Collector { get { return collector; } }

    [XmlElement("market")]
    public MarketData market;
    public MarketData Market { get { return market; } } 

    public string PrefabUrl
    {
        get
        {
            return PrefabsURL.CARRIAGES_GAME_ELEMENT+view;
        }
    }

    
}
