using System;
using System.Collections.Generic;
using UnityEngine;
/***
 * Class with logic of carriage in game 
 * */
public class CarriageGamePlayController : GamePlayController
{
    [SerializeField]
    private GameObject _connector;
    public GameObject Connector { get { return _connector; } }
    public override object StaticData
    {
        get
        {
            return base.StaticData as CarriageVO; 
        }
    }
}
