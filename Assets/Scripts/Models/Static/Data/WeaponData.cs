using System;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;

public class WeaponData
{
    [XmlAttribute("power")]
    public int power = 0;

    [XmlAttribute("cooldown")]
    public float cooldown = 0;

    [XmlAttribute("cartridge")]
    public int cartridge = 0;

    [XmlAttribute("reloading")]
    public float reloading = 0;

    [XmlAttribute("aimSpeed")]
    public float aimSpeed= 0;

    [XmlAttribute("bulletView")]
    public string bulletView = "";

    [XmlAttribute("bulletSpeed")]
    public float bulletSpeed = 0.1f;

    [XmlAttribute("bulletRage")]
    public float bulletRage = 1f;
}
