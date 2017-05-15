using System;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;

public class MarketData
{
    [XmlAttribute("resources")]
    public int resources = 0;
    
    public EnumMarketState state = EnumMarketState.open;
}
