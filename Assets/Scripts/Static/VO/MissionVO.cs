using System;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;

public class MissionVO :DataVO
{
    public override EnumStaticDataType Type
    {
        get
        {
            return EnumStaticDataType.mission;
        }
    }

    [XmlArray("rewards")]
    [XmlArrayItem("reward")]
    public List<RewardData> rewardList;

    [XmlArray("conditions")]
    [XmlArrayItem("condition")]
    public List<ConditionData> conditionList;


}
