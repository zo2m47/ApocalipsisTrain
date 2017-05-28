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
    private float _height = 0;
    public override object StaticData
    {
        get
        {
            return base.StaticData as CarriageVO; 
        }
    }
    
    public float Height
    {
        get
        {
            if (_height == 0)
            {
                _height = gameObject.GetComponent<Renderer>().bounds.size.y;
            }
            return _height;
        }
    }
}
