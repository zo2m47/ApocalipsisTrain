using System;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;

public class RailwayVO : DataVO
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

    [XmlArray("attackList")]
    [XmlArrayItem("attack")]
    public List<AttackData> attackList;
}
