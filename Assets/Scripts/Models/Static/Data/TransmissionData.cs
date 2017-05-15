using System;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization; 

public class TransmissionData
{
    [XmlElement("index")]
    public int index = 0;

    [XmlElement("speed")]
    public int speed = 0;

    [XmlElement("change")]
    public int change = 0;
}
