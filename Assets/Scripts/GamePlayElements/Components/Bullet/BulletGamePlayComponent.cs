using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class BulletGamePlayComponent : GamePlayComponent
{
    protected override GamePlayController GamePlayElementController
    {
        get
        {
            return base.GamePlayElementController;
        }
    }

    protected WeaponData WeaponData
    {
        get
        {
            return BulletGamePlayController.WeaponData;
        }
    }

    protected Quaternion AimAngle
    {
        get
        {
            return BulletGamePlayController.AimAngle;
        }
    }

    protected virtual BulletGamePlayController BulletGamePlayController
    {
        get
        {
            return base.GamePlayElementController as BulletGamePlayController;
        }
    }
}
