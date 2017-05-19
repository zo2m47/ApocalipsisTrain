using System;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;

public class WeaponData
{
    [XmlAttribute("power")]
    public int power = 0;

    [XmlAttribute("cooldown")]
    public int cooldown = 0;

    [XmlAttribute("cartridge")]
    public int cartridge = 0;

    [XmlAttribute("reloading")]
    public int reloading = 0;

    [XmlAttribute("aimSpeed")]
    public int aimSpeed= 0;

}
