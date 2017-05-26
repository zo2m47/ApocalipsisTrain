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
    public override object StaticData
    {
        get
        {
            return base.StaticData as TrainVO;
        }
    }
}
