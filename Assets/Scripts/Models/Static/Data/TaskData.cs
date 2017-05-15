using System;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;

public class TaskData :DataState
{
    [XmlAttribute("passedAmount")]
    public int passedAmount = 0;

}
