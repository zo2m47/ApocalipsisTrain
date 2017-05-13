using System;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;

public class DataState
{
    [XmlAttribute("name")]
    public string name;

    [XmlAttribute("state")]
    public EnumStaticDataState state;
}
