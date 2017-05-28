using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***
 * Class with logic of Train in game
 * */
public class TrainGamePlayController : GamePlayController
{
    [SerializeField]
    private GameObject _connector;
    public GameObject Connector { get { return _connector; } }
    private float _height = 0;

    public override object StaticData
    {
        get
        {
            return base.StaticData as TrainVO;
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
