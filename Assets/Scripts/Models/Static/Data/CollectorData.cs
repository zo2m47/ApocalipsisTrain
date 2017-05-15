using System;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;

public class CollectorData
{
    [XmlAttribute("speed")]
    public int speed = 0;

    [XmlAttribute("amount")]
    public int amount = 0;
}
