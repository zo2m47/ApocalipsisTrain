using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***
 * Class with logic of Train in game
 * */
public class TrainGamePlayController : BaseGamePlayController
{
    public override IStaticData StaticData
    {
        get
        {
            return base.StaticData as TrainVO;
        }
    }
}
