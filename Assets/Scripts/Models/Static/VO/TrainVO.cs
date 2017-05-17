using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

public class TrainVO : DataVO, IGameElement
{
    [XmlAttribute("strength")]
    public int strength = 0;

    [XmlAttribute("engine")]
    public int engine = 0;

    [XmlElement("market")]
    public MarketData market = null;

    [XmlArray("transmissions")]
    [XmlArrayItem("transmission")]
    public List<TransmissionData> transmissionList = new List<TransmissionData>();

    [XmlElement("weapon")]
    public WeaponData weapon;

    public string PrefabUrl
    {
        get
        {
            return PrefabsURL.TRAIN_GAME_ELEMENT + view;
        }
    }
}
