using System;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;

public class TerminalVO : DataVO
{
    public override EnumStaticDataType Type
    {
        get
        {
            return EnumStaticDataType.terminal;
        }
    }
    [XmlAttribute("location")]
    public string location = "";
    
}
