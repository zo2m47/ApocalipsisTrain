using System;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization; 

public class TransmissionData
{
    [XmlAttribute("index")]
    public int index = 0;

    [XmlAttribute("speed")]
    public int speed = 0;

    [XmlAttribute("change")]
    public int change = 0;
}
