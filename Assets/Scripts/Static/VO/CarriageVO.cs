using System;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;

public class CarriageVO : DataVO
{
    public override EnumStaticDataType Type
    {
        get
        {
            return EnumStaticDataType.carriage;
        }
    }

    [XmlAttribute("strength")]
    public int strength = 0;

    [XmlAttribute("weight")]
    public int weight = 0;

    [XmlElement("weapon")]
    public WeaponData weapon;

    [XmlElement("storage")]
    public StorageData storage;

    [XmlElement("collector")]
    public CollectorData collector;

    [XmlElement("market")]
    public MarketData market;

}
