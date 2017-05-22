using System;
using System.Collections.Generic;
using UnityEngine;
/***
 * Class with logic of carriage in game 
 * */
public class CarriageGamePlayController : BaseGamePlayController
{
    public override IStaticData StaticData
    {
        get
        {
            return base.StaticData as CarriageVO; 
        }
    }
}
