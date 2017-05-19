using System;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;

public class RailwayVO : DataVO, IMarketData
{
    public override EnumStaticDataType Type
    {
        get
        {
            return EnumStaticDataType.railway;
        }
    }

    [XmlAttribute("start")]
    public string start;

    [XmlAttribute("end")]
    public string end;

    [XmlAttribute("length")]
    public int length;

    [XmlElement("market")]
    public MarketData market;
    public MarketData Market { get { return market; } }

    [XmlArray("attackList")]
    [XmlArrayItem("attack")]
    public List<AttackData> attackList;
}
