using System;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;

public class AttackData
{
    [XmlAttribute("passedCounter")]
    public int passedCounter = 0;
}
