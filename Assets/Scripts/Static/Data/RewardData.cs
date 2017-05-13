using System;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;

public class RewardData : DataState
{
   
    [XmlAttribute("amount")]
    public int amount;


}
