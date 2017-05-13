using System;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;

public class StorageData
{
    [XmlAttribute("amount")]
    public int amount = 0;
}
