using System;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization; 

public class TransmissionData
{
    [XmlAttribute("index")]
    public int index = 0;

    [XmlAttribute("speed")]
    public float speed = 0;

    [XmlAttribute("acceleration")]
    public float acceleration = 0;

    [XmlAttribute("braking")]
    public float braking = 0;
}
