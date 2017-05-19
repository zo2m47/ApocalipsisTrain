using System;
using System.Collections.Generic;
using UnityEngine;
/***
 * Class with logic of carriage in game 
 * */
public class CarriageGamePlayController : BaseGamePlayController
{
    public override object StaticData
    {
        get
        {
            return base.StaticData as CarriageVO; 
        }

        set
        {
            base.StaticData = value;
        }
    }
}
